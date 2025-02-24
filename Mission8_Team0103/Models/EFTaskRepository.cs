namespace Mission8_Team0103.Models
{
    public class EFTaskRepository : iTaskRepository
    {
        private TasksContext _context;

        public EFTaskRepository(TasksContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.Include(t => t.Category).OrderBy(t => t.TaskName).ToList();
        public List<Category> Categories => _context.Categories.OrderBy(c => c.CategoryName).ToList();

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
    }

}
