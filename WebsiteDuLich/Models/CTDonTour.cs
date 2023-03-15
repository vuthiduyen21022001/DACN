using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    [Serializable]
    public class CTDonTour
    {
     

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã đơn")]
        public int Madon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã sản phẩm")]
        public int Masp { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal? Dongia { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? Thanhtien { get; set; }
        public virtual DonTour DonTour { get; set; }
        public virtual Tour Tour { get; set; }
    }
}