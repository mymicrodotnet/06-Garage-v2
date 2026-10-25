Console.ForegroundColor = ConsoleColor.Cyan;
System.Console.WriteLine("\n=== Welcome to GARAGE 1.0 Console App ===");
Console.ResetColor();

int capacity = ReadIntegerInput("Enter garage capacity: ", 1);
Garage garage = new Garage(capacity);
System.Console.WriteLine("");

//*** POPULATING THE GARAGE ***
#region GaragePopulation
List<Vehicle> sampleVehicles = new List<Vehicle>
{
    new Car("ABC111", "Red", 4, Car.FuelType.Gasoline),
    new Car("ABC222", "Black", 4, Car.FuelType.Gasoline),
    new Car("ABC333", "Black", 4, Car.FuelType.Diesel),
    new Motorcycle("MOT111", "Black", 2, 600),
    new Motorcycle("MOT222", "black", 2, 600),
    new Motorcycle("MOT333", "PINk", 3, 600),
    new Motorcycle("MOT444", "Pink", 2, 600),
    new Airplane("AIR111", "White", 6, 2),
    new Airplane("AIR111", "Pink", 3, 2), // Test: duplicate registration
    new Airplane("AIR222", "Pink", 3, 2),
    new Bus("BUS111", "Blue", 6, 50),
    new Bus("BUS222", "Red", 6, 50),
    new Boat("BOA111", "White", 0, 7.5),
    new Boat("BOA222", "red", 0, 7.5)
};

foreach (Vehicle vehicle in sampleVehicles)
{
    // garage.ParkVehicle(sampleVehicles[i]);
    if (!garage.ParkVehicle(vehicle, showMessage: false))
    {
        if (garage.ListVehicles().Count >= capacity)
        {
            break;
        }
    }
}
#endregion

// ***** MENU ******
#region Menu
bool running = true;
while (running)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n=== GARAGE 1.0 CONSOLE APP ===\n");

    Console.WriteLine("VEHICLE MANAGEMENT");
    Console.WriteLine("  1. Park a vehicle");
    Console.WriteLine("  2. Remove a vehicle\n");

    Console.WriteLine("GARAGE INFORMATION");
    Console.WriteLine("  3. List all vehicles");
    Console.WriteLine("  4. List vehicle types and counts");
    Console.WriteLine("  5. Show garage capacity\n");

    Console.WriteLine("SEARCH");
    Console.WriteLine("  6. Find by registration number");
    Console.WriteLine("  7. Search by color");
    Console.WriteLine("  8. Search by number of wheels");
    Console.WriteLine("  9. Search by vehicle-specific properties");
    Console.WriteLine("  10. Search using multiple criteria\n");

    Console.WriteLine("SHUT DOWN GARAGE");
    Console.WriteLine("  0. Exit\n");

    Console.ResetColor();
    string choice = ReadRequiredString("Choose an option: ");
    System.Console.WriteLine("");

    switch (choice)
    {
        case "1": // Park a vehicle -> submenu
            ParkVehicle();
            break;

        case "2": // Remove a vehicle
            string registrationToRemove = ReadRegistrationNumber("\nRegistration number: ");

            garage.RemoveVehicle(registrationToRemove);
            break;

        case "3": // List all vehicles
            List<Vehicle> vehicles = garage.ListVehicles();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("The garage is empty.");
            }
            else
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    DisplayVehicle(vehicle);
                }
            }
            break;

        case "4": // List vehicle types and counts
            garage.ListVehicleTypesAndCounts();
            break;

        case "5":
            Console.WriteLine($"Garage capacity: {capacity}");
            Console.WriteLine($"Parked vehicles: {garage.ListVehicles().Count}");
            break;

        case "6":
            string registrationToFind = ReadRegistrationNumber("\nRegistration number: ");

            Vehicle? found =
                garage.FindVehicleByRegistrationNumber(registrationToFind);

            if (found != null)
            {
                DisplayVehicle(found);
            }
            break;

        case "7": // Search by color
            string color = ReadColor("Color: ");
            DisplayResults(garage.FindVehiclesByCriteria(color: color));
            break;

        case "8": // Search by number of weels
            int wheels = ReadIntegerInput("\nNumber of wheels: ", 0);
            DisplayResults(garage.FindVehiclesByCriteria(numberOfWheels: wheels));
            break;

        case "9": // Search by vehicle-specific properties -> submenu
            SearchBySpecificProperties();
            break;

        case "10": // Search using multiple criteria -> submenu
            string? registration = ReadOptionalRegistrationNumber(
                "\nRegistration number (Enter to skip): ");

            string? searchColor =
                ReadOptionalColor("Color (Enter to skip): ");

            int? searchWheels =
                ReadOptionalInt("Number of wheels (Enter to skip): ");

            string? vehicleType =
                ReadOptionalString(
                    "Vehicle type (Car/Motorcycle/Airplane/Bus/Boat; Enter to skip): ");
            System.Console.WriteLine("");

            List<Vehicle> matchesColor = garage.FindVehiclesByCriteria(
                registrationNumber: registration,
                color: searchColor,
                numberOfWheels: searchWheels,
                vehicleType: vehicleType);

            DisplayResults(matchesColor);
            break;

        case "0": // Exit
            running = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thanks for using Garage 1.0!\n\n");
            Console.ResetColor();
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid menu option. Try again.");
            Console.ResetColor();
            break;
    }
}
#endregion

// ***** METHODS *****
// Method for parking a vehicle: Menu 1.
// Creates a vehicle based on the user's input and attempts to park it.
#region ParkVehicle
void ParkVehicle()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Vehicle types:");
    Console.WriteLine("1. Car");
    Console.WriteLine("2. Motorcycle");
    Console.WriteLine("3. Airplane");
    Console.WriteLine("4. Bus");
    Console.WriteLine("5. Boat");
    Console.WriteLine("0. Return to main menu\n");
    Console.ResetColor();

    string type = ReadRequiredString("Choose vehicle type: ");

    while (type != "0" && type != "1" && type != "2" &&
           type != "3" && type != "4" && type != "5")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid vehicle type. Choose between 0 and 5.");
        Console.ResetColor();
        type = ReadRequiredString("Choose vehicle type: ");
    }

    if (type == "0")
    {
        return;
    }

    string registration = ReadRegistrationNumber("\nRegistration number: ");
    string vehicleColor = ReadColor("Color: ");
    int vehicleWheels = ReadIntegerInput("\nNumber of wheels: ", 0);

    try
    {
        Vehicle vehicle;

        switch (type)
        {
            case "1": // Car
                Car.FuelType fuel = ReadFuelType();

                vehicle = new Car(
                    registration, vehicleColor, vehicleWheels, fuel);
                break;

            case "2": // Motorcycle
                int cylinderVolume = ReadIntegerInput("\nCylinder volume (cc): ", 1);

                vehicle = new Motorcycle(
                    registration, vehicleColor, vehicleWheels, cylinderVolume);
                break;

            case "3": // Airplane
                int engines = ReadIntegerInput("\nNumber of engines: ", 1);

                vehicle = new Airplane(
                    registration, vehicleColor, vehicleWheels, engines);
                break;

            case "4": // Bus
                int seats = ReadIntegerInput("\nNumber of seats: ", 1);

                vehicle = new Bus(
                    registration, vehicleColor, vehicleWheels, seats);
                break;

            default: // Boat
                double boatLength = ReadDouble("\nBoat length: ", 0.1);

                vehicle = new Boat(
                    registration, vehicleColor, vehicleWheels, boatLength);
                break;
        }

        garage.ParkVehicle(vehicle);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Invalid vehicle: {ex.Message}");
    }
}
#endregion

// Method for displaying a vehicle: Menus 3, 6, 7, 8, 9, and 10.
// Displays the vehicle's common properties and its type-specific properties.
#region DisplayVehice
void DisplayVehicle(Vehicle vehicle)
{
    Console.WriteLine(
        $"{vehicle.GetType().Name} | " +
        $"{vehicle.RegistrationNumber} | " +
        $"{vehicle.Color} | {vehicle.NumberOfWheels} wheels");

    switch (vehicle)
    {
        case Car car:
            Console.WriteLine($"Fuel: {car.Fuel}\n");
            break;

        case Motorcycle motorcycle:
            Console.WriteLine(
                $"Cylinder volume: {motorcycle.CylinderVolume} cc\n");
            break;

        case Airplane airplane:
            Console.WriteLine($"Engines: {airplane.NumberOfEngines}\n");
            break;

        case Bus bus:
            Console.WriteLine($"Seats: {bus.NumberOfSeats}\n");
            break;

        case Boat boat:
            Console.WriteLine($"Length: {boat.BoatLength.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)}\n");
            break;
    }
}
#endregion

// Method for searching by vehicle-specific properties: Menu 9.
// Requests a property value and displays the matching vehicles.
#region SearchBySpecificProperties
void SearchBySpecificProperties()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n=== Search by Vehicle-Specific Properties ===");
    Console.WriteLine("1. Car — fuel type");
    Console.WriteLine("2. Motorcycle — cylinder volume");
    Console.WriteLine("3. Airplane — number of engines");
    Console.WriteLine("4. Bus — number of seats");
    Console.WriteLine("5. Boat — length");
    Console.WriteLine("0. Return to main menu\n");
    Console.ResetColor();

    string choice = ReadRequiredString("Choose an option: ");

    while (choice != "0" && choice != "1" && choice != "2" &&
       choice != "3" && choice != "4" && choice != "5")
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("Invalid menu option. Choose between 0 and 5.");
        Console.ResetColor();
        choice = ReadRequiredString("Choose an option: ");
    }

    switch (choice)
    {
        case "1":
            Car.FuelType fuel = ReadFuelType();
            DisplayResults(garage.FindVehiclesByFuelType(fuel));
            break;

        case "2":
            int volume = ReadIntegerInput("Cylinder volume (cc): ", 1);
            DisplayResults(garage.FindMotorcyclesByCylinderVolume(volume));
            break;

        case "3":
            int engines = ReadIntegerInput("Number of engines: ", 1);
            DisplayResults(garage.FindAirplanesByNumberOfEngines(engines));
            break;

        case "4":
            int seats = ReadIntegerInput("Number of seats: ", 1);
            DisplayResults(garage.FindBusesByNumberOfSeats(seats));
            break;

        case "5":
            double boatLength = ReadDouble("Boat length: ", 0.1);
            DisplayResults(garage.FindBoatsByLength(boatLength));
            break;

        case "0":
            return;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid menu option.");
            Console.ResetColor();
            break;
    }
}
#endregion

// Method for validating fuel type: Car creation and vehicle-specific search.
// Returns a valid FuelType value and repeats the prompt for invalid input.
#region ReadFuelType
static Car.FuelType ReadFuelType()
{
    while (true)
    {
        string fuel = ReadRequiredString("Fuel type (Gasoline/Diesel): ");

        if (fuel.Equals("Gasoline", StringComparison.OrdinalIgnoreCase))
        {
            return Car.FuelType.Gasoline;
        }

        if (fuel.Equals("Diesel", StringComparison.OrdinalIgnoreCase))
        {
            return Car.FuelType.Diesel;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid fuel type. Enter Gasoline or Diesel.");
        Console.ResetColor();
    }
}
#endregion

// Method for validating integer input: Used wherever a whole number is required.
// Returns an integer that meets the specified minimum value.
#region ReadIntegerInput
static int ReadIntegerInput(string prompt, int minimum)
{
    while (true)
    {
        Console.Write(prompt);

        if (int.TryParse(Console.ReadLine(), out int value) &&
            value >= minimum)
        {
            return value;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            $"Enter a whole number greater than or equal to {minimum}.");
        Console.ResetColor();
    }
}
#endregion

// Method for validating double input validation: converts the user's input into a decimal number and checks that it meets the minimum allowed value.
#region ReadDouble
static double ReadDouble(string prompt, double minimum)
{
    while (true)
    {
        Console.Write(prompt);

        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            input = input.Replace(',', '.'); // Without Replace(',', '.'), InvariantCulture expects a decimal point, so "7,5" would not be interpreted as 7.5. CultureInfo.InvariantCulture tells C# how to interpret the number.

            if (double.TryParse(
                    input,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double value) &&
                value >= minimum)
            {
                return value;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            $"Enter a number greater than or equal to {minimum.ToString(System.Globalization.CultureInfo.InvariantCulture)}.");
        Console.ResetColor();
    }
}
#endregion

// Method for required string input: Used wherever a non-empty string is required.
// Returns the trimmed input and repeats the prompt if the input is empty.
#region ReadRequiredString
static string ReadRequiredString(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim(); // Trim() removes whitespace from the beginning and end of a string. It does not remove spaces inside the text.
        }

        Console.WriteLine("Input cannot be empty.");
    }
}
#endregion

// Method for optional string input: Menu 10, search by multiple criteria.
// Returns a trimmed string or null if the user presses Enter.
#region ReadOptionalString
static string? ReadOptionalString(string prompt)
{
    Console.Write(prompt);
    string? input = Console.ReadLine();

    return string.IsNullOrWhiteSpace(input) ? null : input.Trim(); // Trim() removes whitespace from the beginning and end of a string. It does not remove spaces inside the text.
}
#endregion

// Method for optional integer input: Menu 10, search by multiple criteria.
// Returns a non-negative integer or null if the user presses Enter.
#region ReadOptionalInt
static int? ReadOptionalInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        if (int.TryParse(input, out int value) && value >= 0)
        {
            return value;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "Enter a non-negative whole number or press Enter to skip.");
        Console.ResetColor();
    }
}
#endregion

// Method for displaying search results: Menus 7, 8, 9, and 10.
// Displays matching vehicles or a message if no matches are found.
#region DisplayResults
void DisplayResults(List<Vehicle> results)
{
    if (results.Count == 0)
    {
        Console.WriteLine("No matching vehicles found.");
        return;
    }

    foreach (Vehicle vehicle in results)
    {
        DisplayVehicle(vehicle);
    }
}
#endregion

// Method for validating registration numbers: Vehicle creation and registration search.
// Returns a registration number containing exactly three letters followed by three digits.
#region ReadRegistrationNumber
static string ReadRegistrationNumber(string prompt)
{
    while (true)
    {
        string registrationNumber = ReadRequiredString(prompt);

        if (System.Text.RegularExpressions.Regex.IsMatch(
            registrationNumber, @"^[A-Za-z]{3}[0-9]{3}$"))
        {
            return registrationNumber;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "Invalid registration number. Use exactly 3 letters followed by 3 digits (e.g., ABC123).");
        Console.ResetColor();
    }
}
#endregion

// Method for optional registration number validation: Menu 10 (search by criteria).
// Returns nullable string. If the user presses ENTER, it returns null.
#region ReadOptionalRegistrationNumber
static string? ReadOptionalRegistrationNumber(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        input = input.Trim();

        if (System.Text.RegularExpressions.Regex.IsMatch(
            input, @"^[A-Za-z]{3}[0-9]{3}$"))
        {
            return input;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "Invalid registration number. Use exactly 3 letters followed by 3 digits (e.g., ABC123), or press Enter to skip.");
        Console.ResetColor();
    }
}
#endregion

// Method for color validation: menu 7 (search by color) and parking vehicles.
// Returns a string. If the user presses ENTER, the color is requested again.
#region ReadColor
static string ReadColor(string prompt)
{
    List<string> validColors = new List<string>
    {
        "Red", "Black", "White", "Blue", "Pink",
        "Green", "Yellow", "Orange", "Purple",
        "Brown", "Gray", "Grey", "Silver"
    };

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(
        $"\nAvailable colors: {string.Join(", ", validColors)}");
    System.Console.WriteLine((""));
    Console.ResetColor();

    while (true)
    {
        string color = ReadRequiredString(prompt);

        foreach (string validColor in validColors)
        {
            if (color.Equals(validColor, StringComparison.OrdinalIgnoreCase))
            {
                return validColor;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "Invalid color. Choose one of the available colors.\n");
        Console.ResetColor();

    }
}
#endregion

// Method for optional color validation: Menu 10 (search by criteria).
// Returns nullable string. If the user presses Enter, it returns null.
#region ReadOptionalColor
static string? ReadOptionalColor(string prompt)
{
    List<string> validColors = new List<string>
    {
        "Red", "Black", "White", "Blue", "Pink",
        "Green", "Yellow", "Orange", "Purple",
        "Brown", "Gray", "Grey", "Silver"
    };
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(
        $"Available colors: {string.Join(", ", validColors)}");
    Console.ResetColor();

    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        input = input.Trim();

        foreach (string validColor in validColors)
        {
            if (input.Equals(
                validColor, StringComparison.OrdinalIgnoreCase))
            {
                return validColor;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "Invalid color. Choose an available color or press Enter to skip.");
        Console.ResetColor();
    }
}
#endregion
