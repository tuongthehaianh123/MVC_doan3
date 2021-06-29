    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddooan.Models;

namespace ddooan.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
        //Lấy Giỏ Hàng 
        public List<ItemGioHang> LayGioHang()
        {
            //giỏ hàng đã tồn tại 
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                //nếu session  giỏ hàng chưa tồn tại thì khởi tạo giỏ hàng 
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;
        
            }
            return lstGioHang;
        }

        //Thêm Giỏ Hàng thông thường(load lại trang )
        public ActionResult ThemGioHang(int MaSP, string strURL)
        {
            //kiểm tra sản phẩm  có tồn tại trong CSDL hay không
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                //trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = LayGioHang();
            //trường hợp t1 nếu sản phẩm  đã tồn tại trong giỏ hàng
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);  //kiểm tra sản phẩm  có tồn tại trong Giỏ Hàng hay không
            if (spCheck != null)
            {
                //kiểm tra  số lượng  tồn trước khi cho khách hàng  mua hàng
                if (sp.SoLuongTon <spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);//redirect truyền vào đường dẫn
            }

            //kiểm tra  số lượng  tồn trước khi cho khách hàng  mua hàng
           
            ItemGioHang itemGH = new ItemGioHang(MaSP);// truyền vào MaSp để truy vấn all
            if (sp.SoLuongTon <= itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            lstGioHang.Add(itemGH);
            return Redirect(strURL);

        }

        //Tính tổng số lượng 
        public double TinhTongSoLuong()
        {
            //Lấy Giỏ Hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.SoLuong);
        }

        //tính tổng tiền
        public decimal TinhTongTien()
        {
            //Lấy Giỏ Hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);
        }


        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong()== 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();

            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }
        public ActionResult GioHangPartial1()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();

            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }

        // GET: GioHang
        public ActionResult XemGioHang()
        {
            List<ItemGioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }



        [HttpGet]
        //  chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang( int MaSP)
        {
            //kiểm tra session  giỏ hàng tồn tại  chưa
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");// return về trang chủ 
            }

            //kiểm tra sản phẩm  có tồn tại trong CSDL hay không
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                //trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            //lấy list giỏ hàng từ session 
            List<ItemGioHang> lstGioHang = LayGioHang();
            //kiểm tra  xem sp  đó có tồn tại trong  giỏ hàng hay k
            ItemGioHang spcheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spcheck == null)
            {
                return RedirectToAction("Index", "Home");// return về trang chủ 
            }
            //lấy list giỏ hàng tạo  giao diện
            ViewBag.GioHang = lstGioHang;

            //nếu tồn tại 
            return View(spcheck);
        }
       //Xử lý cập nhập giỏ hàng
       [HttpPost]
       public ActionResult CapNhapGioHang(ItemGioHang itemGH)
        {
            //kiểm tra số lượng tồn 
            SanPham spCheck = db.SanPham.Single(n => n.MaSP == itemGH.MaSP);
            if (spCheck.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            //cập nhập  số lượng  trong session  giỏ hàng
            //B1: Lấy list<GioHang> từ session["GioHang"]
            List<ItemGioHang> lstGH = LayGioHang();
            //b2: lấy sp cần cập nhập  từ trong  list<GioHang> ra
            ItemGioHang itemGHUpdate = lstGH.Find(n => n.MaSP==itemGH.MaSP);
            //b3:cập nhập lại ssoos lượng cũng như thành tiền
            itemGHUpdate.SoLuong = itemGH.SoLuong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;
            return RedirectToAction("XemGioHang");
        }


        // XOÁ GIỎ HÀNG
        public ActionResult XoaGioHang(int MaSP)
        {
            //kiểm tra session  giỏ hàng tồn tại  chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");// return về trang chủ 
            }

            //kiểm tra sản phẩm  có tồn tại trong CSDL hay không
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                //trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            //lấy list giỏ hàng từ session 
            List<ItemGioHang> lstGioHang = LayGioHang();
            //kiểm tra  xem sp  đó có tồn tại trong  giỏ hàng hay k
            ItemGioHang spcheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spcheck == null)
            {
                return RedirectToAction("Index", "Home");// return về trang chủ 
            }
            //XOÁ ITEM GIỎ HÀNG
            lstGioHang.Remove(spcheck);
            return Redirect("XemGioHang");
        }

        //XÂY DỰNG CHỨC NĂNG ĐẶT HÀNG
        public ActionResult DatHang(KhachHang kh )
        {
            //kiểm tra session giỏ hàng tồn tại hay chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang khang = new KhachHang();
            if (Session["TaiKhoan"] == null)
            {
                //thêm khách hàng vào bảng khách hàng chưa có TK
                khang = kh;
                db.KhachHang.Add(khang);
                db.SaveChanges();

            }
        
            //thêm đơn đặt hàng 
            DonDatHang ddh = new DonDatHang();
            ddh.NgayDat = DateTime.Now;
            ddh.TinhTrangGiap = false;
            ddh.DaThanhToan = false;
            ddh.MaKH = khang.MaKH;
            ddh.UuDai = 0;
            db.DonDatHang.Add(ddh);
            db.SaveChanges();
            //thêm chi tiết đơn đặt hàng
            List<ItemGioHang> lstGH = LayGioHang();
            foreach (var item in lstGH)
            {
                ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
                ctddh.MaDDH = ddh.MaDDH;
                ctddh.MaSP = item.MaSP;
                ctddh.TenSP = item.TenSP;
                ctddh.SoLuong = item.SoLuong;
                ctddh.DonGia = item.DonGia;
                db.ChiTietDonDatHang.Add(ctddh);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XemGioHang");
        }


    }
}





