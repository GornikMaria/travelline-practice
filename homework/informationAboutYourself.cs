
// Считываем информацию о себе
Console.WriteLine("Введите информацию о себе:");
Console.Write("ФИО: ");
string fullName = Console.ReadLine();

Console.Write("Возраст: ");
int age = int.Parse(Console.ReadLine());

Console.Write("Email: ");
string email = Console.ReadLine();

Console.Write("GitHub: ");
string github = Console.ReadLine();

Console.WriteLine();

// Выводим информацию о себе с отступами
string FIO = "ФИО: ";
string Addresses = "Адреса:";
string Email = "Email:";
string GitHub = "GitHub:";
string Age = "Возраст: ";

Console.WriteLine("Информация о пользователе:");
Console.WriteLine($"{FIO, 0}{fullName, 0}");
Console.WriteLine($"{Age,0}{age,0}");
Console.WriteLine($"{Addresses}");
Console.WriteLine($"{Email, 7}{email}");
Console.WriteLine($"{GitHub, 8}{github}");

/*
 * 
 * Console.WriteLine("Информация о пользователе:");
Console.WriteLine($"{FIO, 0}{fullName, 0}");
Console.WriteLine($"{Age, 0}{age, 0}");
Console.WriteLine($"{Addresses}");
Console.WriteLine($"{Email, 7}{email, 0}");
Console.WriteLine($"{GitHub, 8}{github, 0}");
string name = "Tom";
int age = 23;

Console.WriteLine($"Имя: {name,-5} Возраст: {age}"); // пробелы после
Console.WriteLine($"Имя: {name,5} Возраст: {age}"); // пробелы до
*/