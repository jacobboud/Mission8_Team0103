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

        // Display Quadrants with Tasks (Only Uncompleted)
        public IActionResult Index()
        {
            var tasks = _repo.Tasks.Where(t => !t.Completed).ToList();
            return View(tasks);
        }

        // GET: Display Add Task Form
        [HttpGet]
        public IActionResult Tasks()
        {
            ViewBag.Categories = _repo.Categories;
            return View(new Task
            {
                TaskName = string.Empty,
                Quadrant = 1,
                CategoryId = 1
            });
        }

        // POST: Add New Task to Database
        [HttpPost]
        public IActionResult Tasks(Task response)
        {
            if (ModelState.IsValid)
            {
                if (response.TaskId == 0)
                {
                    // Add new task
                    _repo.AddTask(response);
                }
                else
                {
                    // Redirect to Edit action if editing an existing task
                    return RedirectToAction("Edit", new { id = response.TaskId });
                }

                _repo.SaveChanges(); // Save changes
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _repo.Categories;
                return View(response);
            }
        }

        // POST: Mark Task as Completed
        [HttpPost]
        public IActionResult UpdateCompletion(int TaskId, bool Completed)
        {
            var task = _repo.GetTaskById(TaskId);
            if (task != null)
            {
                task.Completed = Completed;
                _repo.UpdateTask(task);
                _repo.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Edit Task Form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.GetTaskById(id);
            if (recordToEdit == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _repo.Categories;
            return View("Tasks", recordToEdit);
        }

        // POST: Update Task in Database
        [HttpPost]
        public IActionResult Edit(Task updatedInfo)
        {
            if (ModelState.IsValid)
            {
                var existingTask = _repo.GetTaskById(updatedInfo.TaskId);
                if (existingTask != null)
                {
                    // Update the existing task instead of creating a duplicate
                    existingTask.TaskName = updatedInfo.TaskName;
                    existingTask.DueDate = updatedInfo.DueDate;
                    existingTask.Quadrant = updatedInfo.Quadrant;
                    existingTask.CategoryId = updatedInfo.CategoryId;
                    existingTask.Completed = updatedInfo.Completed;

                    _repo.UpdateTask(existingTask);
                    _repo.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Confirm Task Deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.GetTaskById(id);
            if (recordToDelete == null)
            {
                return NotFound();
            }
            return View(recordToDelete);
        }

        // POST: Delete Task from Database (Renamed to ConfirmDelete ✅)
        [HttpPost]
        public IActionResult ConfirmDelete(int id) // ✅ Renamed method to avoid conflict
        {
            var recordToDelete = _repo.GetTaskById(id);
            if (recordToDelete != null)
            {
                _repo.DeleteTask(recordToDelete);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
