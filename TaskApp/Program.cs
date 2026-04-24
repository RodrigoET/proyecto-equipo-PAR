using TaskApp.Services;

var fileService = new FileService();
var tasks = fileService.Load();

var service = new TaskService(tasks);

void Pause()
{
    Console.WriteLine("\nPresioná una tecla para continuar...");
    Console.ReadKey();
}

while (true)
{
    try
    {
        Console.Clear();
        Console.WriteLine("\n===== MENÚ =====");
        Console.WriteLine("1. Agregar tarea");
        Console.WriteLine("2. Listar tareas");
        Console.WriteLine("3. Filtrar por categoría");
        Console.WriteLine("4. Filtrar por prioridad");
        Console.WriteLine("0. Salir");

        Console.Write("Opción: ");
        var option = Console.ReadLine();

        Console.Clear();

        switch (option)
        {
            case "1":
                Console.WriteLine("\n===== AGREGAR TAREA =====");

                Console.Write("Título: ");
                var title = Console.ReadLine();

                Console.Write("Categoría: ");
                var category = Console.ReadLine();

                Console.Write("Prioridad: ");
                var priority = Console.ReadLine();

                service.AddTask(title, category, priority);
                fileService.Save(service.GetTasks());

                Console.WriteLine("Tarea agregada");
                Pause(); 
                break;

            case "2":
                Console.WriteLine("\n===== LISTAR TAREAS =====");

                var allTasks = service.GetTasks();

                if (!allTasks.Any())
                {
                    Console.WriteLine("No hay tareas");
                }
                else
                {
                    for (int i = 0; i < allTasks.Count; i++)
                    {
                        var t = allTasks[i];
                        Console.WriteLine($"{i}. {t.Title} - {t.Category} - {t.Priority} ({(t.IsCompleted ? "\u221A" : "X")})");
                    }
                }

                Pause();
                break;


            case "3":
                Console.WriteLine("\n===== FILTRAR POR CATEGORÍA =====");

                Console.Write("Categoría: ");
                var categoryFilter = Console.ReadLine();

                var tasksByCategory = service.GetByCategory(categoryFilter);

                if (!tasksByCategory.Any())
                {
                    Console.WriteLine("No hay tareas con esa categoría");
                }
                else
                {
                    foreach (var t in tasksByCategory)
                    {
                        Console.WriteLine($"{t.Title} - {t.Category} - {t.Priority} ({(t.IsCompleted ? "\u221A" : "X")})");
                    }
                }

                Pause();
                break;


            case "4":
                Console.WriteLine("\n===== FILTRAR POR PRIORIDAD =====");

                Console.Write("Prioridad: ");
                var priorityFilter = Console.ReadLine();

                var tasksByPriority = service.GetByPriority(priorityFilter);

                if (!tasksByPriority.Any())
                {
                    Console.WriteLine("No hay tareas con esa prioridad");
                }
                else
                {
                    foreach (var t in tasksByPriority)
                    {
                        Console.WriteLine($"{t.Title} - {t.Category} - {t.Priority} ({(t.IsCompleted ? "\u221A" : "X")})");
                    }
                }

                Pause();
                break;


            case "0":
                return;

            default:
                Console.WriteLine("Opción inválida");
                Pause();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" Error: {ex.Message}");
    }
}
