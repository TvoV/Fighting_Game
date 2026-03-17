namespace IT0125.OOP;

public class Krieger : Charakter
{
    public override void angriff()
    {
        Console.WriteLine($"{name} slashes his broadsword!");
    }

    public override void sangriff()
    {
        Console.WriteLine($"{name} releases a flurry of blows!");
    }
    
    public override int baseattack()
    {
        int dmg = random.Next(10,15) + 1;
        return dmg;
    }
    
    public override int specialattack()
    {
        int dmg = 0;
        int hit = random.Next(0, 100) + 1;
        if (hit < 10)
        {
            dmg = random.Next(20,40) + 1;
            Console.WriteLine("Critical hit!");
            return dmg;
        }
        if (hit < 66)
        {
            dmg = random.Next(15,30) + 1;
            return dmg;
        }
        Console.WriteLine("Attack has missed!");
        return dmg;
    }
    
    public Krieger(string name, int level, int lebenspunkte) : base(name,level,lebenspunkte) {}
}