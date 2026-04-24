using System.Text.Json;
using TaskApp.Models;

namespace TaskApp.Services;

public class FileService
{
    private const string FilePath = "tasks.json";

    public List<TaskItem> Load()
    {
        if (!File.Exists(FilePath))
            return new List<TaskItem>();

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void Save(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FilePath, json);
    }
}