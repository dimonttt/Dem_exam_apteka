//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dem_exam_apteka
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderServices
    {
        public int ID { get; set; }
        public Nullable<int> Service { get; set; }
        public Nullable<int> Order { get; set; }
    
        public virtual DoneServices DoneServices { get; set; }
        public virtual Laboratory_services Laboratory_services { get; set; }
        public virtual Order Order1 { get; set; }
    }
}