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
    
    public partial class BusinessProcessAttribute
    {
        public BusinessProcessAttribute()
        {
            this.AttributeBusinessProcesses = new HashSet<AttributeBusinessProcess>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttributeTypeId { get; set; }
    
        public virtual ICollection<AttributeBusinessProcess> AttributeBusinessProcesses { get; set; }
        public virtual AttributeType AttributeType { get; set; }
    }
}
