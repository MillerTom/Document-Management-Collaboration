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
    
    public partial class StateTransition
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int StateId { get; set; }
        public int NextStateId { get; set; }
    
        public virtual WorkflowAction WorkflowAction { get; set; }
        public virtual WorkflowState WorkflowState { get; set; }
        public virtual WorkflowState WorkflowState1 { get; set; }
    }
}
