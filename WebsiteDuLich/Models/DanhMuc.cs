using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class DanhMuc
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Tên Danh Mục")]
        public string TenDM { get; set; }

        [Display(Name = "URL")]
        public string url { get; set; }






        public ICollection<Tour> Tours { get; set; }
    }
}