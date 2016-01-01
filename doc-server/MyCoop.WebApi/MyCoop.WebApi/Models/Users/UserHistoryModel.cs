using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Users
{
    public class UserHistoryModel
    {
        private readonly SysEvent _sysEvent;
        private readonly UserModel _user;

        public UserHistoryModel(SysEvent sysEvent)
        {
            _sysEvent = sysEvent;
            if (_sysEvent.User != null)
            {
                _user = new UserModel(_sysEvent.User);
            }
        }

        public UserModel User
        {
            get { return _user; }
        }

        public DateTime Time
        {
            get { return _sysEvent.Time; }
        }

        public string Status
        {
            get { return _sysEvent.Summary; }
        }

        public string UserAgent
        {
            get { return _sysEvent.Description; }
        }
    }
}