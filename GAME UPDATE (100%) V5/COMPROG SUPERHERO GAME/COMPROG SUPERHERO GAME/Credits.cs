using System;
using title;

namespace Credits
{
    public class GroupCredits
    {
        public void DisplayCredits()
        {
            pixelatedTitle veryGoodTitle = new pixelatedTitle();
            veryGoodTitle.renderTitle();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t--- Credits ---\n\n\t\t\t     --- Group Members ---\n\n\t\t\tJensen Urrutia - Hotdog sa Freezer\n\t\tJustin Dayle Caasi - Ice cream container na isda laman\n\t\t\t  Jendri Jacinto - Adobong pusit\n\n\n\t\t\t     Thank you for playing.");
            Console.ResetColor();
            Console.WriteLine("\n\n\nPress any key to go back to main menu.");
            Console.ReadKey();
        }
    }
}
