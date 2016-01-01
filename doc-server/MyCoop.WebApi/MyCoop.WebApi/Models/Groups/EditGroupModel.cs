using MyCoop.Data;
using System;

namespace MyCoop.WebApi.Models.Groups
{
    public class EditGroupModel
    {
        private readonly Group _group = new Group();

        public EditGroupModel()
        {
            _group.CreationTime = DateTime.UtcNow;
            _group.ModificationTime = DateTime.UtcNow;
        }

        public string Name
        {
            get { return _group.Name; }
            set { _group.Name = value; }
        }
        public string Description
        {
            get { return _group.Description; }
            set { _group.Description = value; }
        }
        public int CreatedBy
        {
            get { return _group.CreatedByUserId; }
            set { _group.CreatedByUserId = value; }
        }
        public int ModifiedBy
        {
            get { return _group.ModifiedByUserId; }
            set { _group.ModifiedByUserId = value; }
        }

        public Group GetEntity()
        {
            return _group;
        }
    }
}