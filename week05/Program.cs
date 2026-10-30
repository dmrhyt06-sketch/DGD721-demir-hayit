// DGD721 · Practice Sheet · Week 5
// Variables · conditions · switch · loops · methods

// ===== Part A · Predict the output =====
// A1: 5
//     x / y = 11 / 4 = 2 (integer division), x % y = 11 % 4 = 3  ->  2 + 3 = 5
// A2: Hurt
//     hp = 45 is not > 50, but it is > 20  ->  "Hurt"
// A3: 4
//     i=1: -1 -> -1 | i=2: +2 -> 1 | i=3: -1 -> 0 | i=4: +4 -> 4
// A4: 14
//     Twice(3) = 6  ->  a = 6  ->  Twice(6 + 1) = Twice(7) = 14

// ===== B1 =====
{
    void ShowDamage(int baseDamage, int armor, int level)
    {
        int damage = baseDamage - armor;
        if (level >= 5)
        {
            damage += 10;
        }
        if (damage < 1)
        {
            damage = 1;
        }

        string label;
        if (damage >= 30)
        {
            label = "Strong hit";
        }
        else if (damage >= 10)
        {
            label = "Normal hit";
        }
        else
        {
            label = "Weak hit";
        }

        Console.WriteLine($"Damage: {damage} ({label})");
    }

    ShowDamage(40, 15, 4); // Damage: 25 (Normal hit)
    ShowDamage(40, 15, 6); // test: level = 6  -> Damage: 35 (Strong hit)
    ShowDamage(40, 50, 4); // test: armor = 50 -> Damage: 1 (Weak hit)
}
Console.WriteLine();

// ===== B2 =====
{
    int gold = 120;
    int choice = 2;

    string item = "";
    int price = 0;

    switch (choice)
    {
        case 1:
            item = "Sword";
            price = 100;
            break;
        case 2:
            item = "Bow";
            price = 80;
            break;
        case 3:
            item = "Potion";
            price = 25;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    if (item != "")
    {
        if (gold >= price)
        {
            gold -= price;
            Console.WriteLine($"You bought a {item}! Gold left: {gold}");
        }
        else
        {
            Console.WriteLine($"Not enough gold for the {item}. You need {price - gold} more gold.");
        }
    }
}
Console.WriteLine();

// ===== B3 =====
{
    for (int wave = 1; wave <= 30; wave++)
    {
        string monster;
        // Check "both 3 and 5" first, otherwise 15 would print "Slime".
        if (wave % 3 == 0 && wave % 5 == 0)
        {
            monster = "BOSS";
        }
        else if (wave % 3 == 0)
        {
            monster = "Slime";
        }
        else if (wave % 5 == 0)
        {
            monster = "Bat";
        }
        else
        {
            monster = "empty";
        }

        Console.WriteLine($"Wave {wave}: {monster}");
    }
}
Console.WriteLine();

// ===== B4 =====
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        fights++;
        xp += 35;

        if (xp >= 100)
        {
            xp -= 100;
            level++;
            Console.WriteLine($"LEVEL UP! Now level {level}");
        }
    }

    Console.WriteLine($"Reached level {level} after {fights} fights (xp left: {xp})");
}
Console.WriteLine();

// ===== B5 =====
{
    int Clamp(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }
        if (value > max)
        {
            return max;
        }
        return value;
    }

    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp = Clamp(hp + 50, 0, 100); // the hero drinks a potion (+50)
    Console.WriteLine($"HP after potion: {hp}");
}
Console.WriteLine();

// ===== B6 =====
{
    string GetRank(int score)
    {
        if (score >= 1000)
        {
            return "Gold";
        }
        else if (score >= 500)
        {
            return "Silver";
        }
        else if (score >= 1)
        {
            return "Bronze";
        }
        else
        {
            return "No medal";
        }
    }

    for (int score = 0; score <= 1250; score += 250)
    {
        Console.WriteLine($"Score {score}: {GetRank(score)}");
    }
}
Console.WriteLine();

// ===== B7 =====
{
    int Attack(int hp, int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
        return hp;
    }

    bool IsAlive(int hp)
    {
        return hp > 0;
    }

    int playerHp = 150;
    int playerDamage = 25;
    int bossHp = 120;
    int bossDamage = 25;
    int turn = 0;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        turn++;

        // The player always attacks first.
        bossHp = Attack(bossHp, playerDamage);
        if (!IsAlive(bossHp))
        {
            // The boss falls and cannot hit back.
            Console.WriteLine($"Turn {turn} | Boss: {bossHp}");
            break;
        }

        // Every 3rd turn the boss hits for double damage.
        int hit = bossDamage;
        if (turn % 3 == 0)
        {
            hit = bossDamage * 2;
        }
        playerHp = Attack(playerHp, hit);

        Console.WriteLine($"Turn {turn} | Boss: {bossHp} | Player: {playerHp}");
    }

    if (IsAlive(playerHp))
    {
        Console.WriteLine($"You win in {turn} turns! HP left: {playerHp}");
    }
    else
    {
        Console.WriteLine($"The boss wins in {turn} turns! Boss HP left: {bossHp}");
    }
}
Console.WriteLine();

// ===== B8 =====
{
    string Hint(int guess, int secret)
    {
        if (guess < secret)
        {
            return "Too low";
        }
        else if (guess > secret)
        {
            return "Too high";
        }
        else
        {
            return "Correct!";
        }
    }

    // Bonus: set useRandom = true to get a random secret number.
    bool useRandom = false;
    int secret = 42;
    if (useRandom)
    {
        secret = new Random().Next(1, 101);
    }

    int triesLeft = 5;
    int triesUsed = 0;
    bool found = false;

    while (triesLeft > 0 && !found)
    {
        Console.Write($"Guess ({triesLeft} tries left): ");
        int guess = int.Parse(Console.ReadLine() ?? "0");
        triesLeft--;
        triesUsed++;

        string hint = Hint(guess, secret);
        Console.WriteLine(hint);

        if (hint == "Correct!")
        {
            found = true;
        }
    }

    if (found)
    {
        Console.WriteLine($"You found it in {triesUsed} tries!");
    }
    else
    {
        Console.WriteLine($"You lose! The number was {secret}.");
    }
}
