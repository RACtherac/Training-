using System;
using System.Collections.Generic;
using System.IO;

class CharacterGenerator
{
    static Random random = new Random();
    static string filePath = "FantasyCharacter.txt";

    static void Main(string[] args)
    {
        Console.WriteLine("Fantasy Character Generator");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine("Choose race depending on the number next to it:");
        for (int i = 0; i < races.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {races[i]}");
        }
        Console.Write("Pick the number next to the race: ");
        int raceChoice;
        while (!int.TryParse(Console.ReadLine(), out raceChoice) || raceChoice < 1 || raceChoice > races.Length)
        {
            Console.WriteLine("Invalid input. Please enter a number corresponding to the race.");
            Console.Write("Pick the number next to the race: ");
        }
        string race = races[raceChoice - 1];

        Console.WriteLine("\nChoose class depending on the number next to it:");
        for (int i = 0; i < classes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {classes[i]}");
        }
        Console.Write("Pick the number next to the class: ");
        int classChoice;
        while (!int.TryParse(Console.ReadLine(), out classChoice) || classChoice < 1 || classChoice > classes.Length)
        {
            Console.WriteLine("Invalid input. Please enter a number corresponding to the class.");
            Console.Write("Pick the number next to the class: ");
        }
        string characterClass = classes[classChoice - 1];

        string[] availableWeapons = classWeapons[characterClass];
        string weapon = availableWeapons[random.Next(availableWeapons.Length)];

        string[] availableArmor = armorOptions[characterClass];
        string armor = availableArmor[random.Next(availableArmor.Length)];

        int minAge = ageRanges[race].Item1;
        int maxAge = ageRanges[race].Item2;
        int age = random.Next(minAge, maxAge + 1);

        Console.WriteLine("\nGenerated character:");
        Console.WriteLine("Race: " + race);
        Console.WriteLine("Class: " + characterClass);
        Console.WriteLine("Weapon: " + weapon);
        Console.WriteLine("Armor: " + armor);
        Console.WriteLine("Age: " + age);

        string userName = Environment.UserName;
        string filePath = $@"C:\Users\{userName}\Documents\program\FantasyCharacter.txt";

        try
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Race: " + race);
                sw.WriteLine("Class: " + characterClass);
                sw.WriteLine("Weapon: " + weapon);
                sw.WriteLine("Armor: " + armor);
                sw.WriteLine("Age: " + age);
                sw.WriteLine("_______________________________");
            }
            Console.WriteLine($"Character details saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
        }

    }

    static string[] races = { "Aarakocra", "Centaur", "Changeling", "Coralorak", "Dragonborn", "Dwarf", "Elemental", "Elf", "Ent", "Gnome", "Goblin", "Halfling", "Half-Elf", "Half-Orc", "Human", "Orc", "Siren", "Tiefling" };
    static string[] classes = { "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Mage", "Monk", "Paladin", "Ranger", "Rogue", "Warrior", "Warlock" };

    static Dictionary<string, Tuple<int, int>> ageRanges = new Dictionary<string, Tuple<int, int>>
    {
        {"Aarakocra", Tuple.Create(3, 30) },
        {"Centaur", Tuple.Create(16, 60) },
        {"Changeling", Tuple.Create(15, 110) },
        {"Coralorak", Tuple.Create(1, 7) },
        {"Dragonborn", Tuple.Create(15, 80) },
        {"Dwarf", Tuple.Create(30, 250) },
        {"Elemental", Tuple.Create(50, 1000) },
        {"Elf", Tuple.Create(100, 750) },
        {"Ent", Tuple.Create(100, 2000) },
        {"Goblin", Tuple.Create(8, 60) },
        {"Halfling", Tuple.Create(20, 150) },
        {"Human", Tuple.Create(15, 100) },
        {"Half-Elf", Tuple.Create(20, 180) },
        {"Half-Orc", Tuple.Create(14, 75) },
        {"Gnome", Tuple.Create(40, 500) },
        {"Orc", Tuple.Create(10, 80) },
        {"Siren", Tuple.Create(18, 300) },
        {"Tiefling", Tuple.Create(20, 150) }
    };

    static Dictionary<string, string[]> classWeapons = new Dictionary<string, string[]>
    {
        {"Warrior", new string[]{"Sword", "Axe", "Mace", "Rapier", "Dagger", "Shield","Longsword"}},
        {"Mage", new string[]{"Staff", "Dagger", "Magic orb"}},
        {"Rogue", new string[]{"Dagger", "Rapier", "Bow", "Crossbow"}},
        {"Cleric", new string[]{"Mace", "Staff"}},
        {"Barbarian", new string[]{"Axe", "Sword", "Mace","Fist",}},
        {"Bard", new string []{"Dagger", "Rapier"}},
        {"Druid", new string []{"Bow", "Staff"}},
        {"Ranger", new string []{"Bow", "Crossbow"}},
        {"Monk", new string []{"Fist",} },
        {"Paladin",new string []{"Sword",} },
        {"Warlock",new string[] {"Crossbow","Hand axe","Dagger",} },
        {"Artificer", new string[] {"Sheild","Crossbow",""} }
    };

    static Dictionary<string, string[]> armorOptions = new Dictionary<string, string[]>
    {
        {"Mage", new string[] {"Robes"} },
        {"Warrior", new string [] {"Plate", "Plate", "Heavy plate" } },
        {"Rogue", new string [] {"Leather"} },
        {"Cleric", new string [] {"Robes", "Chainmail"} },
        {"Barbarian", new string [] {"Chainmail", "Leather"} },
        {"Bard", new string [] {"Leather"} },
        {"Druid", new string [] { "Leather" } },
        {"Ranger", new string [] { "Leather"} },
        {"Monk",new string []{"Robes","Leather",} },
        {"Paladin",new string []{"Chainmail","Plate","Heavy plate",} },
        {"Warlock",new string[] {"Leather","Robes"} },
        {"Artificer", new string[] {"Leather","Chainmail"} }
    };

}
