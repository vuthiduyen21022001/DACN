using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    [Serializable]
    public class DonTour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonTour()
        {
            CTDonTours = new HashSet<CTDonTour>();
        }

        [Key]
        public int Madon { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime? Ngaydat { get; set; }

        [Display(Name = "Tình trạng")]
        public int? Tinhtrang { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? MaNguoidung { get; set; }
        public virtual ICollection<CTDonTour> CTDonTours { get; set; }
        public virtual Nguoidung Nguoidung { get; set; }

        public string CustomerId { set; get; }
        public ApplicationUser Customer { set; get; }


    }
}