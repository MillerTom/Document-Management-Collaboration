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
    
    public partial class IncidentOrgUnit
    {
        public int IncidentId { get; set; }
        public int OrgUnitId { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
    
        public virtual Incident Incident { get; set; }
        public virtual OrgUnit OrgUnit { get; set; }
    }
}
