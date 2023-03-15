using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class GioiThieu
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDunggt { get; set; }

    }
}