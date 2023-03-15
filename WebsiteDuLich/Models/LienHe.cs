using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class LienHe
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ và Tên")]
        public string HoTenLH { get; set; }
      
        [Display(Name = "Địa chỉ Mail")]
        public string EmailLH { get; set; }
       
        [Display(Name = "Chủ đề")]
        public string ChuDeLH { get; set; }
       
        [Display(Name = "Nội Dung")]
        public string NoiDungLH { get; set; }
    }
}