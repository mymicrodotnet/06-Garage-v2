/*
The class Garage stores a collection of vehicles
The collection must be a List<Vehicles>
The list must be private. Access modifier: private.
The garage capacity must be specified through the constructor.
List<Vehicle> requires the System.Collections.Generic namespace.
*/
using System.Runtime.CompilerServices;

public class Garage
{
    // Field
    private readonly List<Vehicle> _vehicles; //private: The field can only be accessed directly from within the Garage class. Code outside the class cannot access garage._vehicles -> Compilation Error.
    // readonly: applies only to fields. The field can be assigned in its declaration or in an instance constructor. After construction, it cannot be reassigned.
    private readonly int _capacity; // The field can only be accessed directly from within the Garage class. Code outside the class cannot access garage._capacity -> Compilation Error.
    // readonly: applies only to fields. Its value can be assigned in the declaration or constructor, but cannot be reassigned after construction.

    // Constructor: same name as the class, none return type.
    public Garage(int capacity)
    {
        // Validate capacity to ensure the garage has a positive capacity. Throw an exception if the argument is invalid.
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(capacity),
                "Garage capacity must be greater than zero."
            );
        }
        _vehicles = new List<Vehicle>(); // Create an empty list and assign its reference to _vehicles.
        _capacity = capacity;
    }

    // Methods
    #region ParkVehicle
    // Method: The public access modifier allows Program.cs to call this method.
    public bool ParkVehicle(Vehicle vehicle, bool showMessage = true)
    {
        // Parameter validation: checks the incoming method parameter vehicle exists. Rejects a null vehicle passed by mistake to this method. Example: garage.ParkVehicle(null). 
        if (vehicle == null)
        {
            if (showMessage)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                System.Console.WriteLine("The vehicle could not be parked: the vehicle object cannot be null.");
                Console.ResetColor();
            }
            return false; // vehicle is null.       
        }

        // Duplicate validation: registration number must be unique.
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].RegistrationNumber.Equals(
                vehicle.RegistrationNumber,
                StringComparison.OrdinalIgnoreCase)) // Compare registration numbers without case sensitivity.
            {
                if (showMessage)
                {
                    System.Console.WriteLine($"The vehicle could not be parked: Registration Number {vehicle.RegistrationNumber} duplicated.");
                }
                return false;
            }
        }

        // Check whether the garage has available capacity.
        if (_vehicles.Count < _capacity)
        {
            _vehicles.Add(vehicle);

            if (showMessage)
            {
                System.Console.WriteLine($"Vehicle {vehicle.RegistrationNumber} successfully parked.");
            }

            return true; // Successfully parked.
        }

        if (showMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("The vehicle could not be parked: the garage is full.");
            Console.ResetColor();
        }
        return false; // Garage full.
    }
    #endregion

    #region RemoveVehicle
    // Method: Remove vehicle by registration number case-insensitive.
    public bool RemoveVehicle(string registrationNumber)
    {
        // Parameter validation.
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            Console.ForegroundColor = ConsoleColor.Red;

            System.Console.WriteLine($"The vehicle could not be removed: the registration number {registrationNumber} cannot be null or empty");
            Console.ResetColor();
            return false;
        }

        // Search for the vehicle in the list _vehicles.
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].RegistrationNumber.Equals(
                registrationNumber,
                StringComparison.OrdinalIgnoreCase
            ))
            {
                // Remove the vehicle from the list.
                //Remove(vehicle) searches for the specified object and removes it.
                // RemoveAt(i) removes the element at the specified index directly.
                _vehicles.RemoveAt(i);

                System.Console.WriteLine($"Vehicle's registration number: {registrationNumber} successfully removed.");
                return true;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"The vehicle could not be removed: vehicle's registration number: {registrationNumber} not found.");
        Console.ResetColor();
        return false;
    }
    #endregion

    #region ListVehicles
    // Method: Returns a copy of the list of vehicles currently parked.
    public List<Vehicle> ListVehicles()
    {
        // return _vehicles; // No, because it must be prevented `garage.ListVehicles().Clear()`.
        return new List<Vehicle>(_vehicles); // A reference to a new list of vehicles will be returned.
    }
    #endregion

    #region FindVehicleByRegistrationNumber
    // Method: returns the whole vehicle if registration number found. Returns null if not. Adding the nullability annotation (?), explicitly tells the compiler that returning null is intentional and allowed.
    public Vehicle? FindVehicleByRegistrationNumber(string registrationNumber)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            System.Console.WriteLine($"The registration number {registrationNumber} cannot be null or empty.");
            return null;
        }

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].RegistrationNumber.Equals(
                registrationNumber,
                StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine($"The vehicle {_vehicles[i].RegistrationNumber} found.");
                return _vehicles[i];
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"The vehicle {registrationNumber} not found.");
        Console.ResetColor();
        return null;
    }
    #endregion

    #region FindVehiclesByColor
    // Method: Returns a list of vehicles matching the specified color.
    // Returns an empty list if the color is invalid or no vehicles match.
    // This creates an empty list: `new List<Vehicle>()`. It requires the keyword `new`.
    public List<Vehicle> FindVehiclesByColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            System.Console.WriteLine("The color of the vehicle cannot be null, empty or have spaces.");
            return new List<Vehicle>(); // Returns an empty List.
        }

        List<Vehicle> allVehiclesByColor = new List<Vehicle>(); // Empty List to store by color;
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].Color.Equals(
                color,
                StringComparison.OrdinalIgnoreCase
            ))
            {
                allVehiclesByColor.Add(_vehicles[i]);
            }
        }
        return allVehiclesByColor;  // Returns a List empty if no color matches.
    }
    #endregion

    #region FindVehiclesByNumberOfWheels
    // Method: Returns a list of vehicles matching the specified number of wheels.
    // Returns an empty list if no vehicles match.
    public List<Vehicle> FindVehiclesByNumberOfWheels(int numberOfWheels)
    {
        List<Vehicle> allVehiclesByWheels = new List<Vehicle>(); // Empty List to store vehicles by number of wheels.
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].NumberOfWheels == numberOfWheels)
            {
                allVehiclesByWheels.Add(_vehicles[i]);
            }
        }
        return allVehiclesByWheels;  // Returns an empty List if no number of wheels matching.
    }
    #endregion

    #region ListVehicleTypesAndCounts
    // Method: only lists the type of vehicles and the quantity of each one.
    public void ListVehicleTypesAndCounts()
    {
        int countCar = 0;
        int countMotorcycle = 0;
        int countAirplane = 0;
        int countBus = 0;
        int countBoat = 0;

        foreach (Vehicle vehicleElement in _vehicles)
        {
            // if (vehicle != null) is not necessary because if vehicle is null, every `is` check returns false.
            if (vehicleElement is Car)
            {
                countCar++;
            }
            if (vehicleElement is Motorcycle)
            {
                countMotorcycle++;
            }
            if (vehicleElement is Airplane)
            {
                countAirplane++;
            }
            if (vehicleElement is Bus)
            {
                countBus++;
            }
            if (vehicleElement is Boat)
            {
                countBoat++;
            }
        }
        System.Console.WriteLine($"Cars: {countCar}");
        System.Console.WriteLine($"Motorcycles: {countMotorcycle}");
        System.Console.WriteLine($"Airplanes: {countAirplane}");
        System.Console.WriteLine($"Buses: {countBus}");
        System.Console.WriteLine($"Boats: {countBoat}");
    }
    #endregion

    #region FindVehiclesByFuelType    
    // Finds all cars matching the specified fuel type.
    public List<Vehicle> FindVehiclesByFuelType(Car.FuelType fuelType)
    {
        List<Vehicle> allVehiclesByFuelType = new List<Vehicle>();


        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Car car && car.Fuel == fuelType)
            {
                allVehiclesByFuelType.Add(car); // car, No _vehicle[i].
            }
        }
        return allVehiclesByFuelType;
    }
    #endregion

    #region FindMotorcyclesByCylinderVolume
    // Method: Returns a list of motorcycles matching the specified cylinder volume.
    // Returns an empty list if no motorcycles match.
    public List<Vehicle> FindMotorcyclesByCylinderVolume(int cylinderVolume)
    {
        List<Vehicle> allVehiclesByCylinderVolume = new List<Vehicle>(); // Empty list to store vehicles by cylinder volume.

        foreach (Vehicle vehicleElement in _vehicles)
        {
            if (vehicleElement is Motorcycle motorcycle && motorcycle.CylinderVolume == cylinderVolume)
            {
                allVehiclesByCylinderVolume.Add(motorcycle);
            }
        }
        return allVehiclesByCylinderVolume;
    }
    #endregion

    #region FindAirplanesByNumberOfEngines
    public List<Vehicle> FindAirplanesByNumberOfEngines(int numberOfEngines)
    {
        List<Vehicle> allVehiclesByNumberOfEngines = new List<Vehicle>(); // Empty list to store airplanes by number of engines.

        foreach (Vehicle vehicleElement in _vehicles)
        {
            if (vehicleElement is Airplane airplane && airplane.NumberOfEngines == numberOfEngines)
            {
                allVehiclesByNumberOfEngines.Add(airplane);
            }
        }
        return allVehiclesByNumberOfEngines; // Returns an empty list if no vehicles match.
    }
    #endregion

    #region FindBusesByNumberOfSeats
    public List<Vehicle> FindBusesByNumberOfSeats(int numberOfSeats)
    {
        List<Vehicle> allBusesByNumberOfSeats = new List<Vehicle>(); // Empty list to store all buses by number of seats.

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Bus bus && bus.NumberOfSeats == numberOfSeats)
            {
                allBusesByNumberOfSeats.Add(bus);
            }
        }
        return allBusesByNumberOfSeats; // Empty list if no matching.
    }
    #endregion

    #region FindBoatsByLength
    public List<Vehicle> FindBoatsByLength(double boatLength)
    {
        List<Vehicle> allBoatsByLength = new List<Vehicle>(); // Empty list to store boats by length.

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Boat boat && boat.BoatLength == boatLength)
            {
                allBoatsByLength.Add(boat);
            }
        }
        return allBoatsByLength;
    }
    #endregion

    #region FindVehiclesByCriteria
    // Method: find all vehicles that match different criteria.
    // `Nullable<T>` properties: HasValue
    // `Nullable<T>` methods: Equals.
    // Criteria: RegistrationNumber, Color, NumberOfWheels, Vehicle type.
    public List<Vehicle> FindVehiclesByCriteria(
        string? registrationNumber = null,
        string? color = null,
        int? numberOfWheels = null,
        string? vehicleType = null
    )
    {
        List<Vehicle> allVehiclesByCriteria = new List<Vehicle>(); // Empty List to store vehicles that match the criteria.

        foreach (Vehicle vehicleElement in _vehicles)
        {
            // Validation for strings:`IsNullOrWhiteSpace` returns true for all three cases: null, "" and "   ". null ->No string value was supplied, ""->A string was supplied, but it is empty and "   " ->	A string containing only spaces.
            // Validation for strings: `vehicleElement.RegistrationNumber.Equals()` true if the registration number matches.
            if (!string.IsNullOrWhiteSpace(registrationNumber) &&
            !vehicleElement.RegistrationNumber.Equals(
                registrationNumber,
                StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(color) &&
            !vehicleElement.Color.Equals(
                color,
                StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // Validation for nullable integers: int? means Nullable<int>. In `Nullable<T>`, `.HasValue` says whether the nullable variable contains a value. It returns true if numberOfWheels has a value and false if numberOfWheels has no value. An integer (`int`) normally defaults to zero when default-initialized, but in this case, the optional parameter `numberOfWheels` defaults to null when no argument is supplied.
            // Property Value: In `Nullable<T>`, if `.HasValue` returns false, `.Value` CANNOT BE ACCESSED and throws an `InvalidOperationException`. If `.HasValue` returns true, `.Value` contains the stored value. BUT `HasValue` alone is not enough because it tells us whether a value exists, but not what that value is. Therefore, we use `numberOfWheels.Value` to retrieve the stored integer.
            // Example: garage.FindVehiclesByCriteria(numberOfWheels: 4);
            if (numberOfWheels.HasValue && vehicleElement.NumberOfWheels != numberOfWheels.Value) // numberOfWheels is an int?, while vehicleElement.NumberOfWheels is an int.
            {
                continue;
            }

            // vehicleElement is Car: Check whether a vehicle is a Car or any subclass of Car.
            // vehicleElement.GetType() == typeof(Car): checks for exactly Car, not subclasses of Car.
            // `GetType().Name`: returns the type name as a string.https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1.value?view=net-10.0#examples
            // Equals: compares two strings. StringComparison.OrdinalIgnoreCase makes the comparison case-insensitive.
            // Example: garage.FindVehiclesByCriteria(color: "White", vehicleType: "car");
            if (!string.IsNullOrWhiteSpace(vehicleType) && !vehicleElement.GetType().Name.Equals(vehicleType,
            StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            allVehiclesByCriteria.Add(vehicleElement);
        }
        return allVehiclesByCriteria;
    }
    #endregion
}
