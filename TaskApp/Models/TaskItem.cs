namespace TaskApp.Models;

public class TaskItem
{
    public string Title { get; set; }
    public string Category { get; set; } = "";
    public string Priority { get; set; } = "Baja";// Alta, Media, Baja
    public bool IsCompleted { get; set; } = false;
}