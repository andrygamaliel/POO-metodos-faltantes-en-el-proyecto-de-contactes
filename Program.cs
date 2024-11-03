Console.WriteLine("Bienvenido a la Agenda Personal");
var agendaManager = new AgendaManager();
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine(@"1. Añadir Persona     2. Ver Personas    3. Buscar Persona     4. Modificar Persona    5. Eliminar Persona    6. Salir");
    Console.WriteLine("Ingrese el número de la opción deseada");

    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Por favor, ingrese un número válido");
        continue;
    }

    switch (option)
    {
        case 1:
            agendaManager.AddPerson();
            break;
        case 2:
            agendaManager.DisplayPeople();
            break;
        case 3:
            agendaManager.FindPerson();
            break;
        case 4:
            agendaManager.UpdatePerson();
            break;
        case 5:
            agendaManager.RemovePerson();
            break;
        case 6:
            Console.WriteLine("Saliendo de la Agenda Personal");
            isRunning = false;
            break;
        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }
}
