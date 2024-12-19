using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credits;
using MainMenu;
using Campaign;
using Org.BouncyCastle.Utilities.Collections;

namespace MainOrCamp
{
    public class AfterOption
    {
        public void DisplayOptions()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 24));
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();

            Console.WriteLine(new string('-', 24));

            string[] Choices =
            {
                "CONTINUE TO CAMPAIGN",
                "BACK TO MAIN MENU"
            };
            int index = 0;
            ConsoleKey key;
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                for(int i = 0; i < Choices.Length; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(">>> " + Choices[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("" + Choices[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    index = (index == 0) ? Choices.Length - 1 : index - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    index = (index == Choices.Length - 1) ? 0 : index + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        StartCampaign story = new StartCampaign();
                        story.DisplayCampaign();
                    }
                    else if (index == 1)
                    {
                        MainMenu.Menu.DisplayMainMenu(); 
                    }
                }
            }
            /*while (true)
            {
                Console.WriteLine("Continue to Campaign or go back to main menu\n(a) Campaign     (b) Main Menu");
                string choices = Console.ReadLine().ToLower();
                switch (choices)
                {
                    case "a": StartCampaign story = new StartCampaign(); story.DisplayCampaign(); return;
                    case "b": MainMenu.Menu.DisplayMainMenu(); return;
                    default: Console.WriteLine("Error. Please only choose a or b respectively"); break; 
                }
            }*/
        }
    }
}
