using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Reports
{
    public class EditReportModel
    {
        private readonly Report _report = new Report();

        public EditReportModel()
        {
            _report.CreationTime = DateTime.UtcNow;
            _report.ModificationTime = DateTime.UtcNow;
        }

        public string Name
        {
            get { return _report.Name; }
            set { _report.Name = value; }
        }
        public string Description
        {
            get { return _report.Description; }
            set { _report.Description = value; }
        }
        public int CreatedBy
        {
            get { return _report.CreatedById; }
            set { _report.CreatedById = value; }
        }
        public int ModifiedBy
        {
            get { return _report.ModifiedById; }
            set { _report.ModifiedById = value; }
        }

        public string DataSourceType
        {
            get { return _report.DataSourceType; }
            set { _report.DataSourceType = value; }
        }

        public Report GetEntity()
        {
            return _report;
        } 
    }
}