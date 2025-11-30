using System.Drawing;

namespace Ovning5Garage.Vehicles;

public class Boat(string registration, Color color, int length) : Vehicle(registration, color)
{
    public int Length = length;
    public override string ToString()
    {
        return $"A {Color.Name.ToLower()} {Length}cm long boat with registration {Registration}";
    }
}