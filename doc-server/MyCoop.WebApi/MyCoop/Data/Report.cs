//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCoop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime ModificationTime { get; set; }
        public byte[] ReportLayout { get; set; }
        public string DataSourceType { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}