public class AgendaManager
{
    private List<Person> _personList;

    public AgendaManager()
    {
        _personList = new List<Person>();
    }

    public void AddPerson()
    {
        Console.WriteLine("Ingrese el nombre:");
        string firstName = Console.ReadLine().Trim();

        Console.WriteLine("Ingrese el apellido:");
        string surname = Console.ReadLine().Trim();

        Console.WriteLine("Ingrese la ubicación:");
        string location = Console.ReadLine().Trim();

        Console.WriteLine("Ingrese el número de teléfono:");
        string phoneNumber = Console.ReadLine().Trim();

        Console.WriteLine("Ingrese el correo electrónico:");
        string contactEmail = Console.ReadLine().Trim();

        int yearsOld;
        do
        {
            Console.WriteLine("Ingrese la edad:");
        } while (!int.TryParse(Console.ReadLine(), out yearsOld) || yearsOld < 0);

        Console.WriteLine("¿Es amigo cercano? (1. Sí, 2. No)");
        bool isCloseFriend = Console.ReadLine().Trim() == "1";

        int identifier = _personList.Count > 0 ? _personList.Max(c => c.Identifier) + 1 : 1;

        var person = new Person(identifier, firstName, surname, location, phoneNumber, contactEmail, yearsOld, isCloseFriend);
        _personList.Add(person);

        Console.WriteLine("Persona añadida exitosamente.");
    }

    public void DisplayPeople()
    {
        if (_personList.Count == 0)
        {
            Console.WriteLine("No hay personas registradas.");
            return;
        }

        Console.WriteLine($"{"Nombre",-15}{"Apellido",-15}{"Ubicación",-20}{"Teléfono",-15}{"Correo",-25}{"Edad",-10}{"Amigo Cercano?",-15}");
        Console.WriteLine(new string('-', 115));

        foreach (var person in _personList)
        {
            string friendStatus = person.IsCloseFriend ? "Sí" : "No";
            Console.WriteLine($"{person.FirstName,-15}{person.Surname,-15}{person.Location,-20}{person.PhoneNumber,-15}{person.ContactEmail,-25}{person.YearsOld,-10}{friendStatus,-15}");
        }
    }

    public void FindPerson()
    {
        Console.WriteLine("Seleccione el criterio de búsqueda:");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. Apellido");
        Console.WriteLine("3. Teléfono");
        Console.WriteLine("4. Correo");

        if (!int.TryParse(Console.ReadLine(), out int searchChoice))
        {
            Console.WriteLine("Opción no válida");
            return;
        }

        Console.WriteLine("Ingrese el término de búsqueda:");
        string searchInput = Console.ReadLine().Trim().ToLower();
        IEnumerable<Person> results = new List<Person>();

        switch (searchChoice)
        {
            case 1:
                results = _personList.Where(c => c.FirstName.ToLower().Contains(searchInput));
                break;
            case 2:
                results = _personList.Where(c => c.Surname.ToLower().Contains(searchInput));
                break;
            case 3:
                results = _personList.Where(c => c.PhoneNumber.Contains(searchInput));
                break;
            case 4:
                results = _personList.Where(c => c.ContactEmail.ToLower().Contains(searchInput));
                break;
            default:
                Console.WriteLine("Opción no válida");
                return;
        }

        var foundPeople = results.ToList();
        if (foundPeople.Count == 0)
        {
            Console.WriteLine("No se encontraron coincidencias.");
            return;
        }

        Console.WriteLine($"\nPersonas encontradas ({foundPeople.Count}):");
        foreach (var person in foundPeople)
        {
            Console.WriteLine($"ID: {person.Identifier}, Nombre: {person.FirstName} {person.Surname}, Teléfono: {person.PhoneNumber}");
        }
    }

    public void UpdatePerson()
    {
        if (_personList.Count == 0)
        {
            Console.WriteLine("No hay personas para actualizar.");
            return;
        }

        Console.WriteLine("Lista de personas:");
        foreach (var Person in _personList)
        {
            Console.WriteLine($"ID: {Person.Identifier}, Nombre: {Person.FirstName} {Person.Surname}");
        }

        Console.WriteLine("\nIngrese el ID de la persona a actualizar:");
        if (!int.TryParse(Console.ReadLine(), out int personId))
        {
            Console.WriteLine("ID no válido.");
            return;
        }

        var person = _personList.FirstOrDefault(c => c.Identifier == personId);
        if (person == null)
        {
            Console.WriteLine("Persona no encontrada.");
            return;
        }

        Console.WriteLine("¿Qué desea modificar?");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. Apellido");
        Console.WriteLine("3. Ubicación");
        Console.WriteLine("4. Teléfono");
        Console.WriteLine("5. Correo");
        Console.WriteLine("6. Edad");
        Console.WriteLine("7. Estado de amistad cercana");

        if (!int.TryParse(Console.ReadLine(), out int updateChoice))
        {
            Console.WriteLine("Opción no válida");
            return;
        }

        switch (updateChoice)
        {
            case 1:
                Console.WriteLine("Nuevo nombre:");
                person.FirstName = Console.ReadLine().Trim();
                break;
            case 2:
                Console.WriteLine("Nuevo apellido:");
                person.Surname = Console.ReadLine().Trim();
                break;
            case 3:
                Console.WriteLine("Nueva ubicación:");
                person.Location = Console.ReadLine().Trim();
                break;
            case 4:
                Console.WriteLine("Nuevo teléfono:");
                person.PhoneNumber = Console.ReadLine().Trim();
                break;
            case 5:
                Console.WriteLine("Nuevo correo:");
                person.ContactEmail = Console.ReadLine().Trim();
                break;
            case 6:
                Console.WriteLine("Nueva edad:");
                if (int.TryParse(Console.ReadLine(), out int newYearsOld))
                {
                    person.YearsOld = newYearsOld;
                }
                break;
            case 7:
                Console.WriteLine("¿Amigo cercano? (1. Sí, 2. No):");
                person.IsCloseFriend = Console.ReadLine().Trim() == "1";
                break;
            default:
                Console.WriteLine("Opción no válida");
                return;
        }

        Console.WriteLine("Persona actualizada exitosamente.");
    }

    public void RemovePerson()
    {
        if (_personList.Count == 0)
        {
            Console.WriteLine("No hay personas para eliminar.");
            return;
        }

        Console.WriteLine("Lista de personas:");
        foreach (var Person in _personList)
        {
            Console.WriteLine($"ID: {Person.Identifier}, Nombre: {Person.FirstName} {Person.Surname}");
        }

        Console.WriteLine("\nIngrese el ID de la persona a eliminar:");
        if (!int.TryParse(Console.ReadLine(), out int personId))
        {
            Console.WriteLine("ID no válido.");
            return;
        }

        var person = _personList.FirstOrDefault(c => c.Identifier == personId);
        if (person == null)
        {
            Console.WriteLine("Persona no encontrada.");
            return;
        }

        Console.WriteLine($"¿Está seguro de eliminar a {person.FirstName} {person.Surname}? (S/N)");
        if (Console.ReadLine().Trim().ToUpper() != "S")
        {
            Console.WriteLine("Operación cancelada.");
            return;
        }

        _personList.Remove(person);
        Console.WriteLine("Persona eliminada exitosamente.");
    }
}
