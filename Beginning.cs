
using System.Diagnostics;
using System.Xml.Linq;
using System.Windows.Input;

string PlayerName;
string Character;
float statAttk;
float statHp;
float statTrade;
float smallSpellAttk;
float splashSpellAttk;
float DollHealth = 100;
float DollAttack = 10;
float RatHp = 150;
float RatAttk = 50;
float HealPoti = 0;
float StrenghtPoti = 0;
float Gold = 0;
float MaxHp;
float strenght = 1;
float health = 1;
float trade = 1;
float brewer = 1;


Console.WriteLine("NOTICE: play in fullscreen for better experiance");
GameStart();




void GameStart()
{
    Console.WriteLine("Welcome to the game, choose your character: swordsman, archer, mage");
    Character = Console.ReadLine();
    if (Character == "swordsman")
    {
        Console.WriteLine("from now on you will be a " + Character + ", please eneter your name to begin:");
        statAttk = 30;
        statHp = 150;
        MaxHp = 150;
    }
    else if (Character == "archer")
    {
        Console.WriteLine("from now on you will be a " + Character + ", please eneter your name to begin:");
        statAttk = 60;
        statHp = 100;
        MaxHp = 100;
    }
    else if(Character == "skiptutor")
    {
        statAttk = 1000;
        statHp = 1000;
        MaxHp = 1000;
        RatFight();
    }
    else if (Character == "lvlup")
    {
        statAttk = 1000;
        statHp = 1000;
        MaxHp = 1000;
        LvlUp();
    }
    else
    {
        Console.WriteLine("I dont understand this");
        GameStart();
    }
    PlayerName = Console.ReadLine();
    Console.WriteLine("Hello " + PlayerName + ", lets  start our journey!");
    FightTutor();
}



void FightTutor()
{
    
    Console.WriteLine("First lets see how rusty you are in fighting, i want you to attack this doll to practice your skills.");
    Console.WriteLine("Press -enter- to continue");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Enter)
    {
        
        Console.WriteLine("" +
            "" +
            "" +
            "");
        Console.WriteLine("Usually when fighting you will have two options: attack, or item if you attack you will deal damage to the enemy but if you are using item you can heal yourself and mucs more(item can be obtained along the journey, or bought in shops).");
        Console.WriteLine("Press -enter- to continue");
    }
    ConsoleKeyInfo key2 = Console.ReadKey();
    if (key2.Key == ConsoleKey.Enter)
    {
        Console.Clear();
        DollFight();
    }
    
}
void DollFight()
{
    string Action;
    Console.WriteLine("Doll health:" + DollHealth);
    Console.WriteLine("type attack or item");
    Action = Console.ReadLine();
    if (Action == "attack")
    {
        Console.Clear();
        Console.WriteLine("you dealt "+statAttk+" damage");
        DollHealth -= statAttk;
        if (DollHealth > 0)
        {
            
            Console.WriteLine("the doll attack and deals "+DollAttack+" damage to you");
            statHp -= DollAttack;
            Console.WriteLine("you have "+statHp+" health");
            if(statHp <= 0)
            {
                Console.Clear();
                Console.WriteLine("You got killed by the doll");
                return;
            }
            DollFight();
        }
        else

        {
            Console.WriteLine("you succesfully defeated the doll");
            Console.WriteLine("you got a -Heal potion-");
            HealPoti += 1;
            Console.WriteLine("press -enter- to continue");
            ConsoleKeyInfo key3 = Console.ReadKey();
            if(key3.Key == ConsoleKey.Enter)
            {
                NextMission();
            }
        }


    }
    else if(Action == "item")
    {
        if(HealPoti < 1)
        {
            Console.WriteLine("You dont have any items.");
            DollFight();
        }
    }
    else
    {
        DollFight();
    }
}
void NextMission()
{
    Console.Clear();
    Console.WriteLine("okay you completed the tutorial, your next mission is to start the game.");
    Console.WriteLine("PRESS -enter- TO START (finnaly) THE GAME");
    ConsoleKeyInfo key = Console.ReadKey();
    if(key.Key == ConsoleKey.Enter)
    {
        Console.Clear();
        Console.WriteLine("Chapter 1: the dungeon");
        Console.WriteLine("You find yourself in a little inn stopping on a journey to the west, the inkeeper tells you about that he heard noises from the basement.");
        Console.WriteLine("Do you want to look in the basement? y/n");
        string ANS = Console.ReadLine();
        if (ANS == "y")
        {
            Console.WriteLine("thats the answear i wnated young man");
            Console.WriteLine("You go down the basement.");
            Console.WriteLine("press -enter- to continue");
            ConsoleKeyInfo key1 = Console.ReadKey();
            if( key1.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("As soon as you enter the basement you hear the noises the innkeeper was talking about they sound likeshometing scary lies beyond the wall.");
                Console.WriteLine("You peek out and you see the creature its a giant mutant rat.");
                Console.WriteLine("fight or run?");
                string act = Console.ReadLine();
                if (act == "fight")
                {
                    RatFight();
                }
                else if (act == "run")
                {
                    Console.WriteLine("You have ran away but your curiosity brings you back");
                    Console.WriteLine("Press -enter- to continue");
                    ConsoleKeyInfo key2 = Console.ReadKey();
                    if (key2.Key == ConsoleKey.Enter)
                    {
                        NextMission();
                    }
                }
            }
        }
        else if (ANS == "n")
        {
            Console.WriteLine("yu fak");
        }
        else
        {
            Console.WriteLine("Válaszoljon fiatalember!");
            NextMission();
        }
    }
    
}
void RatFight()
{
    string act2;
    Console.WriteLine("The rat has "+RatHp+" health");
    Console.WriteLine("type attack or item");
    act2 = Console.ReadLine();
    if(act2 == "attack")
    {
            Console.Clear();
            Console.WriteLine("you dealt " + statAttk + " damage");
            RatHp -= statAttk;
            if(RatHp > 0)
            {
                statHp -= RatAttk;
                Console.WriteLine("the rat dealt "+RatAttk+" damage to you");
                if (statHp <= 0)
                {
                    Console.WriteLine("you have been killed by the rat (try to use items next time)");
                }
                else
                {
                    Console.WriteLine("you have " + statHp + " health");
                    RatFight();
                }
            }   
            else
            {
            Console.Clear();
                Console.WriteLine("you sucsesfully defeated the rat");
            Console.WriteLine("You got 1 strenght potion");
            StrenghtPoti += 1;
            Console.WriteLine("press -enter- to continue");
            ConsoleKeyInfo key3 = Console.ReadKey();
            if(key3.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("you go up from the basement and tell the innkeeper thet you defeated the monster he gives 100g for your work, and tells that you can spend the money in shop like this");
                Gold += 100;
                Shop();
            }
            }
    }
    else if(act2 == "item")
    {
        Console.Clear();
        Console.WriteLine("Your potions: x"+HealPoti+" heal");
        Console.WriteLine(" what do you want to use?");
        string act1 = Console.ReadLine();
        if(act1 == "heal")
        {
            statHp = MaxHp;
            Console.WriteLine("your health has been restored to the max");
            RatFight();
        }
        else
        {
            RatFight();
        }
    }
    else
    {
        RatFight();
    }
}
void Shop()
{
    Console.WriteLine("what do you want to buy");
    Console.WriteLine("options: heal potion("+statTrade+"), strenght potion(100g), nothing");
    string act1 = Console.ReadLine();
    if(act1 == "heal")
    {
        Console.Clear();
        Gold -= 75;
        HealPoti += 1;
        Console.WriteLine("you bought a heal potion");
        Console.WriteLine("press -enter- to continue");
        ConsoleKeyInfo key1 = Console.ReadKey();
        if(key1.Key == ConsoleKey.Enter)
        {
            LvlUp();
        }
    }
    else if(act1 == "strenght")
    {
        Console.Clear();
        Gold -= 100;
        StrenghtPoti += 1;
        Console.WriteLine("you bought a strenght potion");
        Console.WriteLine("press -enter- to continue");
        ConsoleKeyInfo key2 = Console.ReadKey();
        if (key2.Key == ConsoleKey.Enter)
        {
            LvlUp();
        }
    }
    else if(act1 == "nothing")
    {
        LvlUp();
    }
}
void LvlUp()
{
    Console.Clear();
    Console.WriteLine("You have 1 skill point what will you use it on?");
    Console.WriteLine("theese are youre skills: strenght "+strenght+", health "+health+", trade "+trade+", brewer "+brewer);
    Console.WriteLine("strenght: you will deal more damage, health: you will have more health, trade: the items in shops are cheaper, brewer: the potions you drink are more effective.");
    string act12 = Console.ReadLine();
    if(act12 == "strenght")
    {
        strenght += 1;
        statAttk += 5;
        Console.WriteLine("you have levelled up strenght(lvl "+strenght+") you now deal +5: "+statAttk+" damage");
    }
    else if(act12 == "health")
    {
        health += 1;
        statHp += 10;
        Console.WriteLine("you have levelled up health(lvl "+health+") you now have +10: "+statHp+" hp");
    }
    else if(act12 == "trade")
    {
        
    }
}


