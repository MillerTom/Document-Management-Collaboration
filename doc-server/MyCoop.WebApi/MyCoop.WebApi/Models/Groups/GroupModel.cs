using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Groups
{
    public class GroupModel
    {
        private readonly Group _group;
        private readonly UserInfoModel _createdBy;
        private readonly UserInfoModel _modifiedBy;

        public GroupModel(Group group)
        {
            _group = group;
            _createdBy = new UserInfoModel(_group.User1);
            _modifiedBy = new UserInfoModel(_group.User);
        }
        public int Id
        {
            get { return _group.Id; }
        }
        public string Name
        {
            get { return _group.Name; }
        }
        public string Description
        {
            get { return _group.Description; }
        }
        public DateTime CreationTime
        {
            get { return _group.CreationTime; }
        }
        public DateTime ModificationTime
        {
            get { return _group.ModificationTime; }
        }
        public UserInfoModel CreatedBy
        {
            get { return _createdBy; }
        }
        public UserInfoModel ModifiedBy
        {
            get { return _modifiedBy; }
        }
    }
}