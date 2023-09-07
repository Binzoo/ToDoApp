﻿using System;
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
            return View();
        }

        [HttpPost]
        public IActionResult Index(ToDoModel toDoModel )
        {
            if (ModelState.IsValid)
            {
                _db.toDoApps.Add(toDoModel);
                _db.SaveChanges();
                TempData["success"] = "You have sucessfully added task";
            }
            return RedirectToAction("Index");
        }

        public IActionResult ShowList()
        {
            var data = _db.toDoApps.ToList();

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


    }
}
