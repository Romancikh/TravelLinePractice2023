using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = Encoding.GetEncoding(1251);
Console.InputEncoding = Encoding.GetEncoding(1251);
Console.Write("Фамилия: ");
string lastName = Console.ReadLine();
Console.Write("Имя: ");
string firstName = Console.ReadLine();
Console.Write("Отчество: ");
string middleName = Console.ReadLine();
Console.Write("Возраст: ");
if (!int.TryParse(Console.ReadLine(), out int age))
{
    Console.WriteLine("Не удалось получить возраст");
    age = 0;
}
Console.Write("Email: ");
string email = Console.ReadLine();
Console.Write("GitHub: ");
string github = Console.ReadLine();
Console.WriteLine();
Console.WriteLine("Персональные данные");
Console.WriteLine($"\tФамилия: {lastName}");
Console.WriteLine($"\tИмя: {firstName}");
Console.WriteLine($"\tОтчество: {middleName}");
Console.WriteLine($"\tВозраст: {age}");
Console.WriteLine($"\tEmail: {email}");
Console.WriteLine($"\tGitHub: {github}");
