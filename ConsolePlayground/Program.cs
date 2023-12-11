var random = new Random();

var initialSatiety = random.Next(1, 21);
var desiredSatiety = random.Next(11, 31);
var thirstLevel    = random.Next(1, 11);
var maxThirstLevel = 11;


var currentSatiety = initialSatiety;
var currentThirst  = thirstLevel;
Console.WriteLine($"Начальный уровень сытости кота {initialSatiety}");
Console.WriteLine($"Желаемый уровень сытости кота {desiredSatiety}");
Console.WriteLine($"Начальный уровень жажды кота {thirstLevel}");

while (currentSatiety < desiredSatiety)
{
    Console.WriteLine("Введите название еды: ");
    var foodName = Console.ReadLine();
    int foodValue;
    int thirstValue;


    switch (foodName)
    {
        case "рыба":
            foodValue   = 3;
            thirstValue = 1;
            break;
        case "курица":
            foodValue   = 4;
            thirstValue = 2;
            break;
        case "мясо":
            foodValue   = 5;
            thirstValue = 3;
            break;
        case "вода":
            foodValue   = 0;
            thirstValue = -3;
            break;

        default:
        {
            Console.WriteLine("Доступный выбор: курица, мясо, рыба, вода");
            continue;
        }
    }

    currentSatiety += foodValue;
    currentThirst  += thirstValue;

    Console.WriteLine($"Кот поел {foodName}. Текущий уровень сытости {currentSatiety}");
    Console.WriteLine($"Текущий уровень жажды {currentThirst}");


    if (maxThirstLevel < currentThirst)
    {
        Console.WriteLine("Кот хочет пить");
    }

    else if (initialSatiety >= desiredSatiety)
    {
        break;
    }
}

if (desiredSatiety < currentSatiety)
{
    Console.WriteLine("Коту пора на диету");
}

else
{
    Console.WriteLine("Кот сыт");
}