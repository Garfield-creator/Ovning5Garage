using Ovning5Garage.Vehicles;

namespace Ovning5Garage;
public class ParkingSpot : IEquatable<ParkingSpot>
{
    public Vehicle? Vehicle { get; set; } = null;
    public ParkingSpot()
    {

    }

    internal bool Park(Vehicle vehicle)
    {
        if (!IsEmpty()) return false;
        Vehicle = vehicle;
        return true;
    }

    internal bool IsEmpty()
    {
        return (Vehicle == null);
    }

    internal bool Leave()
    {
        if (IsEmpty()) return false;
        Vehicle = null;
        return true;
    }

    public bool Equals(ParkingSpot? other)
    {
        if (other == null) return false;
        else if (other.Vehicle == null && Vehicle == null) return true;
        else if (Vehicle == null)  return false;
        return Vehicle.Equals(other.Vehicle);
    }

    public override bool Equals(object? obj)
    {
        if (obj is ParkingSpot)
        {
            return base.Equals(obj);
        }
        else if (obj is Vehicle && Vehicle != null)
        {
            return Vehicle.Equals(obj);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Vehicle?.GetHashCode() ?? 0;
    }
}
