var random = new Random();
Player player1 = new Player();
Player player2 = new Player();

player2.name = "jeff";

Console.WriteLine("Input your name");
player1.name = Console.ReadLine().Trim();
if (string.IsNullOrEmpty(player1.name))
{
    player1.name = "Player 1";
}


Console.WriteLine("Press Enter to contine");


void attack(Player attacker, Player target)
{
    int damage;

    Console.WriteLine($"{attacker.name} Attacks!");

    damage = random.Next(20, 50);
    target.hp -= damage;

    Console.WriteLine($"\n{attacker.name} did {damage} damage to {target.name}!");
    Console.ReadLine();

    if (target.hp <= 0)
    {
        target.dead = true;
    }
}


do
{
    if (player1.dead == false && player2.dead == false)
    {
        Console.WriteLine($"\n{player1.name} HP: {player1.hp}  |  {player2.name} HP: {player2.hp}");
        Console.ReadLine();
        attack(player1, player2);
    }

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
}