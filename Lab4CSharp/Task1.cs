class Money
{
    protected int nominal;
    protected int ammount;
    private static readonly int[] nominals = {1, 2, 5, 10, 20, 50, 100, 200, 500, 1000};

    public Money(int nominal, int ammount)
    {
        if (Array.Find(nominals, var => var == nominal) != 0){
            this.nominal = nominal;
            this.ammount = ammount;
        } 
        else
            throw new ArgumentException("Не існує купюри з таким номіналом");
    }

    public int this[int index]
    {
        get
        {
            if (index == 0)
                return nominal;
            else if (index == 1)
                return ammount;
            else
                throw new ArgumentOutOfRangeException();
        }
        set
        {
            if (index == 0)
            {
                if (Array.Find(nominals, var => var == nominal) != 0)
                    throw new ArgumentException("Не існує купюри з таким номіналом");
                nominal = value;
            }
                
            else if (index == 1)
                ammount = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }

    public static Money operator ++(Money money)
    {
        int index = Array.FindIndex(nominals, var => var == money.nominal);
        money.nominal = nominals[++index];
        money.ammount++;
        return money;
    }

    public static Money operator --(Money money)
    {
        int index = Array.FindIndex(nominals, var => var == money.nominal);
        money.nominal = nominals[--index];
        money.ammount--;
        return money;
    }

    public static bool operator !(Money money)
    {
        return money.ammount != 0;
    }

    public static Money operator +(Money money, int scalar)
    {
        money.ammount += scalar;
        return money;
    }

    public override string ToString()
    {
        return $"nominal: {nominal}, ammount: {ammount}";
    }

    public static Money Parse(string s)
    {
        string[] parts = s.Split(',');
        int nominal = int.Parse(parts[0].Split(':')[1]);
        int ammount = int.Parse(parts[1].Split(':')[1]);
        return new Money(nominal, ammount);
    }
}

class Task1
{
    public static void task1()
    {
        Money money = new(10, 20);

        Console.WriteLine($"nominal: {money[0]}, ammount: {money[1]}");

        money[0] = 100;
        money[1] = 200;
        Console.WriteLine($"nominal: {money[0]}, ammount: {money[1]}");

        money++;
        Console.WriteLine($"nominal: {money[0]}, ammount: {money[1]}");
        money--;
        Console.WriteLine($"nominal: {money[0]}, ammount: {money[1]}");

        Console.WriteLine($"!money: {!money}");

        money += 50;
        Console.WriteLine($"nominal: {money[0]}, ammount: {money[1]}");

        string moneyString = money.ToString();
        Console.WriteLine($"Money as string: {moneyString}");

        Money newMoney = Money.Parse("nominal: 500, ammount: 600");
        Console.WriteLine($"New Money: nominal: {newMoney[0]}, ammount: {newMoney[1]}");
    }
}
