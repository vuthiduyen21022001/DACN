using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    [Serializable]
    public class Tour
    {
        public Tour()
        {
            CTDonTours = new HashSet<CTDonTour>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên tour")]
        public string TenTour { get; set; }

        [Display(Name = "URL")]
        public string url { get; set; }

        [Display(Name = "Giá Bán")]
        public float Giaban { get; set; }

        [Display(Name = "Giá chưa khuyến mãi")]
        public float GiaChuaKM { get; set; }

        [Display(Name = "Giảm giá")]
        public float GiamGia { get; set; }

        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; }

        [Display(Name = "Lịch trình")]
        public string LichTrinh { get; set; }

        [Display(Name = "Lịch Khởi hành")]
        public string LichKhoiHanh { get; set; }

        [Display(Name = "Gia bao Gồm")]
        public string GiaBaoGom { get; set; }

        [Display(Name = "Giá Không Bao Gồm")]
        public string GiaKBaoGom { get; set; }

        [Display(Name = "Phụ Thu")]
        public string PhuThu { get; set; }

        [Display(Name = "Hoàn/ hủy")]
        public string HoanHuy { get; set; }

        [Display(Name = "Lưu Ý")]
        public string LuuY { get; set; }


        [Display(Name = "Ảnh đại diện")]
        public string HinhAnhTour { get; set; }

        [Display(Name = "Ảnh 1")]
        public string HinhAnhTour1 { get; set; }

        [Display(Name = "Ảnh 2")]
        public string HinhAnhTour2 { get; set; }

        [Display(Name = "Ảnh 3")]
        public string HinhAnhTour3 { get; set; }


        [ForeignKey("DanhMuc")]
        public int DMuc { get; set; }
        public DanhMuc DanhMuc { get; set; }

        //public ICollection<DatTour> DatTours { get; set; }
        public virtual ICollection<CTDonTour> CTDonTours { get; set; }
    }
}