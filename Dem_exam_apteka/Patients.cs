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
    
    public partial class Patients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patients()
        {
            this.blood = new HashSet<blood>();
            this.Users = new HashSet<Users>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string social_sec_number { get; set; }
        public string ein { get; set; }
        public string social_type { get; set; }
        public string phone { get; set; }
        public string passport_s { get; set; }
        public string passport_n { get; set; }
        public string birthdate_timestamp { get; set; }
        public string country { get; set; }
        public string insurance_name { get; set; }
        public string insurance_address { get; set; }
        public string insurance_inn { get; set; }
        public string ipadress { get; set; }
        public string insurance_p_c { get; set; }
        public string insurance_bik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<blood> blood { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
    }
}