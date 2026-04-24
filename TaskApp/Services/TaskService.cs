using TaskApp.Models;

namespace TaskApp.Services;

public class TaskService
{
    private List<TaskItem> tasks;

    public TaskService(List<TaskItem> initialTasks)
    {
        tasks = initialTasks ?? new List<TaskItem>();
    }
}