//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace leasingAgency.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AutoTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AutoTable()
        {
            this.UserTable = new HashSet<UserTable>();
        }
    
        public int IdAuto { get; set; }
        public string BrandAuto { get; set; }
        public string ModelAuto { get; set; }
        public string BodyType { get; set; }
        public int Release { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int DurationPayment { get; set; }
        public int MonthPayment { get; set; }
        public string ImgAuto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTable> UserTable { get; set; }
    }
}
