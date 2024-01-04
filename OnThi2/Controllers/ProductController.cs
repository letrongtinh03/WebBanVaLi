using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnThi2.Models;
namespace OnThi2.Controllers
{
    public class ProductController : Controller
    {
        WebBanVaLiEntities db = new WebBanVaLiEntities();
        // GET: Product
        public ActionResult Index()
        {
            List<tDanhMucSP> lstProducts = db.tDanhMucSPs.ToList();
            return View(lstProducts);
        }
        public PartialViewResult CategoryPartial()
        {
            return PartialView(db.tLoaiSPs.ToList());
        }
        public ViewResult ProductByCategory(string MaLoai = "vali")
        {
            List<tDanhMucSP> lstProducts = db.tDanhMucSPs.Where(n => n.MaLoai == MaLoai).OrderBy(n => n.MaLoai).ToList();
            if (lstProducts.Count == 0)
            {
                ViewBag.Products = "Khong co san pham nay";
                ViewBag.lstProducts = db.tDanhMucSPs.ToList();
            }
            return View(lstProducts);
        }
        public PartialViewResult CountryPartial()
        {
            return PartialView(db.tQuocGias.ToList());
        }
        public ViewResult ProductsByCountry(string MaNuocSX = "dc")
        {
            List<tDanhMucSP> lstProducts = db.tDanhMucSPs.Where(n => n.MaNuocSX == MaNuocSX).OrderBy(n =>
            n.MaNuocSX).ToList();
            if (lstProducts.Count == 0)
            {
                ViewBag.Products = "Khong co san pham nay";
                ViewBag.lstProducts = db.tDanhMucSPs.ToList();
            }
            return View(lstProducts);
        }
        public ViewResult ProductDetail(string MaSP)
        {
            tDanhMucSP product = db.tDanhMucSPs.SingleOrDefault(n => n.MaSP == MaSP);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");

            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");

            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");

            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");

            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(tDanhMucSP product)
        {
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");

            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");

            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");

            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");

            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");
            if (ModelState.IsValid)
            {
                db.tDanhMucSPs.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult SuaSanPham(string MaSP)
        {
            if (MaSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            tDanhMucSP sanpham = db.tDanhMucSPs.Find(MaSP);

            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");

            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");

            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");

            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");

            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");

            return View(sanpham);
        }
        [HttpPost]
        public ActionResult SuaSanPham(tDanhMucSP sanpham)
        {

            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");

            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");

            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");

            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");

            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham);
        }

        [HttpGet]
        public ActionResult XoaSanPham(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult Xacnhanxoa(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault(n => n.MaSP == MaSP);
            var anhsp = from p in db.tAnhSPs
                        where p.MaSP == sanpham.MaSP
                        select p;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tAnhSPs.RemoveRange(anhsp);
            db.tDanhMucSPs.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SearchResults(FormCollection f, int? page)
        {
            string searchkey = f["txtsearch"].ToString();
            List<tDanhMucSP> lstSearchResults = db.tDanhMucSPs.Where
                (n => n.TenSP.Contains(searchkey)).ToList();
            int pagesize = 12; // so sp tren 1 trang 
            int pagenumber = (page ?? 1); //sotrang
            ViewBag.keyword = searchkey;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = " Không có sản phẩm này";
                return View(db.tDanhMucSPs.ToList());
            }
            ViewBag.ThongBao = " Đã tìm thấy" + lstSearchResults.Count + "sản phẩm";
            return View(lstSearchResults.OrderBy(n => n.TenSP).ToList());
        }
        [HttpGet]
        public ActionResult SearchResults(int? page, string searchkey)
        {
            ViewBag.keyword = searchkey;
            List<tDanhMucSP> lstSearchResults = db.tDanhMucSPs.Where
                (n => n.TenSP.Contains(searchkey)).ToList();
            int pagesize = 12; // so sp tren 1 trang 
            int pagenumber = (page ?? 1); //sotrang
            ViewBag.keyword = searchkey;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = " Khong co san pham nay";
                return View(db.tDanhMucSPs.ToList());
            }
            ViewBag.ThongBao = " da tim thay" + lstSearchResults.Count + "san pham";
            return View(lstSearchResults.OrderBy(n => n.TenSP).ToList());
        }
    }
}