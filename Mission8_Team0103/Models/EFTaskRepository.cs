﻿using System.Collections.Generic;
using System.Linq;
using Mission8_Team0103.Models;

namespace Mission8_Team0103.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> Tasks => _context.Tasks.ToList();
        public IEnumerable<Category> Categories => _context.Categories.ToList();

        // ✅ FIXED: Ensures method handles possible null values properly
        public Task? GetTaskById(int taskId) => _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);

        public Category? GetCategoryById(int categoryId) => _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}