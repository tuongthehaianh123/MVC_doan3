using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddooan.Models;
namespace ddooan.Areas.Admin.Controllers
{
    public class Sanpham1Controller : Controller
    {
        QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
        // GET: Admin/Sanpham
        public ActionResult Index()
        {
            return View(db.SanPham.ToList());   
            
        }
        public ActionResult LoaiSP()
        {
            return View(db.LoaiSanPham.ToList());
        }
        public ActionResult TrangTinTuc()
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult khachhang()
        {
            return View(db.KhachHang.ToList());
        }
        public ActionResult DonDatHang()
        {
            return View(db.DonDatHang.ToList());
        }
        public ActionResult ChiTietDonDatHang()
        {
            return View(db.ChiTietDonDatHang.ToList());
        }

        //public JsonResult create(SanPham sp)
        //{

        //    var rs = db.SanPham.Add(sp);
        //    db.SaveChanges(); 

        //    return Json(rs, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult get(int MaSP)//k dùng hàm này dc
        //{
        //    var rs = db.SanPham.Where(x => x.MaSP == MaSP).Select(x => new
        //    {
        //        x.TenSP,
        //        x.DonGia,
        //        x.NgayCapNhap,
        //        x.CauHinh,
        //        x.MoTa,
        //        x.HinhAnh,
        //        x.SoLuongTon,
        //        x.MaLoaiSP,
        //        x.MaNCC,
        //        x.MaNSX,
        //        x.MaSP,
        //    }).SingleOrDefault();
        //    return Json(new { dt = rs }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult edit(SanPham entity)
        //{
        //    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;//có sai đâu ơ tự dưn hết lỗi @@


        //    //db.Entry(entity).State = System.Data.Entity.en;

        //    db.SaveChanges();
        //    return Json(JsonRequestBehavior.AllowGet);

        //}
        //dùng action
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(SanPham sp)
        {
            db.SanPham.Add(sp);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult delete(int id)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x => x.MaSP == id);
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //public JsonResult details(int MaSP)
        //{
        //    var ds = db.SanPham.Find(MaSP);
        //    return Json(ds, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Edit1()
        {
            return View();
        }


        ////public ActionResult Edit1(int id)
        //{
        //    SanPham sp = db.SanPham.FirstOrDefault(x => x.MaSP == id);
        //    return View(sp);
        //}
        //[HttpPost]
        //public ActionResult Edit1(SanPham sp)
        //{
        //    SanPham spham = db.SanPham.FirstOrDefault(x => x.MaSP == sp.MaSP);
        //    spham.MaSP = sp.MaSP;
        //    spham.TenSP = sp.TenSP;
        //    spham.DonGia = sp.DonGia;
        //    spham.NgayCapNhap = sp.NgayCapNhap;
        //    spham.CauHinh = sp.CauHinh;
        //    spham.MoTa = sp.MoTa;
        //    spham.HinhAnh = sp.HinhAnh;
        //    spham.SoLuongTon = sp.SoLuongTon;
        //    spham.LuotXem = sp.LuotXem;
        //    spham.LuotBinhChon = sp.LuotBinhChon;
        //    spham.SoLanMua = sp.SoLanMua;
        //    spham.Moi = sp.Moi;
        //    spham.MaNSX = sp.MaNSX;
        //    spham.MaLoaiSP = sp.MaLoaiSP;
        //    spham.DaXoa = sp.DaXoa;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}

        public ActionResult moi(int id)
        {
            SanPham sp = db.SanPham.FirstOrDefault(n => n.MaSP == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult moi(SanPham sp)
        {
            SanPham spham = db.SanPham.FirstOrDefault(n => n.MaSP == sp.MaSP);
            spham.MaSP = sp.MaSP;
            spham.TenSP = sp.TenSP;
            spham.DonGia = sp.DonGia;
            spham.NgayCapNhap = sp.NgayCapNhap;
            spham.CauHinh = sp.CauHinh;
            spham.MoTa = sp.MoTa;
            spham.HinhAnh = sp.HinhAnh;
            spham.SoLuongTon = sp.SoLuongTon;
            spham.LuotXem = sp.LuotXem;
            spham.LuotBinhChon = sp.LuotBinhChon;
            spham.SoLanMua = sp.SoLanMua;
            spham.Moi = sp.Moi;
            spham.MaNSX = sp.MaNSX;
            spham.MaLoaiSP = sp.MaLoaiSP;
            spham.DaXoa = sp.DaXoa;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
