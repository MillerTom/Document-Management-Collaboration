using System;
using System.Linq;
using MyCoop.Data;
using MyCoop.WebApi.Models.Components;

namespace MyCoop.WebApi.Models.WorkspaceTemplates
{
    public class WorkspaceTemplateModel
    {
        private readonly WorkspaceTemplate _workspaceTemplate;
        private readonly int _documentCount;
        private readonly ComponentModel[] _components;
        private readonly UserInfoModel _createdBy;
        private readonly UserInfoModel _modifiedBy;

        public WorkspaceTemplateModel(WorkspaceTemplate workspaceTemplate)
        {
            _workspaceTemplate = workspaceTemplate;
            _documentCount = workspaceTemplate.WorkspaceDocumentTemplates.Count;
            _components = workspaceTemplate.WorkspaceTemplateComponents.Select(c => new ComponentModel(c.Component)).ToArray();
            _createdBy = new UserInfoModel(_workspaceTemplate.User1);
            _modifiedBy = new UserInfoModel(_workspaceTemplate.User);
        }

        public int Id
        {
            get { return _workspaceTemplate.Id; }
        }

        public string Name
        {
            get { return _workspaceTemplate.Name; }
        }

        public DateTime CreationTime
        {
            get { return _workspaceTemplate.CreationTime; }
        }

        public DateTime ModificationTime
        {
            get { return _workspaceTemplate.ModificationTime; }
        }

        public UserInfoModel CreatedBy
        {
            get { return _createdBy; }
        }
        public UserInfoModel ModifiedBy
        {
            get { return _modifiedBy; }
        }

        public int DocumentCount
        {
            get { return _documentCount; }
        }

        public ComponentModel[] Components
        {
            get { return _components; }
        }
    }
}