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
    
    public partial class Analyzers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Analyzers()
        {
            this.DoneServices = new HashSet<DoneServices>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> DataAndTimeDelivery { get; set; }
        public Nullable<System.DateTime> DateAndTimeCompletion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoneServices> DoneServices { get; set; }
    }
}
