using System;
using System.Data;
using System.Reflection;
using Campaign;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using MainMenu;
using System.Threading;
using title;


namespace database
{
    public class DatabaseHandler
    {
        protected string ConnectionString { get; set; }

        public DatabaseHandler()
        {
            ConnectionString = "server=localhost;port=3306;database=super;user=root;password=";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }

    public class HeroDatabase : DatabaseHandler
    {
        public void InsertHero(string name, string HoV, string gender, string race, string height, string weight, string build, string age, string skinColor, string eyeColor, string bodyModification, string hairStyle, string hairColor, string topClothes, string bottomPants, bool hasSidekick, string mainPower, string secondaryPower, string elementalOrb, int strength, int vitality, int energy, int attack, int agility, int defense, int luck, int intelligence)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM superhero WHERE uname = @uname";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@uname", name);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("Error: A hero with the username \"{0}\" already exists. Please choose a different username.", name);
                            return;
                        }
                    }

                    string query = "INSERT INTO superhero(uname,HoV,gender,race,height,weight,age,build,sColor,eColor,bMod,hair,hColor,tClothes,bPants,hasSide,mPower,sPower,orb,str,vit,mana,atk,agi,def,luck,intel) VALUES(@uname,@HoV,@gender,@race,@height,@weight,@age,@build,@skinColor,@eyeColor,@bodyModification,@hairStyle,@hairColor,@topClothes,@bottomPants,@hasSidekick,@mainPower,@secondaryPower,@elementalOrb,@strength,@vitality,@energy,@attack,@agility,@defense,@luck,@intelligence)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uname", name);
                        cmd.Parameters.AddWithValue("@HoV", HoV);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@race", race);
                        cmd.Parameters.AddWithValue("@height", height);
                        cmd.Parameters.AddWithValue("@weight", weight);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@build", build);

                        cmd.Parameters.AddWithValue("@skinColor", skinColor);
                        cmd.Parameters.AddWithValue("@eyeColor", eyeColor);
                        cmd.Parameters.AddWithValue("@bodyModification", bodyModification);
                        cmd.Parameters.AddWithValue("@hairStyle", hairStyle);
                        cmd.Parameters.AddWithValue("@hairColor", hairColor);
                        cmd.Parameters.AddWithValue("@topClothes", topClothes);
                        cmd.Parameters.AddWithValue("@bottomPants", bottomPants);
                        cmd.Parameters.AddWithValue("@hasSidekick", hasSidekick);

                        cmd.Parameters.AddWithValue("@mainPower", mainPower);
                        cmd.Parameters.AddWithValue("@secondaryPower", secondaryPower);
                        cmd.Parameters.AddWithValue("@elementalOrb", elementalOrb);
                        cmd.Parameters.AddWithValue("@strength", strength);
                        cmd.Parameters.AddWithValue("@vitality", vitality);
                        cmd.Parameters.AddWithValue("@energy", energy);
                        cmd.Parameters.AddWithValue("@attack", attack);
                        cmd.Parameters.AddWithValue("@agility", agility);
                        cmd.Parameters.AddWithValue("@defense", defense);
                        cmd.Parameters.AddWithValue("@luck", luck);
                        cmd.Parameters.AddWithValue("@intelligence", intelligence);

                        int status = cmd.ExecuteNonQuery();

                        if (status > 0)
                        {
                            Console.WriteLine("Hero added successfully.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while inserting hero: " + ex.Message);
                Console.ResetColor();
            }
        }
        public void DisplaySavedHeroes()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT uname FROM superhero";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("---SAVED CHARACTERS---");
                                int counter = 1;
                                while (reader.Read())
                                {
                                    string heroName = reader["uname"]?.ToString();
                                    if (!string.IsNullOrWhiteSpace(heroName))
                                    {
                                        Console.WriteLine($"{counter}. {heroName}");
                                        counter++;
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nNo heroes found in the database.");
                                Console.ResetColor();
                                Console.WriteLine("\nPress any key to go back.");
                                Console.ReadKey();
                                DisplayHeroes();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while displaying saved heroes: " + ex.Message);
                Console.ResetColor();
            }
        }

        public void DisplayHeroes()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT uname FROM superhero";

                while (true)
                {
                    Console.Clear();
                    string[] dbChoice =
                    {
                    "VIEW ALL CHARACTERS",
                    "VIEW A SPECIFIC CHARACTER",
                    "DELETE CHARACTER",
                    "GO BACK TO MAIN MENU"
                };

                    int selectedIndex = 0;
                    ConsoleKey key;
                    bool isSelected = false;

                    while (!isSelected)
                    {
                        Console.Clear();
                        pixelatedTitle veryGoodTitle = new pixelatedTitle();
                        veryGoodTitle.renderTitle();
                        for (int i = 0; i < dbChoice.Length; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine(">>> " + dbChoice[i]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("" + dbChoice[i]);
                            }
                        }

                        key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.UpArrow)
                            selectedIndex = (selectedIndex == 0) ? dbChoice.Length - 1 : selectedIndex - 1;
                        else if (key == ConsoleKey.DownArrow)
                            selectedIndex = (selectedIndex == dbChoice.Length - 1) ? 0 : selectedIndex + 1;
                        else if (key == ConsoleKey.Enter)
                            isSelected = true;
                    }

                    if (selectedIndex == 1)
                    {
                        Console.Clear();
                        DisplaySavedHeroes();
                        Console.Write("\nEnter the character name to view: ");
                        string enteredUsername = Console.ReadLine();

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM superhero WHERE uname = @uname", conn))
                        {
                            cmd.Parameters.AddWithValue("@uname", enteredUsername);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\x1b[3J");
                                        Console.WriteLine("\n\t --- CHARACTER LOOK ---\n");
                                        Console.WriteLine("Username: \t\t\t" + reader["uname"].ToString());
                                        Console.WriteLine("Morality: \t\t\t" + reader["HoV"].ToString());
                                        Console.WriteLine("Gender: \t\t\t" + reader["gender"].ToString());
                                        Console.WriteLine("Race: \t\t\t\t" + reader["race"].ToString());
                                        Console.WriteLine("Height: \t\t\t" + reader["height"].ToString());
                                        Console.WriteLine("Weight: \t\t\t" + reader["weight"].ToString());
                                        Console.WriteLine("Age: \t\t\t\t" + reader["age"].ToString());
                                        Console.WriteLine("Build: \t\t\t\t" + reader["build"].ToString());
                                        Console.WriteLine("Skin Color: \t\t\t" + reader["sColor"].ToString());
                                        Console.WriteLine("Eye Color: \t\t\t" + reader["eColor"].ToString());
                                        Console.WriteLine("Body Modification: \t\t" + reader["bMod"].ToString());
                                        Console.WriteLine("Hair Style: \t\t\t" + reader["hair"].ToString());
                                        Console.WriteLine("Hair Color: \t\t\t" + reader["hColor"].ToString());
                                        Console.WriteLine("Top Clothes: \t\t\t" + reader["tClothes"].ToString());
                                        Console.WriteLine("Bottom Pants: \t\t\t" + reader["bPants"].ToString());
                                        Console.WriteLine("Has Sidekick: \t\t\t" + reader["hasSide"].ToString());
                                        Console.WriteLine("\n\t--- CHARACTER POWERS ---\n");
                                        Console.WriteLine("Main Power: \t\t\t" + reader["mPower"].ToString());
                                        Console.WriteLine("Secondary Power: \t\t" + reader["sPower"].ToString());
                                        Console.WriteLine("Elemental Orb: \t\t\t" + reader["orb"].ToString());
                                        Console.WriteLine("\n\t --- ATTRIBUTES ---\n");
                                        Console.WriteLine("Strength: \t\t\t" + reader["str"].ToString());
                                        Console.WriteLine("Vitality: \t\t\t" + reader["vit"].ToString());
                                        Console.WriteLine("Energy: \t\t\t" + reader["mana"].ToString());
                                        Console.WriteLine("Attack: \t\t\t" + reader["atk"].ToString());
                                        Console.WriteLine("Agility: \t\t\t" + reader["agi"].ToString());
                                        Console.WriteLine("Defense: \t\t\t" + reader["def"].ToString());
                                        Console.WriteLine("Luck: \t\t\t\t" + reader["luck"].ToString());
                                        Console.WriteLine("Intelligence: \t\t\t" + reader["intel"].ToString());
                                        Console.WriteLine(new string('-', 30));
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Hero not found.");
                                    Console.ResetColor();
                                }
                            }
                        }
                        Console.WriteLine("\nPress any key to return");
                        Console.ReadKey();
                    }
                    else if (selectedIndex == 0)
                    {
                        Console.Clear();
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand("SELECT uname, HoV, gender, race, height, weight, age, build, sColor, eColor, bMod, hair, hColor, tClothes, bPants, hasSide, mPower, sPower, orb, str, vit, mana, atk, agi, def, luck, intel FROM superhero", conn))
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        Console.WriteLine("--- ALL CHARACTERS ---\n");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(new string('=', 50));
                                            Console.WriteLine("\n\t\t\t --- CHARACTER LOOK ---\n");
                                            Console.WriteLine($"Character Name: \t\t{reader["uname"]}");
                                            Console.WriteLine($"Morality: \t\t\t{reader["HoV"]}");
                                            Console.WriteLine($"Gender: \t\t\t{reader["gender"]}");
                                            Console.WriteLine($"Race: \t\t\t\t{reader["race"]}");
                                            Console.WriteLine($"Height: \t\t\t{reader["height"]}");
                                            Console.WriteLine($"Weight: \t\t\t{reader["weight"]}");
                                            Console.WriteLine($"Age: \t\t\t\t{reader["age"]}");
                                            Console.WriteLine($"Build: \t\t\t\t{reader["build"]}");
                                            Console.WriteLine($"Skin Color: \t\t\t{reader["sColor"]}");
                                            Console.WriteLine($"Eye Color: \t\t\t{reader["eColor"]}");
                                            Console.WriteLine($"Body Modification: \t\t{reader["bMod"]}");
                                            Console.WriteLine($"Hair Style: \t\t\t{reader["hair"]}");
                                            Console.WriteLine($"Hair Color: \t\t\t{reader["hColor"]}");
                                            Console.WriteLine($"Top Clothes: \t\t\t{reader["tClothes"]}");
                                            Console.WriteLine($"Bottom Pants: \t\t\t{reader["bPants"]}");
                                            Console.WriteLine($"Has Sidekick: \t\t\t{reader["hasSide"]}");
                                            Console.WriteLine("\n\t--- CHARACTER POWERS ---\n");
                                            Console.WriteLine($"Main Power: \t\t\t{reader["mPower"]}");
                                            Console.WriteLine($"Secondary Power: \t\t{reader["sPower"]}");
                                            Console.WriteLine($"Elemental Orb: \t\t\t{reader["orb"]}");
                                            Console.WriteLine("\n\t\t\t--- ATTRIBUTES ---\n");
                                            Console.WriteLine($"Strength: \t\t\t{reader["str"]}");
                                            Console.WriteLine($"Vitality: \t\t\t{reader["vit"]}");
                                            Console.WriteLine($"Energy: \t\t\t{reader["mana"]}");
                                            Console.WriteLine($"Attack: \t\t\t{reader["atk"]}");
                                            Console.WriteLine($"Agility: \t\t\t{reader["agi"]}");
                                            Console.WriteLine($"Defense: \t\t\t{reader["def"]}");
                                            Console.WriteLine($"Luck: \t\t\t\t{reader["luck"]}");
                                            Console.WriteLine($"Intelligence: \t\t\t{reader["intel"]}");
                                            Console.WriteLine();
                                            Console.WriteLine(new string('=', 50));
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("No heroes found.");
                                        Console.ResetColor();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error while displaying heroes: " + ex.Message);
                            Console.ResetColor();
                        }

                        Console.Write("\nPress any key to go back.");
                        Console.ReadKey();
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    int columnWidth = 15;
                                    int index = 1;

                                    Console.WriteLine("\tCharacter Name".PadRight(columnWidth));
                                    Console.WriteLine(new string('-', columnWidth * 2));

                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"{index++}. {reader["uname"].ToString().PadRight(columnWidth)}");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nNo heroes found.");
                                    Console.ResetColor();
                                    Console.WriteLine("\nPress any key to go back.");
                                    Console.ReadKey();
                                    DisplayHeroes();
                                }
                            }
                        }

                        Console.Write("\nEnter the character name to delete: ");
                        string enteredUsername = Console.ReadLine();

                        using (MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM superhero WHERE uname = @uname", conn))
                        {
                            checkCmd.Parameters.AddWithValue("@uname", enteredUsername);
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nError: Character not found.");
                                Console.WriteLine("\nPress any key to go back.");
                                Console.ReadKey();
                                Console.ResetColor();

                            }
                            else
                            {
                                Console.WriteLine("\nPlease type DELETE to permanently delete character.");
                                Console.ForegroundColor= ConsoleColor.Cyan;
                                string delete = Console.ReadLine();
                                Console.ResetColor();
                                if (delete == "DELETE")
                                {
                                    Console.Write("\nSure ka na ba?\n(a) Oo\t(b) Hinde\nYour answer is: ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    string ooOhinde = Console.ReadLine().ToLower();
                                    Console.ResetColor();
                                    if (ooOhinde == "a")
                                    {
                                        Console.WriteLine("\nWeeeh");
                                        Console.Write("Sure na sure na sure na sure ka na ba? Final answer?\n(a) Oo nga\t(b) Yaw ko na pala\nTugon: ");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string finalSagot = Console.ReadLine().ToLower();
                                        Console.ResetColor();
                                        if (finalSagot == "a")
                                        {
                                            HeroDatabase heroDb = new HeroDatabase();
                                            heroDb.DeleteHero(enteredUsername);
                                            Console.WriteLine("\nPress any key to go back");
                                            Console.ReadKey();
                                        }
                                        else if (finalSagot == "b")
                                        {
                                            Console.WriteLine("\nPress any key to go back");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Input!");
                                            Console.ResetColor();
                                            Console.WriteLine("Returning to Load game.");
                                            DisplayHeroes();
                                        }
                                    }
                                    else if (ooOhinde == "b")
                                    {
                                        Console.WriteLine("\nPress any key to go back");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Input!");
                                        Console.ResetColor();
                                        Console.WriteLine("Returning to Load game.");
                                        DisplayHeroes();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input!");
                                    Console.WriteLine("Returning to Load game.");
                                    DisplayHeroes();
                                }
                            }
                        }
                    }
                    else if (selectedIndex == 3)
                    {
                        break;
                    }
                }
            }
        }
        public void DeleteHero(string uname)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM superhero WHERE uname = @uname";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uname", uname);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Hero \"{0}\" deleted successfully.", uname);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("No hero found with the name \"{0}\".", uname);
                            Console.ResetColor();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while deleting hero: " + ex.Message);
                Console.ResetColor();
            }
        }
        public bool IsUsernameValid(string username)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM superhero WHERE uname = @uname";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uname", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while validating username: " + ex.Message);
                Console.ResetColor();
                return false;
            }
        }
    }
}
