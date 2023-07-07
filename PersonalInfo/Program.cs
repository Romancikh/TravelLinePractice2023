using System.Text;
using System.Text.RegularExpressions;

bool IsValidEmail( string email )
{
    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    return Regex.IsMatch( email, pattern );
}

Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
Console.OutputEncoding = Encoding.GetEncoding( 1251 );
Console.InputEncoding = Encoding.GetEncoding( 1251 );

Console.WriteLine( "Введите данные" );
Console.Write( "Фамилия: " );
string lastName = Console.ReadLine();
Console.Write( "Имя: " );
string firstName = Console.ReadLine();
Console.Write( "Отчество: " );
string middleName = Console.ReadLine();
Console.Write( "Возраст: " );

bool isValidAge = int.TryParse( Console.ReadLine(), out int age );
while ( !isValidAge || age <= 0 )
{
    Console.WriteLine( "Некорректный возраст. Пожалуйста, введите положительное число." );
    isValidAge = int.TryParse( Console.ReadLine(), out age );
}

Console.Write( "Email: " );
string email = Console.ReadLine();
while ( !IsValidEmail( email ) )
{
    Console.WriteLine( "Некорректный email. Пожалуйста, введите корректный email." );
    email = Console.ReadLine();
}

Console.Write( "GitHub: " );
string github = Console.ReadLine();
Console.Clear();

Console.WriteLine(
$@"Персональные данные
    Фамилия: {lastName}
    Имя: {firstName}
    Отчество: {middleName}
    Возраст: {age}
Контакты
    Email: {email}
    GitHub: {github}"
);
