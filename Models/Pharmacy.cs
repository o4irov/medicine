//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace лр5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pharmacy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pharmacy()
        {
            this.Pharmacy_has_medicine = new HashSet<Pharmacy_has_medicine>();
        }
        [Required]
        [Display(Name = "Номер аптеки")]
        public int idPharmacy { get; set; }
        [Required]
        [Display(Name = "Название аптеки")]
        public string namePharmacy { get; set; }
        [Required]
        [Display(Name = "Адрес аптеки")]
        public string addresPharmacy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pharmacy_has_medicine> Pharmacy_has_medicine { get; set; }
    }
}
