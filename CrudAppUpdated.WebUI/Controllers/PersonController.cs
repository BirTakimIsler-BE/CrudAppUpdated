using CrudAppUpdated.WebUI.Context;
using CrudAppUpdated.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAppUpdated.WebUI.Controllers
{

    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PersonController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Person> objList = _db.Person;
            return View(objList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person obj)
        {
            /// Doğrulama içeride yapılsın isteniyorsa bu kullanılır.

            //if (ModelState.IsValid)
            //{
            //    _db.Category.Add(obj);
            //    _db.SaveChanges();

            //    return RedirectToAction("Index");
            //}

            //return View(obj);

            obj.LastEditTime = DateTime.Now;
            _db.Person.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _db.Person.Find(id);

            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person obj)
        {
            obj.LastEditTime = DateTime.Now;

            _db.Person.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _db.Person.Find(id);

            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Person obj)
        {
            _db.Person.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
