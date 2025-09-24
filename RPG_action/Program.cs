using static System.Console;

// determines if the game is running or not
bool running = true;


int regions = 1;

// 1 == starting point

// 2 == fight monsters
// 4 == dragon battle
// 5 == goblin battle
// 6 == bandit battle

// 3 == town
// 7 == tavern
//      9 == shady guy
//      10 == sobbing guy
// 8 == shop
// 11 == inn


// player stats and level
int player_level = 1;
int player_experience = 0;
int player_currency = 100;
int player_health = 10;
int player_books = 0;


// input controls
const ConsoleKey Z = ConsoleKey.Z;
const ConsoleKey X = ConsoleKey.X;
const ConsoleKey C = ConsoleKey.C;
const ConsoleKey V = ConsoleKey.V;

ConsoleKey getchoice()
{
    ConsoleKey choice = ReadKey(true).Key;
    return choice;
}


int experience = 1;
int enemy_gold = 1;
int enemy_health = 1;
int enemy_attack = 1;


// code for leveling up
void levelup()
{
        player_currency += enemy_gold;
        player_experience += experience;
        while (player_experience >= 100)
        {
            player_level += 1;
            player_experience -= 100;
        }   
}


//battle state
void battle()
{
    bool inbattle = true;
    while (enemy_health > 0 && player_health > 0 && inbattle == true)
    {
        Console.WriteLine("");
        Console.WriteLine(@"Make your move:
        
        [Z]: Attack.
        [X]: Defend.
        [C]: Item.
        [V]: Escape.");

        Console.WriteLine("");


        switch (getchoice())
        {
            case Z:
                enemy_health -= 7 * player_level;
                if (regions == 4)
                {
                    Console.WriteLine($"You attack the dragon head on. You deal {7 * player_level} to the dragon.");
                }
                if (regions == 5)
                {
                    Console.WriteLine($"You attack the goblin head on. You deal {7 * player_level} to the goblin.");
                }
                if (regions == 6)
                {
                    Console.WriteLine($"You attack the bandit head on. You deal {7 * player_level} to the bandit.");
                }
                if (enemy_health > 0)
                {
                    player_health -= enemy_attack;
                    if (regions == 4)
                    {
                        Console.WriteLine($"The dragon spews flames at you. you take {enemy_attack} damage.");
                    }
                    if (regions == 5)
                    {
                        Console.WriteLine($"The goblin takes a swing at you with his hammer. You take {enemy_attack} damage.");
                    }
                    if (regions == 6)
                    {
                        Console.WriteLine($"The bandit brandishes his knife and rushes toward you. You take {enemy_attack} damage");
                    }
                }
                break;
            case X:
                player_health -= enemy_attack / 2;
                if (regions == 4)
                {
                    Console.WriteLine($"The dragon spews flames at you. You take {enemy_attack / 2} damage.");
                }
                if (regions == 5)
                {
                    Console.WriteLine($"The goblin takes a swing at you with his hammer. You take {enemy_attack / 2} damage.");
                }
                if (regions == 6)
                {
                    Console.WriteLine($"The bandit brandishes his knife and rushes toward you. You take {enemy_attack / 2} damage");
                }
                break;
            case C:
                Console.WriteLine("You don't have any items in this build.");
                break;
            case V:
                Console.WriteLine("You escape by the skin of your teeth.");
                inbattle = false;
                regions = 1;
                break;

        }

    }
}


// enemy encounters
void dragon_battle()
{
    enemy_attack = 18;
    enemy_health = 100;
    experience = 500;
    enemy_gold = 100;

    Console.WriteLine("A dragon crashes down from above.");
    battle();
    if (enemy_health <= 0)
    {
        Console.WriteLine("You terminated the dragon!");
        levelup();
        regions = 1;
    }
}

void bandit_battle()
{
    enemy_attack = 6;
    enemy_health = 40;
    enemy_gold = 300;
    experience = 20;
    Console.WriteLine("A bandit ambushes you.");
    battle();
    if (enemy_health <= 0)
    {
        Console.WriteLine("You aprehended the bandit.");
        levelup();
        regions = 1;
    }
}

void goblin_battle()
{
    enemy_attack = 3;
    enemy_health = 15;
    enemy_gold = 5;
    experience = 50;
    Console.WriteLine("A goblin charges you head on.");
    battle();
    if (enemy_health <= 0)
    {
        Console.WriteLine("You drive off the goblin!");
        levelup();
        regions = 1;
    }
}



// checks if the character is alive.
void death_check()
{
    if (player_health <= 0)
    {
        Console.WriteLine(@"You have been annihilated. Do you want to continue?
        
        [Z]: yes
        [X]: no");

        Console.WriteLine("");

        if (getchoice() == Z)
        {
            player_currency = player_currency / 2;
            player_health = 1;
            regions = 1;
        }
        if (getchoice()== X)
        {
            Console.WriteLine("Game over.");
            running = false;
            
        }
    }
}


// starting point
void start_point()
{
    Console.WriteLine(@$"You are at the starting point. What will you do?

    STATUS:
    Level {player_level}
    Health {player_health}
    Zenny {player_currency}
    Books {player_books}
    
    [Z]: go to town.
    [X]: go fight monsters.");

    Console.WriteLine("");

    if (getchoice() == Z)
    {
        regions = 2;
    }
    if (getchoice() == X)
    {
        regions = 3;
    }


}


// code for the town.
void town()
{
    Console.WriteLine(@"Where do you want to go?
    
    [Z]: tavern
    [X]: shop
    [C]: inn");

    Console.WriteLine("");

    if (getchoice() == Z)
    {
        regions = 7;
    }
    if (getchoice() == X)
    {
        regions = 8;
    }
    if (getchoice() == C)
    {
        regions = 11;
    }
}


// code for the shop
void shop()
{

    Console.WriteLine(@"

    [Z]: Talk to the shop owner
    [X]: Take a look at the bookshelf
    [C]: leave.");

    Console.WriteLine("");

    if (getchoice() == Z)
    {
        Console.WriteLine(@"Shopkeeper: I am currently cleaning the place up. Sorry I can't do buisness at the moment.
        Still, feel free to take a look around the place.");
    }
    if (getchoice() == X)
    {
        if (player_books == 0)
        {
            Console.WriteLine("Shopkeeper: You read much? Feel free to take some for youself.");
        }
        if (player_books < 5)
        {
            player_books += 1;
        }
        if (player_books == 2)
        {
            Console.WriteLine("Don't take that book, that's my favorite one, take this one instead.");
        }
        if (player_books == 3)
        {
            Console.WriteLine("Shopkeeper: Alright thats enough! Leave some of those books for me.");
        }
        if (player_books == 4)
        {
            Console.WriteLine("Shopkeeper: I said thats enough books for you!");
        }
        if (player_books == 5)
        {
            Console.WriteLine("Alright, I've had enough of you. Get ou!t.");
            player_health = 1;
            regions = 1;
        }

    }
    if (getchoice() == C)
    {
        regions = 1;
    }

}



// Code for the tavern
void tavern()
{
    Console.WriteLine(@"There are quite a few people here. Who will you talk to?
    
    [Z]: a shady guy in a dark corner.
    [X]: a man sleeping on the counter.
    [C]: the bartender.
    [V]: go back to town.");

    Console.WriteLine("");


    if (getchoice() == Z)
    {
        Console.WriteLine(@"Mr. Shady: (I swear the kid looked... ) Agh! W-What do you want? You scared the living daylights outa me!
        
        [Z]: Oh, Sorry I...
        [X]: What's your problem?");

        Console.WriteLine("");
        
        if (getchoice() == Z)
        {
            Console.WriteLine("Well, don't just stare. Beat it kid!");
        }
        if (getchoice() == X)
        {
            Console.WriteLine(@"Look kid, I am kind of on a tight schedule. Here take this and get a drink or something, alright?
            (he gives you 2 zenny)");
            player_currency += 2;
        }


    }
    if (getchoice() == X)
    {
        Console.WriteLine("");
        Console.WriteLine(@"Aloof man: ...

        [Z]: So... uh... How's it going?
        [X]: ...");

        Console.WriteLine("");

        if (getchoice() == Z)
        {
            Console.WriteLine("Aloof man: can you leave me be??");
        }
        if (getchoice() == X)
        {
            Console.WriteLine(@"Aloof man: ......
            
            [Z]: You're pretty quiet.
            [X]: ......");

            Console.WriteLine("");

            if (getchoice() == Z)
            {
                Console.WriteLine("Aloof man: Go away, please.");
            }
            if (getchoice() == X)
            {
                Console.WriteLine("Aloof man: ................");
                Console.WriteLine("[Z]...........................");
                getchoice();
                Console.WriteLine(@"Aloof man:.....................................
                ...................................................................
                ...................................................................
                ...................................................................
                ...................................................................
                ...................................................................
                ...................................................................
                ...");
                getchoice();
                Console.WriteLine("You're a pleasant man to talk to.");

            }
        }


    }
    if (getchoice() == C)
    {
        Console.WriteLine(@"Bartender: Hey you, want to try my special brew?
            
            [Z]: try it out
            [X]: I'll pass");

            Console.WriteLine("");

        if (getchoice() == Z)
        {
            Console.WriteLine(@"
            
            You take a sip of the drink. It tastes awful.
                
                Bartender: You alright there? you look like you are about to hurl.
                
                [Z]: No... It tastes great.
                [X]: I think that I actually will.");

                Console.WriteLine("");


            if (getchoice() == X)
            {
                Console.WriteLine("Bartender: I guess you aren't ready for drinking yet.");
            }
            if (getchoice() == Z)
            {
                Console.WriteLine("Bartender: Gyahaha. You're pretty tough kid, my brew is an aquired taste anyways.");
            }
        }

    }
    if (getchoice() == V)
    {
        regions = 1;
    }
}



//code for the inn
void inn()
{
    Console.WriteLine(@"Inkeeper: Hiiii! Do you want to stay for the night? it's only 10 zenny a night. <3
    
    [Z]: Uh... sure. I guess.
    [X]: Um... I'm fine, thanks.");

    Console.WriteLine("");


    if (getchoice() == Z)
    {
        player_health = 10 * player_level;
        Console.WriteLine("Inkeeper: Thanks so much! Have a nice daaay! <3");
        player_currency -= 10;
        getchoice();
        regions = 1;
    }
    if (getchoice() == X)
    {
        Console.WriteLine("Inkeeper: Were always open if you change your mind. <3");
        regions = 1;
        getchoice();
    }
}

void fight_monsters()
{
    Console.WriteLine(@"What do you want to fight?

    [Z]: dragon
    [X]: goblin
    [C]: bandit");

    Console.WriteLine("");

    if (getchoice() == Z)
    {
        regions = 4;
    }
    if (getchoice() == X)
    {
        regions = 5;
    }
    if (getchoice() == C)
    {
        regions = 6;
    }
}


//main function where code runs
while (running)
{
    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
    switch (regions)
    {
        case 1:

            start_point();
            death_check();
            break;
        case 2:
            town();
            death_check();
            break;
        case 3:
            fight_monsters();
            death_check();
            break;
        case 4:
            dragon_battle();
            death_check();
            break;
        case 5:
            goblin_battle();
            death_check();
            break;
        case 6:
            bandit_battle();
            death_check();
            break;
        case 7:
            tavern();
            death_check();
            break;
        case 8:
            shop();
            death_check();
            break;
        case 11:
            inn();
            death_check();
            break;
    }
}





