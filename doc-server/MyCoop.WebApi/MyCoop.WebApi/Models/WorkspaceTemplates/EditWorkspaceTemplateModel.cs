using System;
using MyCoop.Data;
using MyCoop.WebApi.Helpers;

namespace MyCoop.WebApi.Models.WorkspaceTemplates
{
    public class EditWorkspaceTemplateModel
    {
        private readonly WorkspaceTemplate _workspaceTemplate = new WorkspaceTemplate();

        public EditWorkspaceTemplateModel()
        {
            _workspaceTemplate.ModificationTime = DateTime.UtcNow;
            _workspaceTemplate.CreationTime = DateTime.UtcNow;
            _workspaceTemplate.CreatedByUserId = UserHelper.GetId();
            _workspaceTemplate.ModifiedByUserId = UserHelper.GetId();
        }

        public string Name
        {
            get { return _workspaceTemplate.Name; }
            set { _workspaceTemplate.Name = value; }
        }

        public WorkspaceTemplate GetEntity()
        {
            return _workspaceTemplate;
        }
    }
}