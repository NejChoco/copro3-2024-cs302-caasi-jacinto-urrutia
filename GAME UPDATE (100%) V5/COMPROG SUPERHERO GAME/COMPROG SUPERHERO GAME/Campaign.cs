using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using title;
using static System.Net.Mime.MediaTypeNames;

namespace Campaign
{
    public class StartCampaign
    {
        public void DisplayCampaign()
        {
            Console.WriteLine("--- CAMPAIGN ---\n\n--- STORY ---");

            string[] story = {
                           "\nA long time ago, the world was full of evil and chaos because of the invasion of people from ",
                           "another planet called Asyshin. Their goal is to get to the core of our planet, a source of ",
                           "boundless energy that keeps Earth alive and thriving. The Asyshins believed that harnessing the ",
                           "core's power would save their dying world, even if it meant dooming ours. And in order to save ",
                           "itself, Earth decided to share its power to the people of earth in order for us to protect it. With ",
                           "the help of this power, we will protect the earth from these invaders. A prophecy was given to ",
                           "the people of Earth, “One day the hero who will save the world will be born, but they are also ",
                           "capable of destroying it.”",

                           "\nBack to the present, the battle between humanity and the Asyshins has reached a critical point. ",
                           "The power Earth shared has awakened extraordinary abilities within its people, turning ordinary ",
                           "humans into protectors known as the Earthbound. These warriors now wield extraordinary ",
                           "powers to fight for our beloved planet. But there are also villains who, seduced by promises of ",
                           "power or fearing Earth's inevitable destruction, have sided with the Asyshins. The villains, ",
                           "known as the Corrupted, use their stolen Earth-given powers to aid the invaders, creating chaos ",
                           "and division among humanity's ranks. As the conflict intensifies, both sides race to uncover the ",
                           "secrets of the Earth's core, knowing that the final battle will decide the fate of the planet.",

                           "\nIn a small, quiet town in the Philippines, you wake up one day feeling an unfamiliar surge of ",
                           "energy coursing through your veins. The earth beneath you trembles slightly, and for a brief ",
                           "moment, you can hear its pulse, alive, vibrant, and powerful. The stories of the Asyshins, the ",
                           "Corrupted, and the prophecy suddenly feel much closer to home. You begin to sense an ",
                           "unusual energy within yourself, something far beyond anything you've ever known. Could it be ",
                           "that Earth has chosen you, or is this power something else entirely? These newfound abilities ",
                           "might hold the key to protecting the planet, or perhaps to its downfall. As your journey unfolds, ",
                           "every choice you make will influence not just your destiny but the world around you. Whether ",
                           "you rise as a hero, fall into darkness, or carve a path somewhere in between, the outcome is ",
                           "uncertain and entirely in your hands."
                           };

            string[] skipOrNot =
            {
                "READ CAMPAIGN",
                "SKIP CAMPAIGN",
                "BACK"
            };
            int selectedIndex = 0;
            ConsoleKey key;
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                pixelatedTitle veryGoodTitle = new pixelatedTitle();
                veryGoodTitle.renderTitle();
                for (int i = 0; i < skipOrNot.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(">>> " + skipOrNot[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("" + skipOrNot[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? skipOrNot.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == skipOrNot.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {

                        foreach (string line in story)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            effect(line, 1);
                            Console.WriteLine();
                            Console.ResetColor();

                        }
                        Console.WriteLine("\n\n\nPress any key to go back to main menu...");
                        Console.ReadLine();
                    }
                    else if (selectedIndex == 1)
                    {
                        foreach (string line in story)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(line);
                            Console.ResetColor();
                        }
                        Console.WriteLine("\n\nPress any key to return to the main menu...");
                        Console.ReadKey(true);
                    }
                    else if (selectedIndex == 2)
                    {
                        MainMenu.Menu.DisplayMainMenu();
                    }
                }
            }
        }

        private void effect(string line, int delay)
        {
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
