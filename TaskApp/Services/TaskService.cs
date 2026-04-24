using System.Linq;
using TaskApp.Models;

namespace TaskApp.Services;

public class TaskService
{
    private List<TaskItem> tasks;

    public TaskService(List<TaskItem> initialTasks)
    {
        tasks = initialTasks ?? new List<TaskItem>();
    }

    public void AddTask(string title, string category, string priority)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new Exception("El título no puede estar vacío");

        tasks.Add(new TaskItem
        {
            Title = title,
            Category = category,
            Priority = priority,
            IsCompleted = false
        });
    }
    
    public List<TaskItem> GetTasks()
    {
        return tasks;
    }


    public List<TaskItem> GetByCategory(string category)
    {
        return tasks
            .Where(t => t.Category != null && t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<TaskItem> GetByPriority(string priority)
    {
        return tasks
            .Where(t => t.Priority != null && t.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}