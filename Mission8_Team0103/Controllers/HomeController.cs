using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0103.Models;

namespace Mission8_Team0103.Controllers
{
    public class HomeController : Controller
    {
        private iTaskRepository _repo;

        public HomeController(iTaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks; // Uses repository to get tasks

            return View(tasks);
        }

        [HttpPost]
        public IActionResult UpdateTasks(List<Task> updatedTasks)
        {
            foreach (var task in updatedTasks)
            {
                var existingTask = _repo.Tasks.FirstOrDefault(x => x.TaskId == task.TaskId);

                if (existingTask != null)
                {
                    existingTask.IsCompleted = task.IsCompleted;
                    _repo.UpdateTask(existingTask);
                }
            }

            return RedirectToAction("Quadrants");
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
                return View("Quadrants", response);
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
