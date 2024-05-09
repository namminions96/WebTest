using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBTEST.Data;
using WEBTEST.Models;
using AspNetCore.PaginatedList;
namespace WEBTEST.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBStore _dbStore;
        public ProductController(DBStore dbStore)
        {
            _dbStore = dbStore;
        }

        // GET: ProductController
        public ActionResult Index(int? page, string tensp, string masanpham)
        {
            if(tensp == null && masanpham==null)
            {
                var products = _dbStore.Products.ToList();
                var pageNumber = page ?? 1;
                ViewData["PageNumber"] = pageNumber;
                return View(products);
            }
           if(tensp!= null)
            {
                var product = _dbStore.Products.Where(x=>x.Name.Contains(tensp)).ToList();
                return View(product);
            }
            else if (masanpham != null)
            {
                int massp;
                int.TryParse(masanpham, out massp);
                var product = _dbStore.Products.Where(x => x.Id == massp).ToList();
                return View("Index", product);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }

        }

        // GET: ProductController/Details/5
        public ActionResult Details(string tensp , string masanpham)
        {
                return Index(0, tensp, masanpham);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
