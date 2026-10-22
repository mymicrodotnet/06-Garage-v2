/*
Motorcycle inherits the common properties from Vehicle.
*/
public class Motorcycle : Vehicle
{
    // Property
    public int CylinderVolume { get; set; }

    // Constructor
    public Motorcycle(
        string registrationNumber,
        string color,
        int numberOfWheels,
        int cylinderVolume
    ) : base(registrationNumber, color, numberOfWheels)
    {
        CylinderVolume = cylinderVolume;

    }
}