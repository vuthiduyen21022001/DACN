using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class Nguoidung
    {
 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguoidung()
        {
            DonTours = new HashSet<DonTour>();
        }

        [Key]
        [Display(Name = "Mã")]
        public int MaNguoiDung { get; set; }

        [Display(Name = "Họ tên")]
        [StringLength(50)]
        public string Hoten { get; set; }


        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(10)]
        public string Dienthoai { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string Matkhau { get; set; }

        [Display(Name = "ID quyền")]
        public int? IDQuyen { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string Diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonTour> DonTours { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }

}