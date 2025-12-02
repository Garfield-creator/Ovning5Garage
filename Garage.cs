using Ovning5Garage.Vehicles;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Ovning5Garage;

public class Garage<Type> : IEnumerable<Type>, IGarage<Type> where Type : ParkingSpot, new()
{
    private readonly Type[] _spots;
    private int _spotsTaken = 0;

    public Garage(int capacity)
    {
        _spots = new Type[capacity];
        for (int i = 0; i < capacity; i++)
        {
            _spots[i] = new Type();
        }
    }

    public string Park(Vehicle vehicle)
    {
        ArgumentNullException.ThrowIfNull(vehicle);
        if (_spotsTaken >= _spots.Length) { return "Full"; } //Checks if the garage is full.
        foreach (var spot in _spots) //Checks if the vehicle is already in the garage
        {
            if (vehicle.Equals(spot.Vehicle))
            {
                return "Same";
            }
        }
        for (int i = 0; i < _spots.Length; i++)
        {
            if (_spots[i].IsEmpty()) //Places the car in the first available spot.
            {
                _spots[i].Park(vehicle);
                _spotsTaken++;
                return "Parked";
            }
        }
        return "Error"; //You should not be able to get down here.
    }

    public bool Leave(Vehicle vehicle)
    {
        for (int i = 0; i < _spots.Length; i++)
        {
            if (vehicle.Equals(_spots[i].Vehicle))
            {
                _spots[i].Leave();
                _spotsTaken--;
                return true;
            }
        }
        return false;
    }

    public bool Leave(string registration)
    {
        for (int i = 0; i < _spots.Length; i++)
        {
            if (String.Equals(_spots[i].Vehicle?.Registration, registration))
            {
                _spots[i].Leave();
                _spotsTaken--;
                return true;
            }
        }
        return false;
    }

    public Vehicle? FindVehicle(string registration)
    {
        for (int i = 0; i < _spots.Length; i++)
        {
            if (String.Equals(_spots[i].Vehicle?.Registration, registration))
            {
                return _spots[i].Vehicle;
            }
        }
        return null;
    }

    public bool IsEmpty()
    {
        return _spotsTaken == 0;
    }

    public Type[] Search(string vehicleType, Color color)
    {
        Type?[] output =  [.. _spots
            .Where(spot => spot.Vehicle != null &&
                  (vehicleType.Equals("All") || spot.Vehicle.GetType().Name.Equals(vehicleType)) &&
                  (color == Color.Empty || spot.Vehicle.Color == color))
            .Select(spot => spot)];
        if (output == null) return [];
        return output!;
    }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<Type> GetEnumerator()
    {
        if (_spots == null) yield break;
        foreach (var spot in _spots)
        {
            yield return spot;
        }
    }


}
