
class CharacterGenerator
{
    static void Main(string[] args)
{
    Console.WriteLine("Fantasy Character Generator");
    Console.WriteLine("-------------------------------------------------------------------------------");


    Console.Write("Choose race (t.ex. Human, Elf, Dwarf, Orc, Halfling, Dragonborn, Siren, Elemental, Ent, Tiefling, Coralorak): ");
        string userRace = Console.ReadLine().ToUpper();

    Console.Write("Choose class (t.ex. Warrior, Mage, Rogue, Cleric, Barbarian, Bard, Druid, Ranger,): ");
        string userClass = Console.ReadLine().ToUpper();

    Console.WriteLine("\nGenerating charakter...");

    Random random = new Random();

    string[] races = { "Human", "Elf", "Dwarf", "Orc", "Halfling", "Dragonborn", "Siren", "Elemental", "Ent", "Tiefling", "Coralorak" };
    string[] weapons = { "Sword", "Staff", "Bow", "Dagger", "Crossbow", "Longsword", "Mace", "Rapier", "Axe", "Bow", };
    string[] armorTypes = { "Plate", "Leather", "Chainmail", "Robes", "Heavy plate", };

    var ageRanges = new Dictionary<string, Tuple<int, int>>
        {
            {"Human", Tuple.Create(15, 100) },
            {"Elf", Tuple.Create(100, 750) },
            {"Dwarf", Tuple.Create(30, 250) },
            {"Orc", Tuple.Create(10, 80) },
            {"Halfling", Tuple.Create(20, 150) },
            {"Dragonborn", Tuple.Create(15, 80) },
            {"Siren", Tuple.Create(18, 300) },
            {"Elemental", Tuple.Create(50, 1000) },
            {"ENT", Tuple.Create(100, 2000) },
            {"Tiefling", Tuple.Create(20, 150) },
            {"Coralorak", Tuple.Create(1, 7) }
        };

    var classes = new Dictionary<string, string[]>
        {
            {"Warrior", new string[]{"Sword", "Axe", "Mace", "Rapier", "Dagger", "Sheild","Longsword"}},
            {"Mage", new string[]{"Staff", "Dagger", "Magic orb",}},
            {"Rogue", new string[]{"Dagger", "Rapier", "Bow", "Crossbow"}},
            {"Cleric", new string[]{"Mace", "Staff"}},
            {"Barbarian", new string[]{"Axe", "Sword", "Mace",}},
            {"BARD", new string []{"Dagger", "Rapier"}},
            {"Druid", new string []{"Bow", "Staff"} },
            {"Ranger", new string []{"Bow", "Crossbow"} },
        };

    var armorOptions = new Dictionary<string, string[]>
        {
            {"Mage", new string[] {"Robes"} },
            {"Warriror", new string [] {"Plate", "Plate", "Heavy plate" } },
            {"Rouge", new string [] {"Leather"} },
            {"Cleric", new string [] {"Robes", "Chainmail"} },
            {"Barbarian", new string [] {"Chainmail", "Leather"} },
            {"BARD",new string [] {"Leather"} },
            {"Druid", new string [] { "Leather" } },
            {"Ranger", new string [] { "Leather"} },
        };

    string race = userRace.Trim() != "" ? userRace : races[random.Next(races.Length)];
    string characterClass = userClass.Trim() != "" ? userClass : classes.Keys.ToArray()[random.Next(classes.Count)];
    string[] availableWeapons = classes[characterClass];
    string weapon = availableWeapons[random.Next(availableWeapons.Length)];
    string[] availableArmorTypes = armorOptions.ContainsKey(characterClass) ? armorOptions[characterClass] : armorTypes;
    string armorType = availableArmorTypes[random.Next(availableArmorTypes.Length)];

    int minAge = ageRanges[race].Item1;
    int maxAge = ageRanges[race].Item2;
    int age = random.Next(minAge, maxAge + 1);

    Console.WriteLine("\nGenererad karaktär:");
    Console.WriteLine("Race: " + race);
    Console.WriteLine("Class: " + characterClass);
    Console.WriteLine("Weapon: " + weapon);
    Console.WriteLine("Armor: " + armorType);
    Console.WriteLine("Age: " + age);
}
}
