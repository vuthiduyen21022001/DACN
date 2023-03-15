using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class headerBanner
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Tên banner")]
        public string Namebanner { get; set; }

        [Display(Name = "Banner")]
        public string Imgbanner { get; set; }
    }
}