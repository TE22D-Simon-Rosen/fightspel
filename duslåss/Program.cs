var random = new Random();
int p1HP = 100;
int p2HP = 100;

string name;
string name2 = "jeff";


Console.WriteLine("Input your name");
name = Console.ReadLine().Trim();
if (string.IsNullOrEmpty(name)){
    name = "Player 1";
}


Console.WriteLine("Press Enter to contine");

void startRound(){
    int damage;

    Console.WriteLine($"{name} HP - {p1HP}  |  {name2} HP - {p2HP}");
    Console.ReadLine();

    Console.WriteLine($"{name} Attacks!");
    Console.ReadLine();


    damage = random.Next(10, 25);
    p2HP -= damage;

    Console.WriteLine($"");
    
}