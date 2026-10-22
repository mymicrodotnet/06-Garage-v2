public class Bus : Vehicle
{
    // Property
    public int NumberOfSeats { get; set; }

    // Constructor
    public Bus(
        string registrationNumber,
        string color,
        int numberOfWheels,
        int numberOfSeats) : base(registrationNumber, color, numberOfWheels)
    {
        NumberOfSeats = numberOfSeats;
    }
}