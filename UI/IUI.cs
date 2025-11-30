using System.Drawing;

namespace Ovning5Garage.UI
{
    public interface IUI
    {
        void Display(string text);
        string GetChoice(string question, string[] options, bool cancelable = false);
        string GetInput(string prompt);
        int GetNumber(string prompt);
        int GetNaturalNumber(string prompt);
        Color GetColor(string prompt);
    }
}