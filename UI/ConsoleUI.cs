namespace Ovning5Garage.UI;

using System.Drawing;

public class ConsoleUI : IUI
{
    public void Display(string text)
    {
        if (text != "")  Console.WriteLine(text);
    }

    public string GetChoice(string question, string[] options, bool cancelable = false)
    {
        int choice = -1;
        while (choice > options.Length || choice < 0 && cancelable || choice < 1 && !cancelable)
        {
            Display(question);
            for (int i = 0; i < options.Length; i++)
            {
                Display($"[{i + 1}] {options[i]}");
            }
            if (cancelable) Display("[0] Cancel");
            choice = GetNaturalNumber("");
            if (choice == 0 && cancelable)
            {
                Display("Cancelling!");
                return "Cancel";
            }
            if (choice > options.Length || choice < 1) Display("Please select a valid choice!");
        }
        
        return options[choice-1];
    }

    public string GetInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input)) Console.WriteLine("Please enter some input!");
            else
            {
                return input;
            }
        }
    }

    public int GetNumber(string prompt)
    {
        while (true)
        {
            if (int.TryParse(GetInput(prompt), out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Enter a valid number!");
            }
        }
    }

    public int GetNaturalNumber(string prompt)
    {
        while (true)
        {
            if (int.TryParse(GetInput(prompt), out int number))
            {
                if (number < 0) Console.WriteLine("Enter a valid number!");
                else return number;
            }
            else
            {
                Console.WriteLine("Enter a valid number!");
            }
        }
    }

    public Color GetColor(string prompt)
    {
        Color color;
        while (true)
        {
            color = Color.FromName(GetInput(prompt));
            if (color.IsKnownColor)
            {
                return color;
            }
            else
            {
                Console.WriteLine("Enter a valid color!");
            }
        }
    }
}