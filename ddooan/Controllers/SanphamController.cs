using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ddooan.Models;
using PagedList;

namespace ddooan.Controllers
{
    public class SanphamController : Controller
    {
        
        
        QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
        // GET: Sanpham
        //tạo 2 partial view sp1 và sp2  để hiện thị theo 2 style khác nhau
        [ChildActionOnly]
        public ActionResult SanPhamStylelPartial()
        {
                
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult SanPhamStylelPartial1()
        {
            
            return PartialView();
        }
        //public ActionResult SanPhamStylelPartial1(int? MaLoaiSP, int? MaNSX, int? page)
        //{

        //    if (MaLoaiSP == null || MaNSX == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var lstSP = db.SanPham.Where(n => n.MaLoaiSP == MaLoaiSP && n.MaNSX == MaNSX);
        //    if (lstSP.Count() == 0)
        //    {
        //        return HttpNotFound();
        //    }
        //    //thực hiện chức năng  phân trang 
        //    //tạo biến  ssoo sp  trên trang 
        //    int PageSize = 6;
        //    //tạo  biến t2:  số trang hiện tại
        //    int PageNumber = (page ?? 1);
        //    ViewBag.MaLoaiSP = MaLoaiSP;
        //    ViewBag.MaNSX = MaNSX;
        //    return PartialView(lstSP.OrderBy(n => n.MaSP).ToPagedList(PageNumber,PageSize));
        //}


        //xây dựng trang chi tiết
        public ActionResult  xemchitiet(int id)
        {
            //kiểm tra tham số truyền có rỗng hay không
            var sp = db.SanPham.Find(id);
            return View(sp);
        }
        
    }
    }
    
