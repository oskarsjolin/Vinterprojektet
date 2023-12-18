using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Välkommen till det stora slagsmålsspelet!");
        Console.WriteLine("\nDu är en hjälte som möter ett mäktigt monster.");
        System.Console.WriteLine("\nDitt mål är att besegra monstret med 150hp, Lycka till!");
        //Instruktioner till spelaren

        Player player = new Player("Hjälte", 100, 20);
        Enemy enemy = new Enemy("Monstret", 150, 15);

        Console.WriteLine($"Din {player.Name} har {player.Health} hp.");
        Console.WriteLine($"{enemy.Name} har {enemy.Health} hp.\n");

        Console.WriteLine("Låt striden börja!");
// när spelaren och monstret är vid liv
while (player.Health > 0 && enemy.Health > 0)
{
    Console.WriteLine("Välj vad du ska göra attack:");
    Console.WriteLine("1. Standard Attack (80% träffsäkerhet)");
    Console.WriteLine("2. Special Attack (50% träffsäkerhet)");
    Console.WriteLine("3. Heala (100% träffsäkerhet)");
    // de olika attackerna


    int choice;

    if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
    {
        Console.WriteLine("Fel input. Försök igen.");
        // Skippa resten av loopen vid invalid input
        continue;
    }

    switch (choice) // spelarens attacker
    {
        case 1:
            player.Attack(enemy, 80);
            break;
        case 2:
            player.Attack(enemy, 50);
            break;
        case 3:
            player.Heal();
            break;
        default:
            Console.WriteLine("Fel val. Försök igen.");
            break;
    }

    // Kolla om monstret är besegrat
    if (enemy.Health <= 0)
    {
        Console.WriteLine($"Grattis! Du besegrade {enemy.Name}!");
        break;
    }

    // Monstrets attacker
    enemy.Attack(player, 70); // Monstrets attack har 70% träffsäkerhet

    // Gör så att spelaren inte kan ha mer än 100hp
    if (player.Health > 100)
    {
        player.Health = 100;
        Console.WriteLine($"{player.Name}s liv är maximum 100hp.\n");
    }

    // Kolla om hjälten är besegrad
    if (player.Health <= 0)
    {
        Console.WriteLine($"Game over! {enemy.Name} besegrade dig.");
        break;
    }
}

        Console.ReadLine(); 
    }

    static int GetPlayerChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Fel input. Var snäll och skriv ett nummer.");
        }
        return choice; 
    }
}
