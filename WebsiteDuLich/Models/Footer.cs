using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class Footer
    {
        [Key]
        public string Id { get; set; }

        public string Logo { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

    }
}