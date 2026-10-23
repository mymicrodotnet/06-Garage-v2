/*
The class Garage stores a collection of vehicles
The collection must be a List<Vehicles>
The list must be private. Access modifier: private.
The garage capacity must be specified through the constructor.
List<Vehicle> requires the System.Collections.Generic namespace.
*/
public class Garage
{
    // Field
    private List<Vehicle> _vehicles; // private: _vehicles can only be accessed from inside the class.
    private readonly int _capacity; // readonly: applies only to fields. garage.capacity -> Compilation error

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
        _vehicles = new List<Vehicle>(); // An empty List is created.
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
                System.Console.WriteLine("The vehicle could not be parked: the vehicle object cannot be null.");
            }
            return false; // vehicle is null                
        }

        // Duplicate validation: registration number must be unique.
        for (int j = 0; j < _vehicles.Count; j++)
        {
            if (string.Equals(
                _vehicles[j].RegistrationNumber,
                vehicle.RegistrationNumber,
                StringComparison.OrdinalIgnoreCase))
            {
                if (showMessage)
                {
                    System.Console.WriteLine($"The vehicle could not be parked: Registration Number {vehicle.RegistrationNumber} duplicated.");
                }
                return false;
            }
        }
        // Reject parking when the garage is full.
        if (_vehicles.Count >= _capacity)
        {
            if (showMessage)
            {
                System.Console.WriteLine("The vehicle could not be parked: the garage is full.");
            }
            return false; // garage full.
        }

        _vehicles.Add(vehicle);
        if (showMessage)
        {
            System.Console.WriteLine($"Vehicle {vehicle.RegistrationNumber} successfully parked.");
        }
        return true; // parked.
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

        // Search for the vehicle in the List _vehicles.
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (string.Equals(
                 _vehicles[i].RegistrationNumber,
                 registrationNumber,
                 StringComparison.OrdinalIgnoreCase
                 ))
            {
                // Remove the matching vehicle from the list.
                _vehicles.Remove(_vehicles[i]);
                System.Console.WriteLine($"Vehicle's registration number: {registrationNumber} successfully removed.");
                return true;
            }
        }
        System.Console.WriteLine($"The vehicle could not be removed: vehicle's registration number: {registrationNumber} not found.");
        return false;
    }
    #endregion

    #region ListVehicles
    // Method: Returns an array of vehicles in the list.
    public Vehicle[] ListVehicles()
    {
        return _vehicles.ToArray();
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

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (string.Equals(
            _vehicles[i].RegistrationNumber,
            registrationNumber,
            StringComparison.InvariantCultureIgnoreCase))
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

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (string.Equals(
                _vehicles[i].Color,
                color,
                StringComparison.InvariantCultureIgnoreCase))
            {
                countVehicles++;
            }
        }

        Vehicle[] allVehiclesByColor = new Vehicle[countVehicles];
        int counter = 0;
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (string.Equals(
                _vehicles[i].Color,
                color,
                StringComparison.InvariantCultureIgnoreCase
            ))
            {
                allVehiclesByColor[counter] = _vehicles[i];
                counter++;
            }
        }
        return allVehiclesByColor;
    }
    #endregion

    #region FindVehiclesByNumberOfWheels
    // Find all vehicles matching the specified number of wheels.
    public Vehicle[] FindVehiclesByNumberOfWheels(int numberOfWheels)
    {
        int countVehicleWheels = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].NumberOfWheels == numberOfWheels)
            {
                countVehicleWheels++;
            }
        }

        Vehicle[] vehiclesByWheels = new Vehicle[countVehicleWheels];
        int counter = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i].NumberOfWheels == numberOfWheels)
            {
                vehiclesByWheels[counter] = _vehicles[i];
                counter++;
            }
        }

        return vehiclesByWheels;
    }
    #endregion

    #region FindVehiclesByFuelType
    // Find all cars matching the specified fuel type.
    public Vehicle[] FindVehiclesByFuelType(Car.FuelType fuelType)
    {
        int countVehiclesFuelType = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Car car && car.Fuel == fuelType)
            {
                countVehiclesFuelType++;
            }
        }

        Vehicle[] allVehiclesByFuelType =
            new Vehicle[countVehiclesFuelType];

        int counter = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Car car && car.Fuel == fuelType)
            {
                allVehiclesByFuelType[counter] = car;
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
    // Find motorcycles matching the specified cylinder volume.
    public Vehicle[] FindMotorcyclesByCylinderVolume(int cylinderVolume)
    {
        int count = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Motorcycle motorcycle &&
                motorcycle.CylinderVolume == cylinderVolume)
            {
                count++;
            }
        }

        Vehicle[] results = new Vehicle[count];
        int index = 0;

        for (int i = 0; i < _vehicles.Count; i++)
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
    // Find airplanes matching the specified number of engines.
    public Vehicle[] FindAirplanesByNumberOfEngines(int numberOfEngines)
    {
        int counter = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Airplane airplane &&
                airplane.NumberOfEngines == numberOfEngines)
            {
                counter++;
            }
        }

        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        for (int i = 0; i < _vehicles.Count; i++)
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
    // Find buses matching the specified number of seats.
    public Vehicle[] FindBusesByNumberOfSeats(int numberOfSeats)
    {
        int counter = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Bus bus &&
                bus.NumberOfSeats == numberOfSeats)
            {
                counter++;
            }
        }

        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        for (int i = 0; i < _vehicles.Count; i++)
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
    // Find boats matching the specified length.
    public Vehicle[] FindBoatsByLength(double length)
    {
        int counter = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Boat boat &&
                boat.Length == length)
            {
                counter++;
            }
        }

        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        for (int i = 0; i < _vehicles.Count; i++)
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
    // Find vehicles matching all supplied criteria.
    public Vehicle[] FindVehiclesByCriteria(
        string? registrationNumber = null,
        string? color = null,
        int? numberOfWheels = null,
        string? vehicleType = null)
    {
        // First pass: count matching vehicles.
        int counter = 0;

        for (int i = 0; i < _vehicles.Count; i++)
        {
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

            counter++;
        }

        // Create an array with exactly the number of matches.
        Vehicle[] results = new Vehicle[counter];
        int index = 0;

        // Second pass: copy matching vehicles into the result array.
        for (int i = 0; i < _vehicles.Count; i++)
        {
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

            results[index] = _vehicles[i];
            index++;
        }

        return results;
    }
    #endregion

}
