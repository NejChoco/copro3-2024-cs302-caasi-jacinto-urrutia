using System;
using Super_Hero_Game;
using MainOrCamp;
using Credits;
using Campaign;
using database;
using title;
using System.Security.Cryptography.X509Certificates;

namespace MainMenu
{
    public class Menu
    {
        public static void DisplayMainMenu()
        {
            string[] menuItems =
            {
                "NEW GAME",
                "LOAD GAME",
                "CAMPAIGN MODE",
                "CREDITS",
                "EXIT"
            };

            int selectedIndex = 0;
            ConsoleKey key;
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                pixelatedTitle veryGoodTitle = new pixelatedTitle();
                veryGoodTitle.renderTitle();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(">>> " + menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("" + menuItems[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (selectedIndex == 0)
                    {
                        string[] charSelection =
                        {
                            "CREATE CHARACTER",
                            "BACK"
                        };
                        selectedIndex = 0;
                        loop = true;

                        while (loop)
                        {
                            Console.Clear();
                            veryGoodTitle.renderTitle();
                            for (int i = 0; i < charSelection.Length; i++)
                            {
                                if (i == selectedIndex)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(">>> " + charSelection[i]);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine("" + charSelection[i]);
                                }
                            }

                            key = Console.ReadKey(true).Key;

                            if (key == ConsoleKey.UpArrow)
                            {
                                selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                            }
                            else if (key == ConsoleKey.DownArrow)
                            {
                                selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                            }
                            else if (key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                if (selectedIndex == 0)
                                {
                                    CharacterCreate createCharacter = new CharacterCreate();
                                    createCharacter.CreatingHero();
                                    createCharacter.AllocateAttributes();
                                    createCharacter.DisplayCharacterDetails();

                                    AfterOption afterOption = new AfterOption();
                                    afterOption.DisplayOptions();
                                }
                                else if (selectedIndex == 1)
                                {
                                    DisplayMainMenu();
                                }
                            }
                        }
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("--- LOAD GAME ---");
                        HeroDatabase database = new HeroDatabase();
                        database.DisplayHeroes();

                    }
                    else if (selectedIndex == 2)
                    {
                        StartCampaign story = new StartCampaign();
                        story.DisplayCampaign();
                    }
                    else if (selectedIndex == 3)
                    {
                        GroupCredits credits = new GroupCredits();
                        credits.DisplayCredits();
                    }
                    else if (selectedIndex == 4)
                    {
                        while (true)
                        {
                            Console.WriteLine("Are you sure you want to exit?\n(O) Yes   (X) No");
                            string exit = Console.ReadLine().ToUpper();
                            if (exit == "O")
                            {
                                Environment.Exit(0);
                                loop = false;
                                break;
                            }
                            else if (exit == "X")
                            {
                                DisplayMainMenu();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid input! Please only type O or X!\n");
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            DisplayMainMenu();
        }
    }
}
