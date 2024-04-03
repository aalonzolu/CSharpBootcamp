using Microsoft.AspNetCore.Mvc;
using MVCTodo.Models;

namespace MVCTodo.Controllers;



public class TodoController : Controller
{
    private static List<TodoItem> todoItems = new List<TodoItem>();

    public IActionResult Index()
    {
        ViewBag.Title = "Todo List";
        ViewBag.Items = todoItems;
        return View(todoItems);
    }
    
    [HttpPost]
    public ActionResult Create(TodoItem todoItem)
    {
        if (ModelState.IsValid)
        {
            todoItem.ID = todoItems.Count + 1;
            todoItems.Add(todoItem);

            return RedirectToAction("Index");
        }

        // If not valid return Form
        return View("Create", todoItem);
    }
    
    [HttpGet]
    public ActionResult Create()
    {
        return View("Create");
    }

}