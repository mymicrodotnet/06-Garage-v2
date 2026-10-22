/*
Car inherits the common properties from Vehicle.
*/
public class Car : Vehicle
{
    // Enum: defines a fixed set of named constants.
    // Usage: Car car = new Car("ABC123", "Black", 4, Car.FuelType.Gasoline);
    public enum FuelType
    {
        Gasoline,
        Diesel
    }

    // Property
    public FuelType Fuel { get; set; }

    // Constructor
    public Car(
        string registrationNumber,
        string color,
        int numberOfWheels,
        FuelType fuelType
    ) : base(registrationNumber, color, numberOfWheels)
    {
        Fuel = fuelType;
    }
}