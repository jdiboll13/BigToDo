using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BigToDo.Models;
using BigToDo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BigToDo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
            _context = context;
            _userManager = um;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.ToDo.Include(p => p.ApplicationUser).Where(x => x.UserId == user.Id);

            return View(applicationDbContext.ToList());

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
        [HttpPost]
        public async Task<IActionResult> Create(string newToDo)
        {
            var todo = new BigToDoModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            todo.UserId = user.Id;
            todo.TaskName = newToDo;
            _context.Add(todo);
            await _context.SaveChangesAsync();
            var applicationDbContext = _context.ToDo.Include(p => p.ApplicationUser).Where(x => x.UserId == user.Id);
            return View("Index", await applicationDbContext.ToListAsync());
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
