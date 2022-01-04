using Demo_Bandirma.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Bandirma.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            c.Categories.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var values = c.Categories.Find(id);
            c.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var values = c.Categories.Find(id);
            return View("EditCategory", values);
        }
        [HttpPost]
        public IActionResult EditCategory(Category p)
        {
            c.Update(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
