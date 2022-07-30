using System;

class MainClass
{
    public static void Main(string[] args)
    {

        GetAnketa(out (string Name, string LastName, int Age, string[] Pets, string[] FavColors) User);
        ShowUser(User);
        Console.ReadKey();

    }

    static void GetAnketa(out (string Name, string LastName, int Age, string[] Pets, string[] FavColors) User)
    {

        Console.WriteLine("Введите имя");
        User.Name = Console.ReadLine();
        Console.WriteLine("Введите Фамилию");
        User.LastName = Console.ReadLine();

        string check;
        //      Код о возрасте
        int correctage;

        do
        {
            Console.WriteLine("Введите свой возвраст (цифрой)");
            check = Console.ReadLine();
        } while (CheckNum(check, out correctage));

        User.Age = correctage;

        //      Код о домашних питомцах
        string HavePets;
        Console.WriteLine("Есть ли у Вас домашние питомцы (Да/Нет)?");
        HavePets = Console.ReadLine();

        int HowManyPets;
        if (HavePets == "Да")
        {
            do
            {
                Console.WriteLine("Cколько у Вас домашних питомцев (цифрой):");
                check = Console.ReadLine();

            } while (CheckNum(check, out HowManyPets));
        }
        else HowManyPets = 0;
        User.Pets = CreateArrayPets(HowManyPets);

        //      Код о цвете
        int HowManyFavColors;

        do
        {
            Console.WriteLine("Напишите сколько Вам нравится цветов (цифрой):");
            check = Console.ReadLine();
        } while (CheckNum(check, out HowManyFavColors));

        User.FavColors = CreateArrayColors(HowManyFavColors);

    }

    static bool CheckNum(string number, out int corrnumber)
    {
        if (int.TryParse(number, out int intnum))
        {
            if (intnum > 0)
            {
                corrnumber = intnum;
                return false;
            }
        }
        {
            corrnumber = 0;
            Console.WriteLine("Некорректино введены данные");
            return true;
        }
    }

    static string[] CreateArrayPets(int num)
    {
        var result = new string[num];
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine("Введите кличку Вашего домашнего питомца номер {0}", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;
    }

    static string[] CreateArrayColors(int num)
    {
        var result = new string[num];
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine("Введите свой любимый цвет номер {0}", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;
    }

    static void ShowUser((string Name, string LastName, int Age, string[] Pets, string[] FavColors) User)
    {
        Console.WriteLine("\n\nАНКЕТА: \nИмя - {0},  Фамилия - {1}", User.Name, User.LastName);
        Console.WriteLine("\nВозраст {0}", User.Age);

        Console.WriteLine("\nДомашние питомцы:");
        if (User.Pets.Length != 0)
        {
            foreach (var pets in User.Pets)
            {
                Console.WriteLine($"{pets}");
            }
        }
        else Console.WriteLine("Нет домашних животных");

        Console.WriteLine("\nЛюбимые цвета:");
        foreach (var color in User.FavColors)
        {
            Console.WriteLine($"{color}");
        }
    }
}