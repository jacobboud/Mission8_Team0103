// ITaskRepository.cs (Mission8_Team0103/Models/ITaskRepository.cs) 
using System.Collections.Generic;
using Mission8_Team0103.Models;

namespace Mission8_Team0103.Models
{
    public interface ITaskRepository
    {
        IEnumerable<Task> Tasks { get; }
        IEnumerable<Category> Categories { get; }

        Task? GetTaskById(int taskId);  // ✅ Allow nullable Task
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);

        Category? GetCategoryById(int categoryId);  // ✅ Allow nullable Category
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

        void SaveChanges();
    }
}