using System.Drawing;

namespace Ovning5Garage.Vehicles;

public class Motorcycle(string registration, Color color, int cylinderVolume) : Vehicle(registration, color)
{
    public int CylinderVolume = cylinderVolume;
    public override string ToString()
    {
        return $"A {Color.Name.ToLower()} motorcycle with {CylinderVolume} cylinder volume and registration {Registration}";
    }
}
