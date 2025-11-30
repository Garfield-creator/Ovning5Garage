using System.Drawing;

namespace Ovning5Garage.Vehicles;

public class Bus(string registration, Color color, int seats) : Vehicle(registration, color)
{
    public int Seats = seats;
    public override string ToString()
    {
        return $"A {Color.Name.ToLower()} bus with {Seats} seats and registration {Registration}";
    }
}
