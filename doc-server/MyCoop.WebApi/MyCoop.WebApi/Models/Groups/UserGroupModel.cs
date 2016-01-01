using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Groups
{
    public class UserGroupModel
    {
        private readonly UserGroup _userGroup;

        public UserGroupModel(UserGroup userGroup)
        {
            _userGroup = userGroup;
        }
        public int Id
        {
            get { return _userGroup.GroupId; }
        }
        public string Name
        {
            get { return _userGroup.Group.Name; }
        }
        public string Description
        {
            get { return _userGroup.Group.Description; }
        }
        public DateTime CreationTime
        {
            get { return _userGroup.Group.CreationTime; }
        }
        public DateTime ModificationTime
        {
            get { return _userGroup.Group.ModificationTime; }
        }
        public int CreatedBy
        {
            get { return _userGroup.Group.CreatedByUserId; }
        }
        public int ModifiedBy
        {
            get { return _userGroup.Group.ModifiedByUserId; }
        }

        public DateTime AddTime
        {
            get { return _userGroup.CreationTime; }
        }
    }
}