using Doga.UI.Entity;
using Doga.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Doga.UI.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();



        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products.Where(i => i.IsHome == true && i.IsApproved == true && i.Stock>0).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image ?? "indir.jpg",
                CategoryId = i.CategoryId
            }).ToList();

            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = _context.Products.Where(i =>i.IsApproved == true).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image ?? "indir.jpg",
                CategoryId = i.CategoryId
            }).AsQueryable();

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }
        public PartialViewResult GetCategories()
        {

            return PartialView(_context.Categories.ToList());
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Purpose()
        {
            return View();
        }
        [Authorize]
        public ActionResult Donation()
        {
            
           return View();
           
        }
        
    }
}