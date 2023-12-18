using System;

public class Character
{
    public string Name { get; set; } // namn, hp och skada
    public int Health { get; set; }
    public int Damage { get; set; }

    protected Character(string name, int health, int damage) //karaktärernas egenskaper
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public virtual void Attack(Character target, int accuracy)
    {
        Random random = new Random();
        int chance = random.Next(1, 101); // Random nummer mellan 1 och 100

        if (chance <= accuracy) // ifall attacken träffar 
        {
            Console.WriteLine($"{Name} attackerar {target.Name} och ger {Damage} skada!");
            target.Health -= Damage;
        }
        else
        {
            Console.WriteLine($"{Name}s attack missade!\n"); // om den missar
        }

        Console.WriteLine($"{target.Name} har {target.Health} liv kvar.\n"); // för att den ska skriva ut livet
    }
}
