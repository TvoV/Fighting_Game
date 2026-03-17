using IT0125.OOP;

namespace Fighting_Game;

public class Fighting_game
{
    // Der User kann zwischen verschiedennen Klassen wählen
    // Die Klassen haben unterschiedliche HP
    // Attacken haben unterschiedliche Werte
    // Jede Klasse hat eine Attacke und eine Superattacke
    // Der User kann wählen zwischen Attacke und Superattacke
    // Die Ai wählt eine Aktion zufällig aus
    // Das Spiel endet wenn einer der Spieler keine HP mehr hat

    public static void main()
    {
        Random random = new Random();  
        Charakter Charakter1 = null;
        Charakter Charakter2 = null;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" ########################## ########################## ");
        Console.WriteLine(" ######################         ###################### ");
        Console.WriteLine(" ##################                 ################## ");
        Console.WriteLine(" #############                           ############# ");
        Console.WriteLine(" ########## !! WELCOME TO SLASHERS KEEP !! ########### ");
        Console.WriteLine(" #############                           ############# ");
        Console.WriteLine(" ##################                 ################## ");
        Console.WriteLine(" ######################         ###################### ");
        Console.WriteLine(" ########################## ########################## ");
        Console.WriteLine("");
        Console.ResetColor();

        
        Console.WriteLine("Select your Character: 1. Fighter, 2. Mage, 3. Rogue");
        int select = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Name your Character: ");
        string username = Console.ReadLine();
        
        
        if (select == 1)
        {
            Console.WriteLine("You have selected the Fighter");
            Charakter1 = new Krieger($"{username}", 15,80);;
        }
        if (select == 2)
        {
            Console.WriteLine("You have selected the Mage");
            Charakter1 = new Magier($"{username}", 12, 50);;
        }
        if (select == 3)
        {
            Console.WriteLine("You have selected the Rogue");
            Charakter1 = new Schurke($"{username}", 14, 65);
        }

        select = random.Next(3) + 1;
        if (select == 1)
        {
            Console.WriteLine("The enemy has selected the Fighter");
            Charakter2 = new Krieger("Steve", 15,80);;
        }
        if (select == 2)
        {
            Console.WriteLine("The enemy has selected the Mage");
            Charakter2 = new Magier("Dave", 12, 50);;
        }
        if (select == 3)
        {
            Console.WriteLine("The enemy has selected the Rogue");
            Charakter2 = new Schurke("Gieselbert", 14, 65);
        }

        if (Charakter1 is null || Charakter2 is null)
            return;
        
        int dmg = 0;
        int win = 0;
        int loss = 0;
        
        for (int i = 0; i < 3; i++)
        {
            do
            {
                Console.WriteLine("Select Attack: (1 for base), (2 for special)");
                int attack = Convert.ToInt32(Console.ReadLine());

                if (attack == 1)
                {
                    Charakter1.angriff();
                    dmg = Charakter1.baseattack();
                    Charakter2.restleben = Charakter2.lebenspunkte - dmg;
                    Console.WriteLine($"You did {dmg} points of Damage to the enemy!");
                    Charakter2.lebenspunkte = Charakter2.restleben;
                    if (Charakter2.lebenspunkte > 0)
                    {
                        Console.WriteLine($"The enemy has {Charakter2.lebenspunkte} left!");
                    }
                    else
                    {
                        Console.WriteLine("The enemy has no more HP left!");
                    }
                }
                else
                {
                    Charakter1.sangriff();
                    dmg = Charakter1.specialattack();
                    Charakter2.restleben = Charakter2.lebenspunkte - dmg;
                    Console.WriteLine($"You did {dmg} points of Damage to the enemy!");
                    Charakter2.lebenspunkte = Charakter2.restleben;
                    if (Charakter2.lebenspunkte > 0)
                    {
                        Console.WriteLine($"The enemy has {Charakter2.lebenspunkte} left!");
                    }
                    else
                    {
                        Console.WriteLine("The enemy has no more HP left!");
                    }
                }
                
                if (Charakter2.restleben <= 0)
                {
                    Console.WriteLine("The enemy has been defeated.");
                    Console.WriteLine($"{Charakter1.name} wins!");
                    Console.WriteLine("");
                    win++;
                    Console.WriteLine(" #################### Round has finished! ##################### ");
                    Console.WriteLine("");
                    break;
                }
                
                attack = Charakter2.pickattack();
                if (attack == 1)
                {
                    Charakter2.angriff();
                    dmg = Charakter2.baseattack();
                    Charakter1.restleben = Charakter1.lebenspunkte - dmg;
                    Console.WriteLine($"The enemy did {dmg} points of Damage to you!");
                    Charakter1.lebenspunkte = Charakter1.restleben;
                    if (Charakter2.lebenspunkte > 0)
                    {
                        Console.WriteLine($"{Charakter1.name} has {Charakter1.lebenspunkte} left!");
                    }
                    else
                    {
                        Console.WriteLine($"{Charakter1.name} has no more HP left!");
                    }
                }
                else
                {
                    Charakter2.sangriff();
                    dmg = Charakter2.specialattack();
                    Charakter1.restleben = Charakter1.lebenspunkte - dmg;
                    Console.WriteLine($"The enemy did {dmg} points of Damage to you!");
                    Charakter1.lebenspunkte = Charakter1.restleben;
                    if (Charakter2.lebenspunkte > 0)
                    {
                        Console.WriteLine($"{Charakter1.name} has {Charakter1.lebenspunkte} left!");
                    }
                    else
                    {
                        Console.WriteLine($"{Charakter1.name} has no more HP left!");
                    }
                }
                
                if (Charakter1.restleben <= 0)
                {
                    Console.WriteLine($"{Charakter1.name} has been knocked out.");
                    Console.WriteLine($"{Charakter1.name} lost!");
                    Console.WriteLine("");
                    loss++;
                    Console.WriteLine(" #################### Round has finished! ##################### ");
                    Console.WriteLine("");
                    break;
                }

            } while (Charakter1.lebenspunkte > 0 || Charakter2.lebenspunkte > 0);
            Charakter1.reset();
            Charakter2.reset();
        }
        if (win >= 2)
        {
            Console.WriteLine($" ############## You have won {win} amount of times! ############### ");
            Console.WriteLine("");
            Console.WriteLine(" ###################### Congratulations! ###################### ");
            Console.WriteLine("");
            Console.WriteLine(" ################### You have won the game! ################### ");
            Console.WriteLine("");
            Console.WriteLine(" ######################### Game Over! ######################### ");
            Console.WriteLine("");
            Console.WriteLine(" ######################## Game made by ######################## ");
            Console.WriteLine(" #################### Alexander Leuschner ##################### ");
        }
        else
        {
            Console.WriteLine($" ############# You have lost {loss} amount of times! ############## ");
            Console.WriteLine("");
            Console.WriteLine(" ######################### You failed! ######################## ");
            Console.WriteLine("");
            Console.WriteLine(" ################### You have lost the game! ################## ");
            Console.WriteLine("");
            Console.WriteLine(" ######################### Game Over! ######################### ");
            Console.WriteLine("");
            Console.WriteLine(" ######################## Game made by ######################## ");
            Console.WriteLine(" #################### Alexander Leuschner ##################### ");
        }
    }
}