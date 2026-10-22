/*
Boat inherits the common properties from Vehicle.
*/
public class Boat : Vehicle
{
    // Property
    public double Length { get; set; }

    // Constructor
    public Boat(
        string registrationNumber,
        string color,
        int numberOfWheels,
        double length
    ) : base(registrationNumber, color, numberOfWheels)
    {
        Length = length;
    }
}
