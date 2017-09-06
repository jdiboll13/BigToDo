using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BigToDo.Models;
using BigToDo.Data;

namespace BigToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ToDo.ToList());
        }
        [HttpPost]
        public IActionResult Index(string ItemName)
        {
            var CurrentToDo = new BigToDoModel
            {
                TaskName = ItemName
            };

            _context.Add(CurrentToDo);
            _context.SaveChanges();

            return View(_context.ToDo.ToList());
        }
        [HttpPost]
        public IActionResult Complete(int id) 
        {
            var done = _context.ToDo.SingleOrDefault(i => i.ID == id);
            done.IsComplete();
            _context.SaveChanges();

            return Redirect("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
