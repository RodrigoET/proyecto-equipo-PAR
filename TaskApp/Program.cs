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
