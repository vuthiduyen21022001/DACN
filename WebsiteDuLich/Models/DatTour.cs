using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteDuLich.Models
{
    [Serializable]
    public class DatTour
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Key]
        public int iMaTour { set; get; }
        //public string CustomerId { set; get; }
        //public ApplicationUser Customer { set; get; }

        [Display(Name = "tên")]
        public string ten { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }

        [Display(Name = "Giá chưa khuyến mãi")]
        public float dGiaChuaKM { get; set; }

        [Display(Name = "Giảm giá")]
        public float dGiamGia { get; set; }

        [Display(Name = "Giá Bán")]
        public float Giaban { get; set; }

        public double ThanhTien
        {
            get { return dGiaChuaKM - dGiamGia; }
        }

        //[ForeignKey("CTDonTour")]
        //public int CTTourID { get; set; }
        //public CTDonTour CTDonTour { get; set; }


        public DatTour(int tourid)
        {
            iMaTour = tourid;
            Tour tour = db.Tours.Single(n => n.Id == iMaTour);
            ten = tour.TenTour;
            hinh = tour.HinhAnhTour;
            dGiaChuaKM = tour.GiaChuaKM;
            dGiamGia = tour.GiamGia;
            Giaban = tour.Giaban;
        }

    }
}