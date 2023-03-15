using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class PhanQuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanQuyen()
        {
            Nguoidung = new HashSet<Nguoidung>();
        }

        [Key]
        public int IDQuyen { get; set; }

        [Display(Name = "Tên quyền")]
        [StringLength(20)]
        public string TenQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nguoidung> Nguoidung { get; set; }
    }
}