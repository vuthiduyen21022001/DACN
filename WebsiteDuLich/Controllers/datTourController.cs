using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;
using WebsiteDuLich.Others;

namespace WebsiteDuLich.Controllers
{
    [Serializable]
    public class datTourController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GioHang

        //Lấy giỏ hàng 
        public List<DatTour> Laytour()
        {
            List<DatTour> lstDattour = Session["Laytour"] as List<DatTour>;
            if (lstDattour == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstDattour = new List<DatTour>();
                Session["Laytour"] = lstDattour;
            }
            return lstDattour;
        }
        //Thêm giỏ hàng
        public ActionResult ThemDatTour(int id, string strURL)
        {
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            Tour t = db.Tours.SingleOrDefault(n => n.Id== id);
            if (t == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<DatTour> lstDattour = Laytour();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
            lstDattour.Clear();
            DatTour dt = lstDattour.Find(n => n.iMaTour == id);
            if (dt == null)
            {
                dt = new DatTour(id);
                //Add sản phẩm mới thêm vào list
                lstDattour.Add(dt);
                return View(lstDattour);
                //return Redirect(strURL);
            }
            else
            {
                return View(lstDattour);
                //return Redirect(strURL);
            }
        }

       //// Xóa giỏ hàng
       // public ActionResult XoaGioHang(int iMaSP)
       // {
       //     //Kiểm tra masp
       //     Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masp == iMaSP);
       //     //Nếu get sai masp thì sẽ trả về trang lỗi 404
       //     if (sp == null)
       //     {
       //         Response.StatusCode = 404;
       //         return null;
       //     }
       //     //Lấy giỏ hàng ra từ session
       //     List<GioHang> lstGioHang = LayGioHang();
       //     GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
       //     //Nếu mà tồn tại thì chúng ta cho sửa số lượng
       //     if (sanpham != null)
       //     {
       //         lstGioHang.RemoveAll(n => n.iMasp == iMaSP);

       //     }
       //     if (lstGioHang.Count == 0)
       //     {
       //         return RedirectToAction("Index", "Home");
       //     }
       //     return RedirectToAction("GioHang");
       // }
        //Xây dựng trang giỏ hàng
        public ActionResult luutour()
        {
            if (Session["Laytour"] == null)
            {
                return RedirectToAction("Index", "tour");
            }
            List<DatTour> lstDattour = Laytour();
            return View(lstDattour);
        }
   
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult Suatour()
        {
            if (Session["Laytour"] == null)
            {
                return RedirectToAction("Index", "tour");
            }
            List<DatTour> lstDattour = Laytour();
            return View(lstDattour);

        }
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatTour()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["Laytour"] == null)
            {
                RedirectToAction("Index", "donTour");
            }
            //Thêm đơn hàng
            DonTour ddt = new DonTour();
            Nguoidung kh = (Nguoidung)Session["use"];
            List<DatTour> dt = Laytour();
            ddt.MaNguoidung = kh.MaNguoiDung;
            ddt.Ngaydat = DateTime.Now;
            Console.WriteLine(ddt);
            db.DonTours.Add(ddt);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in dt)
            {
                CTDonTour ctdt = new CTDonTour();
                float thanhtien = item.dGiaChuaKM - item.dGiamGia;
                ctdt.Madon = ddt.Madon;
                ctdt.Masp = item.iMaTour;
                
                ctdt.Dongia = (decimal)item.Giaban;
                ctdt.Thanhtien = (decimal)thanhtien;
                db.CTDonTours.Add(ctdt);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "donTour");
        }

        public ActionResult DatHangMomo()
        {
            //Them Don hang
            DonTour ddt = new DonTour();
            Nguoidung kh = (Nguoidung)Session["use"];
            List<DatTour> dt = Laytour();
            ddt.MaNguoidung = kh.MaNguoiDung;
            ddt.Ngaydat = DateTime.Now;
            ddt.Ngaydat = DateTime.Today.AddDays(7);
            //ddt.Tinhtrang= false;
            //ddt.DaThanhToan = true;
            db.DonTours.Add(ddt);
            db.SaveChanges();
            //Them chi tiet don hang            
            foreach (var item in dt)
            {
                CTDonTour CTDT = new CTDonTour();
                CTDT.Madon = ddt.Madon;
                CTDT.Masp = item.iMaTour;
                CTDT.Dongia = (decimal)item.Giaban;
                db.CTDonTours.Add(CTDT);
            }
            db.SaveChanges();
           
            return RedirectToAction("KHThanhToan", "DatTour");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            
            List<DatTour> lstDattour = Session["Laytour"] as List<DatTour>;
            List<Nguoidung> kh = Session["KhachHang"] as List<Nguoidung>;
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOXXSI20211204";
            string accessKey = "oDAnrwHUydIhXH6s";
            string serectkey = "3QoGR8qP1JKOuykvOnkvulHTPKJFcCZm";
            string orderInfo = (string)Session["Hoten"];
            string returnUrl = "https://localhost:44355/datTour/KHThanhToan";
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Home/SavePayment -> https://localhost:44355 "; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = lstDattour.Sum(n=>n.ThanhTien).ToString();
            string orderid = "DH" + DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MomoSecurity crypto = new MomoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }
        public ActionResult KHThanhToan()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

        [HttpPost]
        public void SavePayment()
        {

        }

        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}
