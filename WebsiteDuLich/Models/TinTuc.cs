using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    public class TinTuc
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Ảnh tiêu đề")]
        public string AnhTieuDe { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Người đăng")]
        public string NguoiDang { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime TgDang { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }


    }
}