using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Reports
{
    public class ReportModel
    {
        private readonly Report _report;
        private readonly UserInfoModel _createdBy;
        private readonly UserInfoModel _modifiedBy;

        public ReportModel(Report report)
        {
            _report = report;
            _createdBy = new UserInfoModel(_report.User1);
            _modifiedBy = new UserInfoModel(_report.User);
        }
        public int Id
        {
            get { return _report.Id; }
        }
        public string Name
        {
            get { return _report.Name; }
        }
        public string Description
        {
            get { return _report.Description; }
        }
        public DateTime CreationTime
        {
            get { return _report.CreationTime; }
        }
        public DateTime ModificationTime
        {
            get { return _report.ModificationTime; }
        }
        public UserInfoModel CreatedBy
        {
            get { return _createdBy; }
        }
        public UserInfoModel ModifiedBy
        {
            get { return _modifiedBy; }
        }

        public string DataSourceType
        {
            get { return _report.DataSourceType; }
        }
    }
}