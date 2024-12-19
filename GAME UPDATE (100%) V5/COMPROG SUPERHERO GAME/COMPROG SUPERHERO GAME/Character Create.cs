using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using database;
using MySql.Data.MySqlClient;

namespace Super_Hero_Game
{
    public interface ICharacterActions
    {
        void DisplayCharacterDetails();
        void Introduce();
        void AllocateAttributes();
    }

    public struct PhysicalAttributes
    {
        public string Height { get; }
        public string Weight { get; }
        public string Build { get; }

        public PhysicalAttributes(string height, string weight, string build)
        {
            Height = height;
            Weight = weight;
            Build = build;
        }
    }
    public abstract class CharacterBase : DatabaseHandler
    {

        public abstract void DisplayCharacterDetails();


        public virtual void Introduce()
        {
            Console.WriteLine("Welcome to the Character Creation Menu!");
        }
    }
    public class CharacterCreate : CharacterBase, ICharacterActions
    {
        private int strength, vitality, energy, attack, agility, defense, luck, intelligence;
        private string name, HoV, gender, race, age, skinColor, eyeColor, bodyModification, hairStyle, hairColor, topClothes, bottomPants;
        private bool hasSidekick;
        private string mainPower, secondaryPower, elementalOrb;
        private PhysicalAttributes physicalAttributes;

        private HeroDatabase _heroDatabase;

        public string UName
        {
            get { return name; }
            set { name = value; }
        }

        public string HOV
        {
            get { return HoV; }
            set { HoV = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Race
        {
            get { return race; }
            set { race = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public PhysicalAttributes Attributes
        {
            get { return physicalAttributes; }
            set { physicalAttributes = value; }
        }

        public string SkinColor
        {
            get { return skinColor; }
            set { skinColor = value; }
        }

        public string EyeColor
        {
            get { return eyeColor; }
            set { eyeColor = value; }
        }

        public string BodyModification
        {
            get { return bodyModification; }
            set { bodyModification = value; }
        }

        public string HairStyle
        {
            get { return hairStyle; }
            set { hairStyle = value; }
        }

        public string HairColor
        {
            get { return hairColor; }
            set { hairColor = value; }
        }

        public string TopClothes
        {
            get { return topClothes; }
            set { topClothes = value; }
        }

        public string BottomPants
        {
            get { return bottomPants; }
            set { bottomPants = value; }
        }

        public bool HasSidekick
        {
            get { return hasSidekick; }
            set { hasSidekick = value; }
        }
        public string MainPower
        {
            get { return mainPower; }
            set { mainPower = value; }
        }
        public string SecondaryPower
        {
            get { return secondaryPower; }
            set { secondaryPower = value; }
        }
        public string ElementalOrb
        {
            get { return elementalOrb; }
            set { elementalOrb = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int Vitality
        {
            get { return vitality; }
            set { vitality = value; }
        }

        public int Energy
        {
            get { return energy; }
            set { energy = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int Luck
        {
            get { return luck; }
            set { luck = value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }
        public CharacterCreate() { }

        public CharacterCreate(string name, string HoV, string gender, string race)
        {
            this.UName = name;
            this.HOV = HoV;
            this.Gender = gender;
            this.Race = race;

        }

        public void CharacterCreation(string name, string HoV, string gender, string race, string age, string skinColor, string eyeColor)
        {
            this.UName = name;
            this.HOV = HoV;
            this.Gender = gender;
            this.Race = race;
            this.Age = age;
            this.SkinColor = skinColor;
            this.EyeColor = eyeColor;
        }
        public void CharacterCreation(string name, string HoV, string gender, string race, string age, string skinColor, string eyeColor, string bodyModification, string hairStyle, string hairColor, string topClothes, string bottomPants, bool hasSidekick, string mPower, string sPower, string elementalOrb, int strength, int vitality, int energy, int attack, int agility, int defense, int luck, int intelligence)
        {
            this.UName = name;
            this.HOV = HoV;
            this.Gender = gender;
            this.Race = race;
            this.Age = age;
            this.SkinColor = skinColor;
            this.EyeColor = eyeColor;
            this.BodyModification = bodyModification;
            this.HairColor = hairColor;
            this.HairStyle = hairStyle;
            this.TopClothes = topClothes;
            this.BottomPants = bottomPants;
            this.HasSidekick = hasSidekick;
            this.MainPower = mainPower;
            this.SecondaryPower = secondaryPower;
            this.ElementalOrb = elementalOrb;
            this.Strength = strength;
            this.Vitality = vitality;
            this.Energy = energy;
            this.Attack = attack;
            this.Agility = agility;
            this.Defense = defense;
            this.Luck = luck;
            this.Intelligence = intelligence;
        }

        public void SetPhysicalAttributes(string height, string weight, string build)
        {
            this.physicalAttributes = new PhysicalAttributes(height, weight, build);
        }


        public override void Introduce()
        {
            Console.WriteLine("Hello! Get ready to customize your character.\n");
        }


        public void CreatingHero()
        {
            CharacterCreate characterCreate = new CharacterCreate();
            HeroDatabase heroDb = new HeroDatabase();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---CHARACTER CREATION---\n");
            Console.ResetColor();

            characterCreate.Introduce();

            Console.WriteLine(new string('-', 24));
            while (true)
            {
                Console.Write("\nEnter Superhero name: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                UName = Console.ReadLine();
                Console.ResetColor();

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM superhero WHERE uname = @uname";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@uname", name);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (UName.Length > 26 || UName.Length < 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nError. Name must contain at least 6 characters and no more than 26 characters.");
                            Console.ResetColor();
                        }
                        else if (string.IsNullOrWhiteSpace(UName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nName cannot be empty. Please enter a valid name.");
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (count > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nA hero with the username \"{0}\" already exists. Please choose a different username.", name);
                            Console.ResetColor();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nHero or Villain? Please type a for Hero or b for Villain: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string moralInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (moralInput)
                {
                    case "a":
                        HOV = "Hero";
                        break;
                    case "b":
                        HOV = "Villain";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a' or 'b'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        moralInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your gender?\na. Male\nb. Female\nc. Gay\nd. Lesbian\ne. Non-binary\nf. Others\nType the letter of your gender: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string genderInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (genderInput)
                {
                    case "a":
                        Gender = "Male";
                        break;
                    case "b":
                        Gender = "Female";
                        break;
                    case "c":
                        Gender = "Gay";
                        break;
                    case "d":
                        Gender = "Lesbian";
                        break;
                    case "e":
                        Gender = "Non-binary";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', 'd', 'e', or 'f'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        genderInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your race?\na. Human\nb. Mech\nc. Celestial\nd. Elf\ne. Mutant\nType the letter of your race: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string raceInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (raceInput)
                {
                    case "a":
                        Race = "Human";
                        break;
                    case "b":
                        Race = "Mech";
                        break;
                    case "c":
                        Race = "Celestial";
                        break;
                    case "d":
                        Race = "Elf";
                        break;
                    case "e":
                        Race = "Mutant";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', 'd', or 'e'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        raceInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your height?\na. Very Short\nb. Short\nc. Average\nd. Tall\ne. Very Tall\nType the letter of your height: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string heightInput = Console.ReadLine().ToLower();
            string height = "";
            Console.ResetColor();

            while (true)
            {
                switch (heightInput)
                {
                    case "a":
                        height = "Very Short";
                        break;
                    case "b":
                        height = "Short";
                        break;
                    case "c":
                        height = "Average";
                        break;
                    case "d":
                        height = "Tall";
                        break;
                    case "e":
                        height = "Very Tall";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', 'd', or 'e'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        heightInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your weight?\na. Very Light\nb. Light\nc. Average\nd. Heavy\ne. Very Heavy\nType the letter of your weight: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string weightInput = Console.ReadLine().ToLower();
            string weight = "";
            Console.ResetColor();

            while (true)
            {
                switch (weightInput)
                {
                    case "a":
                        weight = "Very Light";
                        break;
                    case "b":
                        weight = "Light";
                        break;
                    case "c":
                        weight = "Average";
                        break;
                    case "d":
                        weight = "Heavy";
                        break;
                    case "e":
                        weight = "Very Heavy";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for weight.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        weightInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your age range?\na. Teenager (13–19)\nb. Young Adult (20–29)\nc. Adult (30–39)\nd. Middle-Aged (40–49)\ne. Senior (50+)\nType the letter of your age range: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string ageInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (ageInput)
                {
                    case "a":
                        Age = "Teenager (13–19)";
                        break;
                    case "b":
                        Age = "Young Adult (20–29)";
                        break;
                    case "c":
                        Age = "Adult (30–39)";
                        break;
                    case "d":
                        Age = "Middle-Aged (40–49)";
                        break;
                    case "e":
                        Age = "Senior (50+)";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', 'd', or 'e'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ageInput = Console.ReadLine().ToLower();
                        Console.ResetColor ();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your build?\na. Athletic\nb. Muscular\nc. Slim\nd. Bulky\ne. Slender\nType the letter of your build: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string buildInput = Console.ReadLine().ToLower();
            string build = "";
            Console.ResetColor();

            while (true)
            {

                switch (buildInput)
                {
                    case "a":
                        build = "Athletic";
                        break;
                    case "b":
                        build = "Muscular";
                        break;
                    case "c":
                        build = "Slim";
                        break;
                    case "d":
                        build = "Bulky";
                        break;
                    case "e":
                        build = "Slender";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for build.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        buildInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }

            Console.WriteLine();

            Attributes = new PhysicalAttributes(height, weight, build);

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your skin color?\na. Pale\nb. Light\nc. Medium\nd. Tan\ne. Dark\nf. Deep\ng. Pale Blue\nh. Green\ni. Silver\nj. Brown\nk. Purple\nType the letter of your skin color: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string skinColorInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (skinColorInput)
                {
                    case "a":
                        SkinColor = "Pale";
                        break;
                    case "b":
                        SkinColor = "Light";
                        break;
                    case "c":
                        SkinColor = "Medium";
                        break;
                    case "d":
                        SkinColor = "Tan";
                        break;
                    case "e":
                        SkinColor = "Dark";
                        break;
                    case "f":
                        SkinColor = "Deep";
                        break;
                    case "g":
                        SkinColor = "Pale Blue";
                        break;
                    case "h":
                        SkinColor = "Green";
                        break;
                    case "i":
                        SkinColor = "Silver";
                        break;
                    case "j":
                        SkinColor = "Brown";
                        break;
                    case "k":
                        SkinColor = "Purple";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for skin color.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        skinColorInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your eye color?\na. Black\nb. Blue\nc. Green\nd. Red\ne. Gray\nf. Brown\ng. Yellow\nh. Violet\nType the letter of your eye color: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string eyeColorInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (eyeColorInput)
                {
                    case "a":
                        EyeColor = "Black";
                        break;
                    case "b":
                        EyeColor = "Blue";
                        break;
                    case "c":
                        EyeColor = "Green";
                        break;
                    case "d":
                        EyeColor = "Red";
                        break;
                    case "e":
                        EyeColor = "Gray";
                        break;
                    case "f":
                        EyeColor = "Brown";
                        break;
                    case "g":
                        EyeColor = "Yellow";
                        break;
                    case "h":
                        EyeColor = "Violet";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for eye color.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        eyeColorInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat body modifications do you have?\na. Tattoos\nb. Scars\nc. Piercings\nd. Wings\ne. Horns\nf. Tails\ng. Claws\nh. Glowing eyes\ni. Cyber enhancement\nj. None\nType the letter of your body modification: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string bodyModificationInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (bodyModificationInput)
                {
                    case "a":
                        BodyModification = "Tattoos";
                        break;
                    case "b":
                        BodyModification = "Scars";
                        break;
                    case "c":
                        BodyModification = "Piercings";
                        break;
                    case "d":
                        BodyModification = "Wings";
                        break;
                    case "e":
                        BodyModification = "Horns";
                        break;
                    case "f":
                        BodyModification = "Tails";
                        break;
                    case "g":
                        BodyModification = "Claws";
                        break;
                    case "h":
                        BodyModification = "Glowing eyes";
                        break;
                    case "i":
                        BodyModification = "Cyber enhancement";
                        break;
                    case "j":
                        BodyModification = "None";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for body modification.\n");
                        Console.ResetColor ();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        bodyModificationInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your hair style?\na. Short hair\nb. Medium hair\nc. Long hair\nd. Straight hair\ne. Wavy hair\nf. Curly hair\ng. Pony tail\nh. Bald\nType the letter of your hair style: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string hairStyleInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (hairStyleInput)
                {
                    case "a":
                        HairStyle = "Short hair";
                        break;
                    case "b":
                        HairStyle = "Medium hair";
                        break;
                    case "c":
                        HairStyle = "Long hair";
                        break;
                    case "d":
                        HairStyle = "Straight hair";
                        break;
                    case "e":
                        HairStyle = "Wavy hair";
                        break;
                    case "f":
                        HairStyle = "Curly hair";
                        break;
                    case "g":
                        HairStyle = "Pony tail";
                        break;
                    case "h":
                        HairStyle = "Bald";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for hair style.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        hairStyleInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your hair color?\na. Black\nb. Brown\nc. Blonde\nd. Gray\ne. White\nf. Red\ng. Blue\nh. Green\ni. Purple\nj. Pink\nType the letter of your hair color: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string hairColorInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (hairColorInput)
                {
                    case "a":
                        HairColor = "Black";
                        break;
                    case "b":
                        HairColor = "Brown";
                        break;
                    case "c":
                        HairColor = "Blonde";
                        break;
                    case "d":
                        HairColor = "Gray";
                        break;
                    case "e":
                        HairColor = "White";
                        break;
                    case "f":
                        HairColor = "Red";
                        break;
                    case "g":
                        HairColor = "Blue";
                        break;
                    case "h":
                        HairColor = "Green";
                        break;
                    case "i":
                        HairColor = "Purple";
                        break;
                    case "j":
                        HairColor = "Pink";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for hair color.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        hairColorInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your top clothes?\na. T-Shirt\nb. Jacket\nc. Hoodie\nd. Sweater\ne. Blouse\nf. Vest\ng. Armor\nh. Robe\ni. Cape\nj. Leather Jacket\nk. Cloak\nl. Long coat\nm. Corset\nType the letter of your top clothes: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string topClothesInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (topClothesInput)
                {
                    case "a":
                        TopClothes = "T-Shirt";
                        break;
                    case "b":
                        TopClothes = "Jacket";
                        break;
                    case "c":
                        TopClothes = "Hoodie";
                        break;
                    case "d":
                        TopClothes = "Sweater";
                        break;
                    case "e":
                        TopClothes = "Blouse";
                        break;
                    case "f":
                        TopClothes = "Vest";
                        break;
                    case "g":
                        TopClothes = "Armor";
                        break;
                    case "h":
                        TopClothes = "Robe";
                        break;
                    case "i":
                        TopClothes = "Cape";
                        break;
                    case "j":
                        TopClothes = "Leather Jacket";
                        break;
                    case "k":
                        TopClothes = "Cloak";
                        break;
                    case "l":
                        TopClothes = "Long coat";
                        break;
                    case "m":
                        TopClothes = "Corset";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for top clothes.\n");
                        Console.ResetColor ();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        topClothesInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your bottom pants?\na. Jeans\nb. Shorts\nc. Trousers\nd. Cargo pants\ne. Armor\nf. Skirt\ng. Jumpsuit bottom\nType the letter of your bottom pants: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string bottomPantsInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (bottomPantsInput)
                {
                    case "a":
                        BottomPants = "Jeans";
                        break;
                    case "b":
                        BottomPants = "Shorts";
                        break;
                    case "c":
                        BottomPants = "Trousers";
                        break;
                    case "d":
                        BottomPants = "Cargo pants";
                        break;
                    case "e":
                        BottomPants = "Armor";
                        break;
                    case "f":
                        BottomPants = "Skirt";
                        break;
                    case "g":
                        BottomPants = "Jumpsuit bottom";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter a valid letter for bottom pants.\n");
                        Console.ResetColor(); 
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        bottomPantsInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));

            Console.Write("\nDo you want to have a sidekick? (a for yes, b for no): ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string sidekickInput = Console.ReadLine()?.ToLower();
            Console.ResetColor();

            while (true)
            {
                if (sidekickInput == "a")
                {
                    HasSidekick = true;
                    break;
                }
                else if (sidekickInput == "b")
                {
                    HasSidekick = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Please enter 'a' or 'b'.\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    sidekickInput = Console.ReadLine().ToLower();
                    Console.ResetColor();
                }
            }
            Console.WriteLine($"Sidekick selected: {(HasSidekick)}");

            Console.WriteLine();
            Console.WriteLine(new string('-', 24));
            Console.ForegroundColor = ConsoleColor.Blue;   
            Console.WriteLine("\n--- CHARACTER POWERS ---\n");
            Console.ResetColor();
            
            Console.Write("\nWhat is your main power?\na. Super Strength\nb. Invisibility\nc. Telekinesis\nd. Super Speed\ne. Shape-shifter\nf. Cloning\ng. Chronobreak\nh. Titan Shifter\ni. Za Warudo\nj. Dragon shout\nType the letter of your main power: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string mainPowerInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (mainPowerInput)
                {
                    case "a":
                        MainPower = "Super Strength";
                        break;
                    case "b":
                        MainPower = "Invisibility";
                        break;
                    case "c":
                        MainPower = "Telekinesis";
                        break;
                    case "d":
                        MainPower = "Super Speed";
                        break;
                    case "e":
                        MainPower = "Shape-shifter";
                        break;
                    case "f":
                        MainPower = "Cloning";
                        break;
                    case "g":
                        MainPower = "Chronobreak";
                        break;
                    case "h":
                        MainPower = "Titan Shifter";
                        break;
                    case "i":
                        MainPower = "Za Warudo";
                        break;
                    case "j":
                        MainPower = "Dragon shout";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', or 'j'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        mainPowerInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your secondary power?\na. Vampirism\nb. Barrier\nc. Silent Step\nd. Dash\ne. Enhanced senses\nf. Flight\ng. Slow time\nh. Wall Climbing\nType the letter of your secondary power: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string secondaryPowerInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (secondaryPowerInput)
                {
                    case "a":
                        SecondaryPower = "Vampirism";
                        break;
                    case "b":
                        SecondaryPower = "Barrier";
                        break;
                    case "c":
                        SecondaryPower = "Silent Step";
                        break;
                    case "d":
                        SecondaryPower = "Dash";
                        break;
                    case "e":
                        SecondaryPower = "Enhanced senses";
                        break;
                    case "f":
                        SecondaryPower = "Flight";
                        break;
                    case "g":
                        SecondaryPower = "Slow time";
                        break;
                    case "h":
                        SecondaryPower = "Wall Climbing";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', 'd', 'e', 'f', 'g', or 'h'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        secondaryPowerInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 24));
            Console.Write("\nWhat is your elemental orb?\na. Fire (Physical buff)\nb. Water (Mana Regeneration)\nc. Wind (Movement Speed)\nd. Earth (Health Regeneration)\nType the letter of your elemental orb: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string elementalOrbInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            while (true)
            {
                switch (elementalOrbInput)
                {
                    case "a":
                        ElementalOrb = "Fire (Physical buff)";
                        break;
                    case "b":
                        ElementalOrb = "Water (Mana Regeneration)";
                        break;
                    case "c":
                        ElementalOrb = "Wind (Movement Speed)";
                        break;
                    case "d":
                        ElementalOrb = "Earth (Health Regeneration)";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection. Please enter 'a', 'b', 'c', or 'd'.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        elementalOrbInput = Console.ReadLine().ToLower();
                        Console.ResetColor();
                        continue;
                }
                break;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("\n--- ATTRIBUTES ---\n");
            Console.ResetColor();

            Console.WriteLine("Strength");
            Console.WriteLine("Vitality");
            Console.WriteLine("Energy (Mana)");
            Console.WriteLine("Attack");
            Console.WriteLine("Agility");
            Console.WriteLine("Defense");
            Console.WriteLine("Luck");
            Console.WriteLine("Intelligence");
            Console.WriteLine();

        }

        public void AllocateAttributes()
        {
            int pointsRemaining = 20;

            Strength = AllocatePoints("Strength", pointsRemaining);
            pointsRemaining -= Strength;
            

            Vitality = AllocatePoints("Vitality", pointsRemaining);
            pointsRemaining -= Vitality;

            Energy = AllocatePoints("Energy", pointsRemaining);
            pointsRemaining -= Energy;

            Attack = AllocatePoints("Attack", pointsRemaining);
            pointsRemaining -= Attack;

            Agility = AllocatePoints("Agility", pointsRemaining);
            pointsRemaining -= Agility;

            Defense = AllocatePoints("Defense", pointsRemaining);
            pointsRemaining -= Defense;

            Luck = AllocatePoints("Luck", pointsRemaining);
            pointsRemaining -= Luck;

            Intelligence = AllocatePoints("Intelligence", pointsRemaining);
            pointsRemaining -= Intelligence;
        }

        private int AllocatePoints(string attributeName, int pointsRemaining)
        {
            int allocatedPoints = 0;

            Console.WriteLine(new string('-', 24));
            Console.WriteLine("\n--- ATTRIBUTES ---\nYou have " + pointsRemaining + " points remaining to allocate to each attribute\nYou only have a maximum of five (5) to allocate each attribute");

            while (true)
            {
                Console.Write(attributeName + " (Max 5): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (int.TryParse(Console.ReadLine(), out allocatedPoints) && allocatedPoints <= 5 && allocatedPoints <= pointsRemaining && allocatedPoints >= 0)
                {
                    Console.ResetColor();
                    return allocatedPoints;
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. You can allocate a maximum of 5 points to " + attributeName + " and you have " + pointsRemaining + " points remaining.");
                    Console.ResetColor(); 
                }
            }
        }

        public override void DisplayCharacterDetails()
        {
            Console.WriteLine(new string('-', 24));
            Console.WriteLine("\n\n\nCharacter Created!\n\n");
            Console.WriteLine("Your character has the following details:\n");
            Console.WriteLine("Name:\t\t\t" + UName);
            Console.WriteLine("Moral Alignment:\t" + HOV);
            Console.WriteLine("Gender:\t\t\t" + Gender);
            Console.WriteLine("Race:\t\t\t" + Race);
            Console.WriteLine("Height:\t\t\t" + Attributes.Height);
            Console.WriteLine("Weight:\t\t\t" + Attributes.Weight);
            Console.WriteLine("Age:\t\t\t" + Age);
            Console.WriteLine("Build:\t\t\t" + Attributes.Build);
            Console.WriteLine("Skin Color:\t\t" + SkinColor);
            Console.WriteLine("Eye Color:\t\t" + EyeColor);
            Console.WriteLine("Body Modification\t" + BodyModification);
            Console.WriteLine("Hair Style\t\t" + HairStyle);
            Console.WriteLine("Hair Color\t\t" + HairColor);
            Console.WriteLine("Top Clothes:\t\t" + TopClothes);
            Console.WriteLine("Bottom Pants:\t\t" + BottomPants);
            Console.WriteLine("Has Sidekick:\t\t" + HasSidekick);
            Console.WriteLine("\n\t--- CHARACTER POWERS ---\n");
            Console.WriteLine("Main Power:\t\t" + MainPower);
            Console.WriteLine("Secondary Power:\t" + SecondaryPower);
            Console.WriteLine("Elemental Orb:\t\t" + ElementalOrb);
            Console.WriteLine("\n\t --- ATTRIBUTES ---\n");
            Console.WriteLine("Strength:\t\t" + Strength);
            Console.WriteLine("Vitality:\t\t" + Vitality);
            Console.WriteLine("Energy (Mana): \t\t" + Energy);
            Console.WriteLine("Attack:\t\t\t" + Attack);
            Console.WriteLine("Agility:\t\t" + Agility);
            Console.WriteLine("Defense:\t\t" + Defense);
            Console.WriteLine("Luck:\t\t\t" + Luck);
            Console.WriteLine("Intelligence:\t\t" + Intelligence);
            Console.WriteLine("\n\n\n");

            HeroDatabase heroDb = new HeroDatabase();
            try
            {
                CharacterCreate hero = new CharacterCreate(UName, HOV, Gender, Race);
                hero.CharacterCreation(UName, HOV, Gender, Race, Age, SkinColor, EyeColor, BodyModification, HairStyle, HairColor, TopClothes, BottomPants, HasSidekick, MainPower, SecondaryPower, ElementalOrb, Strength, Vitality, Energy, Attack, Agility, Defense, Luck, Intelligence);
                hero.SetPhysicalAttributes(Attributes.Height, Attributes.Weight, Attributes.Build);
                heroDb.InsertHero(name, HoV, gender, race, Attributes.Height, Attributes.Weight, Attributes.Build, age, skinColor, eyeColor, bodyModification, hairStyle, hairColor,
                topClothes, bottomPants, hasSidekick, mainPower, secondaryPower,
                elementalOrb, strength, vitality, energy, attack, agility,
                defense, luck, intelligence);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
        }
    }
}