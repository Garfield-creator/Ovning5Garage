using Ovning5Garage.UI;
using Ovning5Garage.Vehicles;
using System.Drawing;

namespace Ovning5Garage;



public class GarageHandler
{
    private readonly IUI UI = new ConsoleUI();
    private readonly IGarage<ParkingSpot> Garage;
    private readonly string[] VehicleTypes = ["Car", "Bus", "Motorcycle", "Airplane", "Boat"];

    public GarageHandler()
    {
        const string PARK = "Park";
        const string LEAVE = "Leave";
        const string FIND = "Find by registration";
        const string LIST = "List";
        const string TYPELIST = "List by type";
        const string SEARCH = "Search by properties";
        const string EXIT = "Exit";
        const string DEBUG = "Populate the garage with vehicles (Debug)";
        string[] mainMenu = [PARK, LEAVE, FIND, LIST, TYPELIST, SEARCH, EXIT, DEBUG];
        int number;
        do
        {
            number = UI.GetNaturalNumber("How many parking spots should the garage have?");
            
        } while (number < 1);
        Garage = new Garage<ParkingSpot>(number);
        while (true) 
        {
            string input = UI.GetChoice("", mainMenu);
            bool success;
            switch (input)
            {
                case PARK:
                    success = Park();
                    if (success) UI.Display("The vehicle was parked successfully!");
                    else UI.Display("The vehicle was not parked!"); //TODO: Refactor this code so that it tells you why.
                    break;
                case LEAVE:
                    success = Leave();
                    if (success) UI.Display("The vehicle left the garage!");
                    else UI.Display("A vehicle with that registration is not in the garage!");
                    break;
                case FIND:
                    Vehicle? found = FindVehicle();
                    if (found == null) UI.Display("No vehicle with that registration found!");
                    else UI.Display($"Found:\n{found}");
                    break;
                case LIST:
                    List();
                    break;
                case TYPELIST:
                    TypeList();
                    break;
                case SEARCH:
                    Search();
                    break;
                case EXIT:
                    return;
                case DEBUG:
                    Garage.Park(new Car("KLM482", Color.Red, FuelType.Gasoline));
                    Garage.Park(new Car("VMW278", Color.Blue, FuelType.Gasoline));
                    Garage.Park(new Car("JTR905", Color.Green, FuelType.Gasoline));
                    Garage.Park(new Car("FGH317", Color.White, FuelType.Diesel));
                    Garage.Park(new Car("PQR660", Color.Black, FuelType.Diesel)); 
                    Garage.Park(new Bus("BZX149", Color.Red, 50));
                    Garage.Park(new Bus("SDF503", Color.Blue, 30));
                    Garage.Park(new Bus("QWE891", Color.Black, 30));
                    Garage.Park(new Motorcycle("RFV713", Color.Black, 200));
                    Garage.Park(new Motorcycle("TGB406", Color.Red, 300));
                    Garage.Park(new Motorcycle("LOP374", Color.White, 150));
                    Garage.Park(new Motorcycle("NHY598", Color.Blue, 150));
                    Garage.Park(new Airplane("IKL527", Color.Black, 1));
                    Garage.Park(new Airplane("NDS372", Color.White, 2));
                    Garage.Park(new Airplane("OPR418", Color.Black, 4));
                    Garage.Park(new Boat("QAZ983", Color.Blue, 400));
                    Garage.Park(new Boat("WSX314", Color.White, 300));
                    Garage.Park(new Boat("EDC762", Color.White, 40000));
                    break;

            }
        }
    }

    public void List()
    {
        if (Garage.IsEmpty()) UI.Display("The garage is empty!");
        else
        { 
            UI.Display("In the garage there are:");
            foreach (var spot in Garage)
            {
                if (!spot.IsEmpty())
                {
                    UI.Display(spot.Vehicle!.ToString());
                }
            }
        }
    }

    public void TypeList()
    {
        int cars = 0;
        int busses = 0;
        int airplanes = 0;
        int motorcycles = 0;
        int boats = 0;
        foreach (ParkingSpot spot in Garage)
        {
            if (!spot.IsEmpty())
            {
                if (spot.Vehicle is Car) cars++;
                if (spot.Vehicle is Bus) busses++;
                if (spot.Vehicle is Airplane) airplanes++;
                if (spot.Vehicle is Motorcycle) motorcycles++;
                if (spot.Vehicle is Boat) boats++;
            }
        }
        UI.Display("In the garage there are:");
        UI.Display($"{cars} cars.");
        UI.Display($"{busses} busses.");
        UI.Display($"{airplanes} airplanes.");
        UI.Display($"{motorcycles} motorcycles.");
        UI.Display($"{boats} boats.");
    }

    public void Search()
    {
        string vehicleTypeChoice = "All";
        Color colorChoice = Color.Empty;
        string input;
        bool searchSpecified = false;
        while (!searchSpecified) 
        {
            input = UI.GetChoice("Select search criteria", [$"Vehicle type: {vehicleTypeChoice}", $"Color: {colorChoice.Name}", "Search with these parameters"]);
            if (input == $"Vehicle type: {vehicleTypeChoice}")
            {
                vehicleTypeChoice = UI.GetChoice("What vehicle type?", VehicleTypes);
                
            }
            else if (input == $"Color: {colorChoice.Name}")
            {
                colorChoice= UI.GetColor("Select color:");
            }
            else if (input == "Search with these parameters")
            {
                searchSpecified = true;
            }
        }
        ParkingSpot[] searchResult = Garage.Search(vehicleTypeChoice, colorChoice);
        if (searchResult.Length == 0 || searchResult == null)
        {
            UI.Display("There are no vehicles fitting that criteria in the garage!");
            return;
        }
        UI.Display("Search result:");
        foreach (ParkingSpot parkingSpot in searchResult)
        {
            UI.Display(parkingSpot.Vehicle!.ToString());
        }
    }

    public bool Park()
    {
        Vehicle? vehicle = CreateVehicle();
        if (vehicle != null)
        {
            return Garage.Park(vehicle);
        }
        return false;
    }

    private bool Park(Vehicle vehicle)
    {
        if (vehicle != null)
        {
            return Garage.Park(vehicle);
        }
        return false;
    }

    public bool Leave()
    {
        UI.Display("What is the registration of the vehicle that is leaving?");
        return Garage.Leave(GetRegistration());
    }

    public Vehicle? FindVehicle()
    {
        return Garage.FindVehicle(GetRegistration());
    }


    public string GetRegistration()
    {
        const string ERROR = "Registration must be 3 letters followed by 3 numbers!";
        while (true)
        {
            string input = UI.GetInput("Input registration. It must be 3 letters followed by 3 numbers.");
            if (input.Length == 6) 
                {
                if (input[..3].All(char.IsLetter) && input[4..].All(char.IsNumber))
                    return input.ToUpper();
                else UI.Display(ERROR);
                }
            else
            {
                UI.Display(ERROR);
            }
        }
    }

    private Vehicle? CreateVehicle()
    {
        string type = UI.GetChoice("What type of vehicle?", VehicleTypes, true);
        if (type == "cancel") return null;
        string registration = GetRegistration();
        Color color = UI.GetColor("What color is the vehicle?");
        switch (type)
        {
            case "Car":
                string fuelInput = UI.GetChoice("What fuel type does the car use?", Enum.GetNames<FuelType>());
                return new Car(registration, color, Enum.Parse<FuelType>(fuelInput));
            case "Bus":
                int seats = UI.GetNaturalNumber("How many seats do the bus have?");
                return new Bus(registration, color, seats);
            case "Motorcycle":
                int cylinderVolume = UI.GetNaturalNumber("What is the cylinder volume of the motorcycle?");
                return new Motorcycle(registration, color, cylinderVolume);
            case "Airplane":
                int engines = UI.GetNaturalNumber("How many engines does the plane have?");
                return new Airplane(registration, color, engines);
            case "Boat":
                int length = UI.GetNaturalNumber("How long is the boat? Enter a value in centimeters");
                return new Boat(registration, color, length);
        }
        return null; // You should not be able to get here.
    }
}
