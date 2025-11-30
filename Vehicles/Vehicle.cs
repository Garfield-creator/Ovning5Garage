using System.Drawing;

namespace Ovning5Garage.Vehicles;


public abstract class Vehicle(string registration, Color color) : IEquatable<Vehicle>
{
    public string Registration { get; set; } = registration;
    public Color Color { get; set; } = color;

    public bool Equals(Vehicle? other)
    {
        if (other == null) { return false; }
        return Registration.Equals(other.Registration);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vehicle)
        {
            return base.Equals(obj);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Registration.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"A {Color.Name.ToLower()} vehicle with registration {Registration}";
    }
}