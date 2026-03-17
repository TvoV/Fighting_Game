namespace IT0125.OOP;

public class Magier : Charakter
{
    public override void angriff()
    {
        Console.WriteLine($"{name} cast Magic Missle!");
    }
    
    public override void sangriff()
    {
        Console.WriteLine($"{name} casts Fireball!");
    }
    
    public override int baseattack()
    {
        int dmg = random.Next(5,20) + 1;
        return dmg;
    }
    
    public override int specialattack()
    {
        int dmg = 0;
        int hit = random.Next(0, 100) + 1;
        if (hit < 10)
        {
            dmg = random.Next(50,100) + 1;
            Console.WriteLine("Critical hit!");
            return dmg;
        }
        if (hit < 50)
        {
            dmg = random.Next(30,60) + 1;
            return dmg;
        }
        Console.WriteLine("Attack has missed!");
        return dmg;
    }
    public Magier(string name, int level, int lebenspunkte) : base(name,level,lebenspunkte) {}
}