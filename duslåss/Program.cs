var random = new Random();
Player player1 = new Player();
Player player2 = new Player();

player2.name = "jeff";
player2.weapon = 0;


//Weapons with their minimum damage, maximum damage and chance to hit in %
object[][] weapons = {
        new object[] {"Fists", 10, 30, 100},
        new object[] {"Sword", 30, 40, 70},
        new object[] {"Gun", 60, 80, 30},
        new object[] {"osthyvel", 30, 60, 50},
        new object[] {"kaktus", 40, 60, 70},
        new object[] {"RPG", 101, 1000, 100}
    };


Console.WriteLine("Input your name");
player1.name = Console.ReadLine().Trim();
if (string.IsNullOrEmpty(player1.name))
{
    player1.name = "Player 1";
}


void selectWeapon(Player player)
{
    //Prints the name of every weapon in order as well as its damage range and hit chance
    for (int h = 0; h <= weapons.Count() - 1; h++)
    {
        Console.WriteLine($"{h + 1}: {weapons[h][0]} - Damage: {weapons[h][1]}-{weapons[h][2]}, {weapons[h][3]}% Hit chance");
    }

    Console.WriteLine("(Leave empty to select a random weapon)");

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
            Console.WriteLine("Type only one number");
            selectWeapon(player);
        }
    }
    else if(string.IsNullOrWhiteSpace(tempWeapon)){
        int randomWeapon = random.Next(0, weapons.Count());
        player.weapon = randomWeapon;
        Console.WriteLine($"\nWeapon Selected: {weapons[player.weapon][0]}");
    }
}



void attack(Player attacker, Player target)
{
    int damage;
    int hitChance = random.Next(0, 100);

    Console.WriteLine($"{attacker.name} Attacks!");

    //If the randomly generated hit chance is higher than the hit% of the weapon then print "missed"
    if (hitChance > Convert.ToInt32(weapons[attacker.weapon][3])){
        Console.WriteLine($"{attacker.name} missed!");
    }
    else{
        //Selects a random amount of damage between the weapons minimum and maximum damage
        damage = random.Next(Convert.ToInt32(weapons[attacker.weapon][1]), Convert.ToInt32(weapons[attacker.weapon][2]));
        target.hp -= damage;

        Console.WriteLine($"\n{attacker.name} hit their attack! {damage} damage");
        Console.ReadLine();
    }

    if (target.hp < 1){
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
    Console.WriteLine($"You lost!");
}
else
{
    Console.WriteLine($"You won!");
}

Console.ReadLine();


public class Player
{
    public string name;
    public int hp = 100;
    public bool dead = false;
    public int weapon;
}