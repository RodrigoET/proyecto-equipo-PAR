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
        Console.WriteLine("1. Salir");

        Console.Write("Opción: ");
        var option = Console.ReadLine();

        Console.Clear();

        switch (option)
        {
            case "1":
                return;

            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" Error: {ex.Message}");
    }
}
