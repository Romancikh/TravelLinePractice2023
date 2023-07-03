using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.Write("Фамилия: ");
string FirstName = Console.ReadLine();
Console.Write("Имя: ");
string LastName = Console.ReadLine();
Console.Write("Отчество: ");
string MiddleName = Console.ReadLine();
Console.Write("Возраст: ");
if (!int.TryParse(Console.ReadLine(), out int age))
{
    Console.WriteLine("Не удалось получить возраст");
}
Console.Write("Email: ");
string email = Console.ReadLine();
Console.Write("GitHub: ");
string github = Console.ReadLine();
