using MyCoop.Data;

namespace MyCoop.WebApi.Models
{
    public class UserInfoModel
    {
        private readonly User _user;

        public UserInfoModel(User user)
        {
            _user = user;
        }
        public int Id
        {
            get { return _user.Id; }
        }

        public string FirstName
        {
            get { return _user.FirstName; }
        }
        public string LastName
        {
            get { return _user.LastName; }
        }
    }
}