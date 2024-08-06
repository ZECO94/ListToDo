using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TodoItemsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Items(int id)
        {
            ViewData["message"] = TempData["message"];
            var result1 = context.users.Where(x=>x.Id == id);
            ViewBag.user = result1;
            var result = context.list.ToList();
            return View(result);
        }
        public IActionResult CreateNew()
        {
            return View();

        }
        public IActionResult Add(TheList theList)
        {
            context.list.Add(theList);
            context.SaveChanges();
            ITempDataProvider x;
            TempData["message"]= "Created Successfully!";
            
            return RedirectToAction("Items");
        }
        public IActionResult Edit(int id)
        {
            var result1 = context.list.Find(id);
            return result1 != null ? View(result1) : View("NotFound");
        }
        public IActionResult SaveEdit(TheList list)
        {
            context.list.Update(list);
            context.SaveChanges();
            return RedirectToAction("Items");
        }
        public ActionResult Delete(int id)
        {
            var result2 = context.list.Find(id);
            if (result2 != null)
            {
                context.list.Remove(result2);
                context.SaveChanges();
                return RedirectToAction("Items");
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }
    }
}
