using System;

namespace MyCoop.WebApi.Services
{
    public interface IServiceManager : IDisposable
    {
        T Get<T>();
    }
}