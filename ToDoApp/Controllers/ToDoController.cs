using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{

    public class ToDoController : Controller
    {
        private readonly DatabaseContext _db;

        public ToDoController(DatabaseContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ToDoModel toDoModel )
        {
            if (ModelState.IsValid)
            {
                _db.toDoApps.Add(toDoModel);
                _db.SaveChanges();
                TempData["success"] = "You have sucessfully added task";
                return RedirectToAction("Index");
            }
            return View(toDoModel);
        }

        public IActionResult ShowList()
        {
            var data = (from t in _db.toDoApps
                        orderby t.Date
                        select t).ToList();

            return View(data);
        }

       
        public IActionResult Delete(int? id)
        {
            var data = _db.toDoApps.Find(id);
            Console.WriteLine(data);
            _db.toDoApps.Remove(data);
          
            _db.SaveChanges();
            TempData["success"] = "You have sucessfully deleted task";
            return RedirectToAction("ShowList");
        }

        //get view
        public IActionResult Edit(int id)
        {
            var data = _db.toDoApps.Find(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ToDoModel toDo)
        {
            if(id != toDo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.toDoApps.Update(toDo);
                    _db.SaveChanges();
                    TempData["success"] = "You have sucessfully updated task";
                    return RedirectToAction("ShowList");
                }
                catch
                {
                    return NotFound();  
                }
            }
            return View(toDo);
        }


    }
}

