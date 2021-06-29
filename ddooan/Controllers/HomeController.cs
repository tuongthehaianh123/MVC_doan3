using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddooan.Models;
using System.IO;

namespace ddooan.Controllers
{
    public class HomeController : Controller
        
    {
        
        QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
        public ActionResult Index()
        {
            //lần lượt lấy các viewBag để lấy list  sp từ cơ sơ  dữ liệu
            //list áo decao mới
            var lstAoMoi = db.SanPham.Where(n => n.MaLoaiSP == 1 && n.Moi == 1 && n.DaXoa == false);
            //gán vào viewbag
            ViewBag.listAomoi = lstAoMoi;

            //list QUẦN decao msới
            var lstQuanMoi = db.SanPham.Where(n => n.MaLoaiSP == 2 && n.Moi == 1 && n.DaXoa == false);
            //gán vào viewbag
            ViewBag.listQuanmoi = lstQuanMoi;

            //list PHỤ KIỆN decao mới
            var lstPhuKienMoi = db.SanPham.Where(n => n.MaLoaiSP == 3 && n.Moi == 0 && n.DaXoa == false);
            //gán vào viewbag
            ViewBag.listPhuKienmoi = lstPhuKienMoi;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MenuPartial()
        {
            var ltssanpham = db.SanPham;
            return PartialView(ltssanpham);
        }

        //[HttpPost]
        //public ActionResult DangNhap()
        //{
        //    //kiểm tra tên đăng nhập và mk 
        //    //string sTaiKhoan = f["txtTenDangNhap"].ToString();
        //    //string sMatKhau = f["txtMatKhau"].ToString();

        //    //ThanhVien tv = db.ThanhVien.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.TaiKhoan == sMatKhau);
        //    //if (tv != null)
        //    //{
        //    //    Session["TaiKhoan"] = tv;
        //    //    return RedirectToAction("Index");
        //    //}

        //    return View();
        //}
        public ActionResult dangnhap()
        {
            return View();
        }
    }
}