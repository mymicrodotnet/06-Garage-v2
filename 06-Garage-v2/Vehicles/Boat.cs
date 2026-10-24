/*
Boat inherits the common properties from Vehicle.
*/
public class Boat : Vehicle
{
    // Property
    public double BoatLength { get; set; }

    // Constructor
    public Boat(
        string registrationNumber,
        string color,
        int numberOfWheels,
        double boatLength
    ) : base(registrationNumber, color, numberOfWheels)
    {
        BoatLength = boatLength;
    }
}
