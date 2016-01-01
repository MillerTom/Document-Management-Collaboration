using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Repositories;

namespace MyCoop.WebApi.Services.Instances
{
    public abstract class ServiceBase
    {
        private readonly IRepositoryManager _repository;

        protected ServiceBase(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IRepositoryManager Repository
        {
            get { return _repository; }
        }

        protected Task<TResult> AsyncOperation<TResult, TTask>(Func<Task<TTask>> getTask, Func<TTask, TResult> getResult)
        {
            var tcs = new TaskCompletionSource<TResult>();
            getTask().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(getResult(_.Result));
                }
            });
            return tcs.Task;
        }

        protected Task<TResult> AsyncOperation<TResult, TTask, TSubTask>(Func<Task<TTask>> getTask, Func<Task<TSubTask>> getSubTask, Action<TTask> setResult, Func<TSubTask, TResult> getResult)
        {
            var tcs = new TaskCompletionSource<TResult>();
            getTask().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    setResult(_.Result);
                    getSubTask().ContinueWith(__ =>
                    {
                        if (__.Exception != null)
                        {
                            tcs.SetException(__.Exception);
                        }
                        else
                        {
                            tcs.SetResult(getResult(__.Result));
                        }
                    });
                }
            });
            return tcs.Task;
        }

        protected Task<TResult[]> GetValues<TResult, TEntity, TRepository>(Func<TEntity, TResult> mapper, params string[] includes)
            where TRepository : IRepository<TEntity>
        {
            return AsyncOperation(() => Repository.GetWithContext<TRepository>().GetValues(includes), result => result.Select(mapper).ToArray());
        }

        protected Task<TResult> GetValue<TResult, TEntity, TRepository>(int id, Func<TEntity, TResult> mapper, params string[] includes)
            where TRepository : IStdRepository<TEntity>
        {
            return AsyncOperation(() => Repository.GetWithContext<TRepository>().GetValue(id, includes), mapper);
        }

        protected Task<int> Add<TEntity, TRepository>(Func<TEntity, int> getId, Func<TEntity> getEntity)
            where TRepository : IRepository<TEntity>
        {
            var entity = getEntity();
            Repository.GetWithContext<TRepository>().Add(entity);
            return AsyncOperation(() => Repository.SaveChangesAsync(), _ => getId(entity));
        }

        protected Task Update<TEntity, TRepository>(int id, Action<TEntity> setter)
             where TRepository : IStdRepository<TEntity>
        {
            return AsyncOperation(() => Repository.GetWithContext<TRepository>().GetValue(id), () => Repository.SaveChangesAsync(), setter, _ => 0);
        }

        protected Task Delete<TEntity, TRepository>(int id)
            where TRepository : IStdRepository<TEntity>
        {
            var repository = Repository.GetWithContext<TRepository>();
            return AsyncOperation(() => repository.GetValue(id), () => Repository.SaveChangesAsync(), repository.Delete, _ => 0);
        }
    }
}