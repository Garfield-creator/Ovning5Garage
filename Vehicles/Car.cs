using System.Drawing;

namespace Ovning5Garage.Vehicles;

public class Car(string registration, Color color, FuelType fuel) : Vehicle(registration, color)
{
    public FuelType Fuel = fuel;

    public override string ToString()
    {
        return $"A {Color.Name.ToLower()} car with registration {Registration} that runs on {Enum.GetName(Fuel)!.ToLower()}";
    }
}
