namespace Mission8_Team0103.Models
{
    public interface iTaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
    }

}
