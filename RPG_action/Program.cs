



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
// 11 == in
int player_level = 3;
int player_experience = 0;
int equipment_boost_attack = 0;
int player_currency = 100;
int player_attack = (10 * player_level) + equipment_boost_attack;
int player_health = 10;

int experience = 1;
int enemy_gold = 1;
int enemy_health = 1;
int enemy_attack = 1;

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

void battle()
{
        while (enemy_health > 0 && player_health > 0)
    {
        Console.WriteLine(@"make your move.
        
        [1]: Attack
        [2]: Defend
        [3]: Item
        [4]: Escape");

        int n = Convert.ToInt32(Console.ReadLine());

        switch (n)
        {
            case 1:
                enemy_health -= player_attack;
                if (regions == 4)
                {
                    Console.WriteLine($"you attack the dragon head on. you deal {player_attack} to the dragon.");
                }
                if (regions == 6)
                {
                    Console.WriteLine($"you attack the goblin head on. you deal {player_attack} to the goblin.");
                }
                if (enemy_health > 0)
                    {
                        player_health -= enemy_attack;
                        if (regions == 4)
                        {
                            Console.WriteLine($"the dragon spews flames at you. you take {enemy_attack} damage");
                        }
                        if (regions == 5)
                        {
                            Console.WriteLine($"the goblin takes a swing at you with his hammer. you take {enemy_attack} damage");
                        }
                    }
                break;
            case 2:
                player_health -= enemy_attack / 2;
                if (regions == 4)
                {
                    Console.WriteLine($"the dragon spews flames at you. you take {enemy_attack / 2} damage");    
                }
                if (regions == 5)
                {
                    Console.WriteLine($"the goblin takes a swing at you with his hammer. you take {enemy_attack} damage");
                }
                break;
            case 3:
                break;
            case 4:
                Console.WriteLine("you escape by the skin of your teeth.");
                regions = 1;
                break;

        }

    }
}

void dragon_battle()
{
    enemy_attack = 18;
    enemy_health = 1;
    experience = 500;
    enemy_gold = 100;
    Console.WriteLine("a dragon appears from above.");
    battle();

    Console.WriteLine("you terminated the dragon!");
    levelup();
    regions = 1;


    
}
void bandit_battle()
{
    enemy_attack = 6;
    enemy_health = 40;
    enemy_gold = 300;
    experience = 20;
    Console.WriteLine("a bandit ambushes you");
    battle();

    Console.WriteLine("you aprehended the bandit");
    levelup();
    regions = 1;
}

void goblin_battle()
{
    enemy_attack = 3;
    enemy_health = 15;
    enemy_gold = 5;
    experience = 50;
    Console.WriteLine("a goblin charges you head on.");
    battle();

    Console.WriteLine("you drive off the goblin!");
    levelup();
    regions = 1;
}


void death_check()
{
    if (player_health <= 0)
    {
        Console.WriteLine(@"Annihilated. Do you want to continue?
        
        [1]: yes
        [2]: no");

        int n = Convert.ToInt32(Console.ReadLine());

        if (n == 1)
        {
            player_currency = player_currency / 2;
            player_health = 1;
            regions = 1;
        }
        if (n == 2)
        {
            Console.WriteLine("Game over.");
            running = false;
            
        }

        
    }
}


void start_point()
{
    Console.WriteLine(@$"You are at the starting point. What will you do?
    status
    level {player_level}
    health {player_health}
    gold {player_currency}
    
    [1]: go to town.
    [2]: go fight monsters.");

    int n = Convert.ToInt32(Console.ReadLine());

    if (n == 1)
    {
        regions = 2;
    }
    if (n == 2)
    {
        regions = 3;
    }


}
void inn()
{
    Console.WriteLine(@"do you want to stay for the night? it's only 10 zenny a night.
    
    [1]: take a rest
    [2]: im fine");

    int n = Convert.ToInt32(Console.ReadLine());

    if (n == 1)
    {
        player_health = 10 * player_level;
        Console.WriteLine("Have a nice day");
        player_currency -= 10;
        regions = 1;
    }
    if (n == 2)
    {
        regions = 1;
    }

}

void town()
{
    Console.WriteLine(@"where do you want to go?
    
    [1]: tavern
    [2]: shop
    [3]: inn");

    int n = Convert.ToInt32(Console.ReadLine());

    if (n == 1)
    {
        regions = 1;
    }
    if (n == 2)
    {
        regions = 1;
    }
    if (n == 3)
    {
        regions = 11;
    }

}

void tavern()
{
    Console.WriteLine(@"there are quite a few people here. Who will you talk to?
    
    [1]: a shady guy in a dark corner
    [2]: a man sobing on the counter
    [3]: the bartender.");

}

void fight_monsters()
{
    Console.WriteLine(@"what do you want to fight?

    [1]: dragon
    [2]: goblin
    [3]: bandit");

    int n = Convert.ToInt32(Console.ReadLine());

    if (n == 1)
    {
        regions = 4;
    }
    if (n == 2)
    {
        regions = 5;
    }
    if (n == 3)
    {
        regions = 6;
    }
}

while (running)
{

    Console.WriteLine(regions);
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
        case 11:
            inn();
            death_check();
            break;
    }





}





