using System.Text;
class Program
{
    static string firstName = string.Empty;
    static string middleName = string.Empty;
    static string lastName = string.Empty;
    static string email = string.Empty;
    static string github = string.Empty;
    static int age = 0;
    static void ReadData()
    {
        Console.WriteLine("Введите данные");
        Console.Write("Фамилия: ");
        lastName = Console.ReadLine()!;
        Console.Write("Имя: ");
        firstName = Console.ReadLine()!;
        Console.Write("Отчество: ");
        middleName = Console.ReadLine()!;
        Console.Write("Возраст: ");

        if (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Не удалось получить возраст");
            age = 0;
        }

        Console.Write("Email: ");
        email = Console.ReadLine();
        Console.Write("GitHub: ");
        github = Console.ReadLine();
        Console.Clear();
    }
    static void WriteData()
    {
        Console.WriteLine("Персональные данные");
        Console.WriteLine($"\tФамилия: {lastName}");
        Console.WriteLine($"\tИмя: {firstName}");
        Console.WriteLine($"\tОтчество: {middleName}");
        Console.WriteLine($"\tВозраст: {age}");
        Console.WriteLine("Контакты");
        Console.WriteLine($"\tEmail: {email}");
        Console.WriteLine($"\tGitHub: {github}");
    }
    static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        Console.InputEncoding = Encoding.GetEncoding(1251);
        ReadData();
        WriteData();
    }
}

