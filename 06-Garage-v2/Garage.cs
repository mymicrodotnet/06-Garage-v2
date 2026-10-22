/*
The class Garage stores a collection of vehicles
The collection must be an array
The array must be private. Access modifier: private.
The garage capacity must be specified through the constructor.
*/
public class Garage
{
    // Field
    private Vehicle[] _vehicles; // private: _vehicles can only be accessed from inside the class.

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
        this._vehicles = new Vehicle[capacity];
        // Creates an array with 'capacity' positions.
        // Each position initially contains null because
        // Vehicle is a reference type.
        // 'this' refers to the current object and is optional here.

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
                System.Console.WriteLine("The vehicle could not be parked: the vehicle object cannot be null.");
            }
            return false; // vehicle is null                
        }

        // Duplicate validation: registration number must be unique.
        for (int j = 0; j < _vehicles.Length; j++)
        {
            if (_vehicles[j] != null &&
            _vehicles[j].RegistrationNumber.ToUpper() == vehicle.RegistrationNumber.ToUpper()) // _vehicles[j] != null to ensure the slot contains a vehicle before accessing its properties. When _vehicles[j] is null, C# never evaluates _vehicles[j].RegistrationNumber, avoiding a NullReferenceException.
            {
                if (showMessage)
                {
                    System.Console.WriteLine($"The vehicle could not be parked: Registration Number {vehicle.RegistrationNumber} duplicated.");
                }
                return false;
            }
        }

        // Find the first null in the array to park a vehicle. Finds a parking spot.
        for (int i = 0; i < _vehicles.Length; i++)
        {
            // Stores the vehicle in the first empty position.
            if (_vehicles[i] == null)
            {
                _vehicles[i] = vehicle;
                if (showMessage)
                {
                    System.Console.WriteLine($"Vehicle {vehicle.RegistrationNumber} successfully parked.");
                }
                return true; // parked
            }
        }
        if (showMessage)
        {
            System.Console.WriteLine("The vehicle could not be parked: the garage is full.");
        }
        return false; // full
    }
    #endregion

    #region RemoveVehicle
    // Method: Remove vehicle by registration number case-insensitive.
    public bool RemoveVehicle(string registrationNumber)
    {
        // Parameter validation.
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            System.Console.WriteLine($"The vehicle could not be removed: the registration number {registrationNumber} cannot be null or empty");
            return false;
        }

        // Search for the vehicle in the array _vehicles.
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i].RegistrationNumber.ToUpper() == registrationNumber.ToUpper())
            {
                // Remove the vehicle by making its array position empty.
                _vehicles[i] = null;
                System.Console.WriteLine($"Vehicle's registration number: {registrationNumber} successfully removed.");
                return true;
            }
        }
        System.Console.WriteLine($"The vehicle could not be removed: vehicle's registration number: {registrationNumber} not found.");
        return false;
    }
    #endregion

    #region ListVehicles
    // Method: If countVehicles=0, the array allVehiclesInGarage does not store elements because there are no vehicles to copy
    public Vehicle[] ListVehicles()
    {
        int countVehicles = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null)
            {
                countVehicles++;
            }
        }
        Vehicle[] allVehiclesInGarage = new Vehicle[countVehicles]; // If countVehicles = 0, Vehicle[] allVehiclesInGarage = new Vehicle[0], is valid in C# -> An array exists with zero elements. This method would return an empty array.

        int counter = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null)
            {
                allVehiclesInGarage[counter] = _vehicles[i]; // If countVehicles=0, the array allVehiclesInGarage does not store elements because there are no vehicles to copy
                // System.Console.WriteLine($"{allVehiclesInGarage[counter].RegistrationNumber}");
                counter++;
            }
        }
        return allVehiclesInGarage;
    }
    #endregion

    #region FindVehicleByRegistrationNumber
    // Method: returns the whole vehicle if registration number found. Returns null if not. Adding the nullability annotation (?), explicitly tells the compiler that returning null is intentional and allowed.
    public Vehicle? FindVehicleByRegistrationNumber(string registrationNumber)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            System.Console.WriteLine($"The registration number {registrationNumber} cannot be null or empty");
            return null;
        }

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && registrationNumber.ToUpper() == _vehicles[i].RegistrationNumber.ToUpper())
            {
                System.Console.WriteLine($"The vehicle {_vehicles[i].RegistrationNumber} found.");
                return _vehicles[i];
            }
        }
        System.Console.WriteLine($"The vehicle {registrationNumber} not found.");
        return null;
    }
    #endregion

    #region FindVehicleByColor
    // Method: Returns an empty array if the color is invalid or no vehicles match, avoiding null checks in the caller. In other words, returns an empty array for invalid color input or when no vehicles match, so callers can iterate without checking for null. If countVehicles=0, the array allVehiclesByColor does not store elements because there are no vehicles to copy
    public Vehicle[] FindVehiclesByColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            System.Console.WriteLine("The color of the vehicle cannot be null, empty or have spaces.");
            return []; // empty array
        }

        int countVehicles = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i].Color.ToUpper() == color.ToUpper())
            {
                countVehicles++;
            }
        }

        Vehicle[] allVehiclesByColor = new Vehicle[countVehicles];
        int counter = 0;
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i].Color.ToUpper() == color.ToUpper())
            {
                allVehiclesByColor[counter] = _vehicles[i];
                counter++;
            }
        }
        return allVehiclesByColor;
    }
    #endregion

    #region FindVehiclesByNumberOfWheels
    // Method: Returns and empty array if it does not match vehicles with numberOfWheels input. 
    public Vehicle[] FindVehiclesByNumberOfWheels(int numberOfWheels)
    {
        // this check is invalid because numberOfWheels is an int, and a non-nullable int cannot be null
        // if (numberOfWheels == null)
        // {
        //     System.Console.WriteLine("Number of wheels cannot be null. Returned: []");
        //     return [];
        // }        

        int countVehicleWheels = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i].NumberOfWheels == numberOfWheels)
            {
                countVehicleWheels++;
            }
        }
        Vehicle[] vehiclesByWheels = new Vehicle[countVehicleWheels];

        int counter = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i].NumberOfWheels == numberOfWheels)
            {
                vehiclesByWheels[counter] = _vehicles[i];
                counter++;
            }
        }
        return vehiclesByWheels;
    }
    #endregion

    #region FindVehiclesByFuelType    
    // Method: uses `_vehicles[i] is a Car car` to verify the Type of Vehicle, in this case Car. 
    public Vehicle[] FindVehiclesByFuelType(Car.FuelType fuelType)
    {
        int countVehiclesFuelType = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            // _vehicles[i] is Car car, Checks whether _vehicles[i] is a Car and, if so, assigns the object to the local variable car.
            // vehicles[i] != null is unnecessary because if _vehicles[i] is null, the (is Car car) check returns false.
            // car.GetType() == typeof(Car) is also valid but it does not check subclasses of subclases, checks whether the object's exact runtime type is Car. Instead, (is) checks the specified type and all its derived types, including subclasses of subclasses, at any inheritance depth, that is, also matches instances of subclasses of Car: public class Car : Vehicle { } | public class ElectricCar : Car { } | public class Tesla : ElectricCar { }
            if ((_vehicles[i] is Car car) && (car.Fuel == fuelType))
            {
                countVehiclesFuelType++;
            }
        }
        Vehicle[] allVehiclesByFuelType = new Vehicle[countVehiclesFuelType];
        int counter = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if ((_vehicles[i] is Car car) && (car.Fuel == fuelType))
            {
                allVehiclesByFuelType[counter] = _vehicles[i];
                counter++;
            }
        }
        return allVehiclesByFuelType;
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

        foreach (Vehicle vehicle in _vehicles)
        {
            // if (vehicle != null) is not necessary because if vehicle is null, every `is` check returns false.
            if (vehicle is Car)
            {
                countCar++;
            }
            if (vehicle is Motorcycle)
            {
                countMotorcycle++;
            }
            if (vehicle is Airplane)
            {
                countAirplane++;
            }
            if (vehicle is Bus)
            {
                countBus++;
            }
            if (vehicle is Boat)
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

    #region FindMotorcyclesByCylinderVolume
    public Vehicle[] FindMotorcyclesByCylinderVolume(int cylinderVolume)
    {
        int count = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Motorcycle motorcycle &&
                motorcycle.CylinderVolume == cylinderVolume)
            {
                count++;
            }
        }

        Vehicle[] results = new Vehicle[count];
        int index = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Motorcycle motorcycle &&
                motorcycle.CylinderVolume == cylinderVolume)
            {
                results[index] = motorcycle;
                index++;
            }
        }

        return results;
    }
    #endregion

    #region FindAirplanesByNumberOfEngines
    // Method
    public Vehicle[] FindAirplanesByNumberOfEngines(int numberOfEngines)
    {
        int counter = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Airplane airplane &&
                airplane.NumberOfEngines == numberOfEngines)
            {
                counter++;
            }
        }

        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Airplane airplane &&
                airplane.NumberOfEngines == numberOfEngines)
            {
                results[index] = airplane;
                index++;
            }
        }

        return results;
    }
    #endregion

    #region FindBusesByNumberOfSeats
    // Method
    public Vehicle[] FindBusesByNumberOfSeats(int numberOfSeats)
    {
        int counter = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Bus bus &&
                bus.NumberOfSeats == numberOfSeats)
            {
                counter++;
            }
        }

        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Bus bus &&
                bus.NumberOfSeats == numberOfSeats)
            {
                results[index] = bus;
                index++;
            }
        }

        return results;
    }
    #endregion

    #region FindBoatsByLength
    // Method
    public Vehicle[] FindBoatsByLength(double length)
    {
        int counter = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Boat boat &&
                boat.Length == length)
            {
                counter++;
            }
        }

        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] is Boat boat &&
                boat.Length == length)
            {
                results[index] = boat;
                index++;
            }
        }

        return results;
    }
    #endregion

    #region FindVehiclesByCriteria
    // Method: the criteria are based in the combination of the parameters. As a programmer I have to think in terms of the user's input also.
    public Vehicle[] FindVehiclesByCriteria(
        string? registrationNumber = null,
        string? color = null,
        int? numberOfWheels = null,
        string? vehicleType = null)
    {
        // First for: count matching vehicles.
        int counter = 0;
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] == null)
            {
                continue;
            }

            // Equals: Compares the actual vehicle type with the type requested by the user, ignoring uppercase and lowercase differences. "Car".Equals("car", StringComparison.OrdinalIgnoreCase); --> True
            // Ordinal: compares the characters directly, without language-specific linguistic rules.
            // IgnoreCase: ignores differences between uppercase and lowercase letters.    
            // HasValue: if true->the variable contains a value, if false->contains null. int? numberOfWheels = null; is equivalent to: Nullable<int> numberOfWheels = null;
            // GetType(): returns a Type object. Its Name property returns the type's name as a string

            // This block filters vehicles by registration number.
            if (!string.IsNullOrWhiteSpace(registrationNumber) &&
                !_vehicles[i].RegistrationNumber.Equals(
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // This block filters vehicles by color.
            if (!string.IsNullOrWhiteSpace(color) &&
                !_vehicles[i].Color.Equals(
                    color,
                    StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // This block filters vehicles by number of wheels.
            if (numberOfWheels.HasValue &&
                _vehicles[i].NumberOfWheels != numberOfWheels.Value)
            {
                continue;
            }

            // This block filters vehicles by their type, such as Car, Boat, Motorcycle, etc. Compares (_vehicles[i].GetType().Name) data type in string with (vehicleType and StringComparison.OrdinalIgnoreCase)
            string actualType = _vehicles[i].GetType().Name; // GetType() returns a Type object. Its Name property returns the type's name as a string. Then, it is compared the actual vehicle type with the type requested by the user, ignoring uppercase and lowercase differences.
            if (!string.IsNullOrWhiteSpace(vehicleType))
            {
                bool typesDoNotMatch = !actualType.Equals(
                    vehicleType,
                    StringComparison.OrdinalIgnoreCase);

                if (typesDoNotMatch)
                {
                    continue;
                }
            }
            counter++;
        }

        // Create an array with exactly the number of matches.
        Vehicle[] results = new Vehicle[counter];

        // Second for: copy matching vehicles into the result array.
        int index = 0;

        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] == null)
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(registrationNumber) &&
                !_vehicles[i].RegistrationNumber.Equals(
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(color) &&
                !_vehicles[i].Color.Equals(
                    color,
                    StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (numberOfWheels.HasValue &&
                _vehicles[i].NumberOfWheels != numberOfWheels.Value)
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(vehicleType) &&
                !_vehicles[i].GetType().Name.Equals(
                    vehicleType,
                    StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            results[index] = _vehicles[i]!;
            index++;
        }
        return results;
    }
    #endregion

}
