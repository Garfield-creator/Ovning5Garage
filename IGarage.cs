
using Ovning5Garage.Vehicles;
using System.Drawing;

namespace Ovning5Garage
{
    public interface IGarage<Type> where Type : ParkingSpot
    {
        Vehicle? FindVehicle(string registration);

        IEnumerator<Type> GetEnumerator();

        bool Leave(string registration);

        bool Leave(Vehicle vehicle);

        bool Park(Vehicle vehicle);

        bool IsEmpty();
        Type[] Search(string vehicleType, Color color);
    }
}