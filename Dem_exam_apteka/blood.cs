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
    
    public partial class blood
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public blood()
        {
            this.blood_services = new HashSet<blood_services>();
        }
    
        public int id_blood { get; set; }
        public Nullable<int> patient { get; set; }
        public Nullable<int> barcode { get; set; }
        public string date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<blood_services> blood_services { get; set; }
    }
}
