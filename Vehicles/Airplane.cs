using System.Drawing;

namespace Ovning5Garage.Vehicles;

public class Airplane(string registration, Color color, int engineNumber) : Vehicle(registration, color)
{
    public int EngineNumber = engineNumber;

    public override string ToString()
    {
        return $"A {Color.Name.ToLower()} airplane with {EngineNumber} engines and registration {Registration}";
    }
}
