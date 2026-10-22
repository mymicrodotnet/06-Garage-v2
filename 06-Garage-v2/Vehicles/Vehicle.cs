public class Vehicle
{
    // Public auto-properties
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }

    // Constructor
    public Vehicle(string registrationNumber, string color, int numberOfWheels)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            throw new ArgumentException(
                "Registration number cannot be null, empty, or whitespace.",
                nameof(registrationNumber)
            );
        }

        if (string.IsNullOrWhiteSpace(color))
        {
            throw new ArgumentException(
                "Color cannot be null, empty, or whitespace.",
                nameof(color)
            );
        }

        if (numberOfWheels < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(numberOfWheels),
                "Number of wheels cannot be negative."
            );
        }

        RegistrationNumber = registrationNumber;
        Color = color;
        NumberOfWheels = numberOfWheels;
    }

}