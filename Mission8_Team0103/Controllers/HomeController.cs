using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0103.Models;
using Task = Mission8_Team0103.Models.Task;

namespace Mission8_Team0103.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks; // Uses repository to get tasks

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Tasks()
        {
            ViewBag.Categories = _repo.Categories;

            return View(new Task());
        }

        [HttpPost]
        public IActionResult Tasks(Task response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);  // Uses repository to add task
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _repo.Categories;
                return View(response);
            }
        }

        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks.FirstOrDefault(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories;

            return View("Tasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedInfo)
        {
            _repo.UpdateTask(updatedInfo); // Uses repository to update task

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks.FirstOrDefault(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Task deletedInfo)
        {
            _repo.DeleteTask(deletedInfo); // Uses repository to delete task

            return RedirectToAction("Quadrants");
        }
    }

}
