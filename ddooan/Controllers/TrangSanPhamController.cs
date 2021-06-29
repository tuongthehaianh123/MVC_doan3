using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddooan.Models;

namespace ddooan.Controllers
{
    public class TrangSanPhamController : Controller
    {
        // GET: TrangSanPham
        public ActionResult Index()

        {
            QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
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
        public ActionResult actionResult()
        {
            return View();
        }
    }
}