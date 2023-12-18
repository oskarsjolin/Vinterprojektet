public class Player : Character //Player classen ärver också från Character klassen
{
    public Player(string name, int health, int damage) : base(name, health, damage)
    {
    }

    public override void Attack(Character target, int accuracy)
    {
        base.Attack(target, accuracy);
    }

    public void Heal()
    {
        int healingAmount = 20;

        // Gör så att spelarens liv inte går över 100
        if (Health + healingAmount > 100)
        {
            healingAmount = 100 - Health;
        }

        Health += healingAmount;
        Console.WriteLine($"{Name} läker {healingAmount} hp!");
        Console.WriteLine($"{Name} har nu {Health} hp.\n");
    }
}
