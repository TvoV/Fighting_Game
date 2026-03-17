namespace IT0125.OOP;

public class Schurke : Charakter
{
    public override void angriff()
    {
        Console.WriteLine($"{name} throws a Dagger!");
    }
    
    public override void sangriff()
    {
        Console.WriteLine($"{name} uses sneak attack!");
    }
    
    public override int baseattack()
    {
        int dmg = random.Next(5,10) + 1;
        return dmg;
    }
    
    public override int specialattack()
    {
        int dmg = 0;
        int hit = random.Next(0, 100) + 1;
        if (hit < 20)
        {
            dmg = random.Next(40,65) + 1;
            Console.WriteLine("Critical hit!");
            return dmg;
        }
        if (hit < 75)
        {
            dmg = random.Next(20,40) + 1;
            return dmg;
        }
        Console.WriteLine("Attack has missed!");
        return dmg;
    }

    public Schurke(string name, int level, int lebenspunkte) : base(name,level,lebenspunkte) {}
}