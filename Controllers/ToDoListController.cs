using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
            return View();
        }
        
    }
}
