var random = new Random();
Player player1 = new Player();
Player player2 = new Player();

string[] names = { "grebert", "haribo", "fernando", "bög", "feffe", "horunge", "mexikan", "kines", "porrlangare", "micke b", "chipspåse", "pedofil" };
player2.name = names[random.Next(0, names.Count())];


//Weapons with their minimum damage, maximum damage and chance to hit in %
object[][] weapons = {
    new object[] {"Fists", 10, 30, 100},
    new object[] {"Sword", 30, 40, 70},
    new object[] {"Gun", 60, 80, 30},
    new object[] {"osthyvel", 30, 60, 50},
    new object[] {"kaktus", 40, 60, 70},
    new object[] {"RPG", 101, 1000, 100},
    new object[] {"stekpanna", 40, 60, 60},
    new object[] {"olw sourcream & onion chips", 30, 60, 80},
    new object[] {"inga käder", 30, 40, 100}
};


Console.WriteLine("Input your name");
player1.name = Console.ReadLine().Trim();
if (string.IsNullOrEmpty(player1.name))
{
    player1.name = "Player 1";
}


void selectWeapon(Player player)
{
    Console.WriteLine("\n");
    //Prints the name of every weapon in order as well as its damage range and hit chance
    for (int h = 0; h <= weapons.Count() - 1; h++)
    {
        Console.WriteLine($"{h + 1}: {weapons[h][0]} - Damage: {weapons[h][1]}-{weapons[h][2]}, {weapons[h][3]}% Hit chance");
    }

    Console.WriteLine("(Type anything else or nothing to select a random weapon)");

    string tempWeapon;

    tempWeapon = Console.ReadLine().Trim();

    //Forces player to type only one number
    if (tempWeapon.Length <= 1 && int.TryParse(tempWeapon, out int i))
    {
        player.weapon = Convert.ToInt32(tempWeapon);
        if (player.weapon <= weapons.Count() && player.weapon >= 1)
        {
            player.weapon -= 1;
            Console.WriteLine($"Weapon Selected: {weapons[player.weapon][0]}");
        }
        else
        {
            Console.WriteLine("\nThat weapon does not exist, try again");
            selectWeapon(player);
        }
    }
    else if (int.TryParse(tempWeapon, out int result) && Convert.ToInt32(tempWeapon) <= 0)
    {
        Console.WriteLine("That weapon does not exist, try again");
        selectWeapon(player);
    }
    else if (string.IsNullOrWhiteSpace(tempWeapon) || tempWeapon is string)
    {
        int randomWeapon = random.Next(0, weapons.Count());
        player.weapon = randomWeapon;
        Console.WriteLine($"\nRandom Weapon Selected: {weapons[player.weapon][0]}");
    }
}


void attack(Player attacker, Player target)
{
    //Array with sentences to be displayed when attacking. Each weapon has its own uniqe sentences and they are chosen randomly
    string[][] attackMsg = {
        new string[] {$"{attacker.name} slår sönder {target.name}s pungkulor", $"{attacker.name} stoppar upp sina knogar i {target.name}s rövhål", $"{attacker.name} drar av {target.name}s penis och äter upp den"},
        new string[] {$"{attacker.name} kastrerar {target.name} med sitt coola svärd", $"{attacker.name} kör upp svärdet i {target.name}s feta rumpa"},
        new string[] {$"{attacker.name} skjuter {target.name} i rövhålet", $"{attacker.name} låtsas skjuta sig själv i huvudet ({target.name} har ett stort crush på hen och blir jätte ledsen)"},
        new string[] {$"{attacker.name} hyvlar sönder {target.name}s skinkor", $"{attacker.name} gör skidbacke i {target.name}s ost"},
        new string[] {$"{attacker.name} kör upp sin kaktus i {target.name}s rövhål", $"{attacker.name} gnuggar kaktusen på {target.name}s arm (det gör ont :())"},
        new string[] {$"{attacker.name} skjuter en raket upp i {target.name}s rövhål", $"{attacker.name} låtsas skjuta {target.name} (hen blir rädd och springer hem)"},
        new string[] {$"{attacker.name} steker {target.name}s bollar", $"{attacker.name} slår {target.name} i ansiktet med stekpannan"},
        new string[] {$"{attacker.name} smaskar på chips riktigt högt framför {target.name}", $"{attacker.name} bjuder {target.name} på chips (de är äckliga)", $"{attacker.name} biter av {target.name}s snopp och gör en smarrig dipp av den"},
        new string[] {$"{attacker.name} visar sin lilla pillesnopp för {target.name} ({target.name} skrattar ihjäl sig)", $"{attacker.name} går till en lekpark utan kläder????? {target.name} är chockad"}
    };


    if (attacker == player1)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }


    int damage;
    int hitChance = random.Next(0, 100);

    //Prints a random funny sentence from the array of the players chosen weapon
    Console.Write($"{attackMsg[attacker.weapon][random.Next(0, attackMsg[attacker.weapon].Count())]}");

    //If the randomly generated hit chance is higher than the hit% of the weapon then print "missed"
    if (hitChance > Convert.ToInt32(weapons[attacker.weapon][3]))
    {
        Console.Write($"\n{attacker.name} missed!");
        Console.ReadLine();
    }
    else
    {
        //Selects a random amount of damage between the weapons minimum and maximum damage
        damage = random.Next(Convert.ToInt32(weapons[attacker.weapon][1]), Convert.ToInt32(weapons[attacker.weapon][2]));
        target.hp -= damage;

        Console.Write($"\n{attacker.name} hit their attack! {damage} damage");
        Console.ReadLine();
    }

    if (target.hp < 1)
    {
        target.dead = true;
    }
}


//Promts player to select a weapon
Console.WriteLine("\nSelect a weapon by typing the corresponding number:");
selectWeapon(player1);

Console.WriteLine("\nSelect a weapon for your enemy:");
selectWeapon(player2);

//Starts game
do
{
    Console.ForegroundColor = ConsoleColor.Gray;

    //Player 1 attack
    if (player1.dead == false && player2.dead == false)
    {
        Console.WriteLine($"\n{player1.name} HP: {player1.hp}  |  {player2.name} HP: {player2.hp}");
        Console.ReadLine();
        attack(player1, player2);
    }

    //Player 2 attack
    if (player1.dead == false && player2.dead == false)
    {
        Console.WriteLine($"\n{player1.name} HP: {player1.hp}  |  {player2.name} HP: {player2.hp}");
        Console.ReadLine();
        attack(player2, player1);
    }
} while (player1.hp >= 0 && player2.hp >= 0);


if (player1.hp <= 0)
{
    Console.WriteLine($"\n{player1.name} died \nYou lost!");
}
else
{
    Console.WriteLine($"\n{player2.name} died \nYou won!");
}

Console.ReadLine();


public class Player
{
    public string name;
    public int hp = 100;
    public bool dead = false;
    public int weapon;
}