/*
Airplane inherits the common properties from Vehicle.
*/
public class Airplane : Vehicle
{
    // Property
    public int NumberOfEngines {get; set;}
    
    // Constructor
    public Airplane(
        string registrationNumber, 
        string color, 
        int numberOfWheels, 
        int numberOfEngines): base(registrationNumber, color, numberOfWheels){
        NumberOfEngines = numberOfEngines;
    }

}