using Ovning5Garage.Vehicles;
using System.Drawing;

namespace Ovning5Garage.GarageTest;

public class GarageTest
{
    [Theory]
    [InlineData("Red")]
    [InlineData("Blue")]
    [InlineData("Green")]
    [InlineData("Black")]
    [InlineData("White")]
    public void Search_By_Color_Works(string criteria)
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(20);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
        MainGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
        MainGarage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
        MainGarage.Park(new Car("PQR660", Color.Black, FuelType.Diesel));
        MainGarage.Park(new Bus("BZX149", Color.Red, 50));
        MainGarage.Park(new Bus("SDF503", Color.Blue, 30));
        MainGarage.Park(new Bus("QWE891", Color.Black, 30));
        MainGarage.Park(new Motorcycle("RFV713", Color.Black, 200));
        MainGarage.Park(new Motorcycle("TGB406", Color.Red, 300));
        MainGarage.Park(new Motorcycle("LOP374", Color.White, 150));
        MainGarage.Park(new Motorcycle("NHY598", Color.Blue, 150));
        MainGarage.Park(new Airplane("IKL527", Color.Black, 1));
        MainGarage.Park(new Airplane("NDS372", Color.White, 2));
        MainGarage.Park(new Airplane("OPR418", Color.Black, 4));
        MainGarage.Park(new Boat("QAZ983", Color.Blue, 400));
        MainGarage.Park(new Boat("WSX314", Color.White, 300));
        MainGarage.Park(new Boat("EDC762", Color.White, 40000));

        Garage<ParkingSpot> OtherGarage;
        switch (criteria)
        {
            case "Red":
                OtherGarage = new Garage<ParkingSpot>(3);
                OtherGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
                OtherGarage.Park(new Bus("BZX149", Color.Red, 50));
                OtherGarage.Park(new Motorcycle("TGB406", Color.Red, 300));
                break;
            case "Blue":
                OtherGarage = new Garage<ParkingSpot>(4);
                OtherGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
                OtherGarage.Park(new Bus("SDF503", Color.Blue, 30));
                OtherGarage.Park(new Motorcycle("NHY598", Color.Blue, 150));
                OtherGarage.Park(new Boat("QAZ983", Color.Blue, 400));
                break;
            case "Green":
                OtherGarage = new Garage<ParkingSpot>(1);
                OtherGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
                break;
            case "Black":
                OtherGarage = new Garage<ParkingSpot>(5);
                OtherGarage.Park(new Car("PQR660", Color.Black, FuelType.Diesel));
                OtherGarage.Park(new Bus("QWE891", Color.Black, 30));
                OtherGarage.Park(new Motorcycle("RFV713", Color.Black, 200));
                OtherGarage.Park(new Airplane("IKL527", Color.Black, 1));
                OtherGarage.Park(new Airplane("OPR418", Color.Black, 4));
                break;
            case "White":
                OtherGarage = new Garage<ParkingSpot>(5);
                OtherGarage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
                OtherGarage.Park(new Motorcycle("LOP374", Color.White, 150));
                OtherGarage.Park(new Airplane("NDS372", Color.White, 2));
                OtherGarage.Park(new Boat("WSX314", Color.White, 300));
                OtherGarage.Park(new Boat("EDC762", Color.White, 40000));
                break;
            default:
                OtherGarage = new Garage<ParkingSpot>(0);
                break;

        }

        // Act
        var result = MainGarage.Search("All", Color.FromName(criteria));

        // Assert
        Assert.Equal(OtherGarage.ToArray(), result);
    }
    [Theory]
    [InlineData("Car")]
    [InlineData("Bus")]
    [InlineData("Motorcycle")]
    [InlineData("Airplane")]
    [InlineData("Boat")]
    public void Search_By_Type_Works(string criteria)
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(20);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
        MainGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
        MainGarage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
        MainGarage.Park(new Car("PQR660", Color.Black, FuelType.Diesel));
        MainGarage.Park(new Bus("BZX149", Color.Red, 50));
        MainGarage.Park(new Bus("SDF503", Color.Blue, 30));
        MainGarage.Park(new Bus("QWE891", Color.Black, 30));
        MainGarage.Park(new Motorcycle("RFV713", Color.Black, 200));
        MainGarage.Park(new Motorcycle("TGB406", Color.Red, 300));
        MainGarage.Park(new Motorcycle("LOP374", Color.White, 150));
        MainGarage.Park(new Motorcycle("NHY598", Color.Blue, 150));
        MainGarage.Park(new Airplane("IKL527", Color.Black, 1));
        MainGarage.Park(new Airplane("NDS372", Color.White, 2));
        MainGarage.Park(new Airplane("OPR418", Color.Black, 4));
        MainGarage.Park(new Boat("QAZ983", Color.Blue, 400));
        MainGarage.Park(new Boat("WSX314", Color.White, 300));
        MainGarage.Park(new Boat("EDC762", Color.White, 40000));

        Garage<ParkingSpot> OtherGarage;
        switch (criteria)
        {
            case "Car":
                OtherGarage = new Garage<ParkingSpot>(5);
                OtherGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
                OtherGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
                OtherGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
                OtherGarage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
                OtherGarage.Park(new Car("PQR660", Color.Black, FuelType.Diesel));
                break;
            case "Bus":
                OtherGarage = new Garage<ParkingSpot>(3);
                OtherGarage.Park(new Bus("BZX149", Color.Red, 50));
                OtherGarage.Park(new Bus("SDF503", Color.Blue, 30));
                OtherGarage.Park(new Bus("QWE891", Color.Black, 30));
                break;
            case "Motorcycle":
                OtherGarage = new Garage<ParkingSpot>(4);
                OtherGarage.Park(new Motorcycle("RFV713", Color.Black, 200));
                OtherGarage.Park(new Motorcycle("TGB406", Color.Red, 300));
                OtherGarage.Park(new Motorcycle("LOP374", Color.White, 150));
                OtherGarage.Park(new Motorcycle("NHY598", Color.Blue, 150));
                break;
            case "Airplane":
                OtherGarage = new Garage<ParkingSpot>(3);
                OtherGarage.Park(new Airplane("IKL527", Color.Black, 1));
                OtherGarage.Park(new Airplane("NDS372", Color.White, 2));
                OtherGarage.Park(new Airplane("OPR418", Color.Black, 4));
                break;
            case "Boat":
                OtherGarage = new Garage<ParkingSpot>(3);
                OtherGarage.Park(new Boat("QAZ983", Color.Blue, 400));
                OtherGarage.Park(new Boat("WSX314", Color.White, 300));
                OtherGarage.Park(new Boat("EDC762", Color.White, 40000));
                break;
            default:
                OtherGarage = new Garage<ParkingSpot>(0);
                break;
        }

        // Act
        var result = MainGarage.Search(criteria, Color.Empty);

        // Assert
        Assert.Equal(OtherGarage.ToArray(), result);
    }


    [Fact]
    public void Any_and_Color_Empty_returns_all()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(18);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
        MainGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
        MainGarage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
        MainGarage.Park(new Car("PQR660", Color.Black, FuelType.Diesel));
        MainGarage.Park(new Bus("BZX149", Color.Red, 50));
        MainGarage.Park(new Bus("SDF503", Color.Blue, 30));
        MainGarage.Park(new Bus("QWE891", Color.Black, 30));
        MainGarage.Park(new Motorcycle("RFV713", Color.Black, 200));
        MainGarage.Park(new Motorcycle("TGB406", Color.Red, 300));
        MainGarage.Park(new Motorcycle("LOP374", Color.White, 150));
        MainGarage.Park(new Motorcycle("NHY598", Color.Blue, 150));
        MainGarage.Park(new Airplane("IKL527", Color.Black, 1));
        MainGarage.Park(new Airplane("NDS372", Color.White, 2));
        MainGarage.Park(new Airplane("OPR418", Color.Black, 4));
        MainGarage.Park(new Boat("QAZ983", Color.Blue, 400));
        MainGarage.Park(new Boat("WSX314", Color.White, 300));
        MainGarage.Park(new Boat("EDC762", Color.White, 40000));

        // Act
        var result = MainGarage.Search("All", Color.Empty);

        // Assert
        Assert.Equal(MainGarage.ToArray(), result);
    }

    [Fact]
    public void Park_Same_Car_Twice_Not_Added_Second_Time()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(2);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));

        Garage<ParkingSpot> OtherGarage = new(2);
        OtherGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));

        // Act

        // Assert
        Assert.Equal([.. OtherGarage], [.. MainGarage]);
    }


    [Fact]
    public void Park_In_Full_Garage_Vehicle_Not_Added()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(1);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));

        Garage<ParkingSpot> OtherGarage = new(1);
        OtherGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));

        // Act

        // Assert
        Assert.Equal([.. OtherGarage], [.. MainGarage]);
    }

    [Fact]
    public void Removing_Car_Opens_Spot_Order_Matters()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(1);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));

        Garage<ParkingSpot> OtherGarage = new(1);
        OtherGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
        OtherGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));

        // Act
        MainGarage.Leave("KLM482");
        MainGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));

        // Assert
        Assert.Equal([.. OtherGarage], [.. MainGarage]);
    }

    [Fact]
    public void Removing_Car_Opens_Spot_Order_Wrong_on_Purpose()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(1);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));

        Garage<ParkingSpot> OtherGarage = new(1);
        OtherGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
        OtherGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));

        // Act
        MainGarage.Leave("KLM482");
        MainGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));

        // Assert
        Assert.NotEqual(OtherGarage.ToArray(), [.. MainGarage]);
    }

    [Fact]
    public void Removing_Car_Empty_Garage_Does_Nothing()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(2);
        Garage<ParkingSpot> OtherGarage = new(2);

        // Act
        MainGarage.Leave("KLM482");

        // Assert
        Assert.Equal([.. OtherGarage], [.. MainGarage]);
    }

    [Fact]
    public void Removing_By_Vehicle_Reference()
    {
        // Arrange
        Vehicle vehicle = new Car("KLM482", Color.Red, FuelType.Gasoline);
        Garage<ParkingSpot> MainGarage = new(2);
        Garage<ParkingSpot> OtherGarage = new(2);

        // Act
        MainGarage.Park(vehicle);
        MainGarage.Leave(vehicle);

        // Assert
        Assert.Equal([.. OtherGarage], [.. MainGarage]);
    }

    [Fact]
    public void Find_Vehicle_Works()
    {
        // Arrange
        Vehicle vehicle = new Car("KLM482", Color.Red, FuelType.Gasoline);

        Garage<ParkingSpot> MainGarage = new(18);
        MainGarage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
        MainGarage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
        MainGarage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
        MainGarage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
        MainGarage.Park(new Car("PQR660", Color.Black, FuelType.Diesel));
        MainGarage.Park(new Bus("BZX149", Color.Red, 50));
        MainGarage.Park(new Bus("SDF503", Color.Blue, 30));
        MainGarage.Park(new Bus("QWE891", Color.Black, 30));
        MainGarage.Park(new Motorcycle("RFV713", Color.Black, 200));
        MainGarage.Park(new Motorcycle("TGB406", Color.Red, 300));
        MainGarage.Park(new Motorcycle("LOP374", Color.White, 150));
        MainGarage.Park(new Motorcycle("NHY598", Color.Blue, 150));
        MainGarage.Park(new Airplane("IKL527", Color.Black, 1));
        MainGarage.Park(new Airplane("NDS372", Color.White, 2));
        MainGarage.Park(new Airplane("OPR418", Color.Black, 4));
        MainGarage.Park(new Boat("QAZ983", Color.Blue, 400));
        MainGarage.Park(new Boat("WSX314", Color.White, 300));
        MainGarage.Park(new Boat("EDC762", Color.White, 40000));

        // Act
        Vehicle? result = MainGarage.FindVehicle(vehicle.Registration);

        // Assert
        Assert.Equal(vehicle, result);
    }
    [Fact]
    public void Garage_Is_Empty_Works()
    {
        // Arrange
        Garage<ParkingSpot> MainGarage = new(18);

        // Act

        // Assert
        Assert.True(MainGarage.IsEmpty());
    }
}
