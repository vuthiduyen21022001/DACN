
using BotDetect.Web.Mvc;
using System.Linq;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private ApplicationDbContext db = new ApplicationDbContext();
        // ĐĂNG KÝ
        public ActionResult Dangky()
        {
            return View();
        }

        // ĐĂNG KÝ PHƯƠNG THỨC POST
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult Dangky(Nguoidung nguoidung)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Status = "Error";
            }
            else
            {
                ViewBag.Status = "Success";
                MvcCaptcha.ResetCaptcha("registerCapcha");
            }
            try
            {
                var encryptedMd5Pas = Encryptor.MD5Hash(nguoidung.Matkhau);
                nguoidung.Matkhau = encryptedMd5Pas;
                // Thêm người dùng  mới
                db.Nguoidungs.Add(nguoidung);
                // Lưu lại vào cơ sở dữ liệu
                db.SaveChanges();
                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Dangnhap");
                }
                return View("Dangky");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dangnhap()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var passkey = Encryptor.MD5Hash(password).ToString();
            var islogin = db.Nguoidungs.SingleOrDefault(x => x.Email.Equals(userMail) && x.Matkhau.Equals(passkey));

            if (islogin != null)
            {
                if (userMail == "admin@gmail.com")
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Admin/PhanQuyens");
                }
                else
                {
                    Session["use"] = islogin;

                    Session["Hoten"] = islogin.Hoten;
                    Session["id"] = islogin.MaNguoiDung;
                    return RedirectToAction("Index", "tour");
                }
            }
            else
            {
                ViewBag.Fail = "Đăng nhập thất bại";
                return View("Dangnhap");
            }

        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "Home");

        }

    }
}