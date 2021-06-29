using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddooan.Models;
using PagedList;

namespace ddooan.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
        //tim kiếm tên sản phẩm
        [HttpGet]
        public ActionResult KQTimKiem( string sTuKhoa, int? page)
        {
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var lstSP = db.SanPham.Where(n => n.TenSP.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View( lstSP.OrderBy(n=>n.TenSP).ToPagedList(pageNumber,pageSize));
        }
        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string sTuKhoa)
        {
            //gọi hàm v ề tìm kiếm 

            return RedirectToAction("KQTimKiem",new {@sTuKhoa=sTuKhoa });
        }
    }
}