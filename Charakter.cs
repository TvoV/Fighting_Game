namespace IT0125.OOP;

public class Charakter
{

    public static Random random = new Random();

    public string name = "";
    public int level = 0;
    public int lebenspunkte = 0;
    public int starthp = 0;
    public int restleben;

    public virtual void angriff()
    {
        Console.WriteLine("Der Charakter greift an!");
    }

    public virtual void sangriff()
    {
        Console.WriteLine("Der Charakter greift besonders an!");
    }

    public Charakter(string name, int level, int lebenspunkte)
    {
        this.name = name;
        this.level = level;
        this.lebenspunkte = lebenspunkte;
        this.starthp = lebenspunkte;
    }

    public void reset()
    {
        lebenspunkte = starthp;
    }

    public virtual int baseattack()
    {
        int dmg = random.Next(15,20) + 1;
        return dmg;
    }
    
    public virtual int specialattack()
    {
        int dmg = 0;
        int hit = random.Next(0, 100) + 1;
        if (hit < 66)
        {
            dmg = random.Next(30,40) + 1;
            return dmg;
        }
        Console.WriteLine("Attack has missed!");
        return dmg;
    }
    
    public int pickattack()
    {
        return random.Next(2) + 1;
    }
    
    public int pickcharakter()
    {
        return random.Next(3) + 1;
    }
}