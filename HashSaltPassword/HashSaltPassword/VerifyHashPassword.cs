using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSaltPassword;
public static class VerifyHashPassword
{
    public static string PasswordUser { get; set; } = null!;
    public static string PasswordUserHash { get; set; } = null!;
    public static string PasswordUserEnhanced { get; set; } = null!;

    public static void SetUserPassword()
    {
        Console.Write("Wprowadź hasło: ");
        var password = Console.ReadLine();

        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        Console.WriteLine("HashPassword: " + hashPassword);

        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        Console.WriteLine("Salt: " + salt);

        var saltPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        Console.WriteLine("SaltPassword: " + saltPassword);

        var saltPasswordEnhanced = BCrypt.Net.BCrypt.HashPassword(password, salt, true);
        Console.WriteLine("SaltPasswordEnhanced: " + saltPasswordEnhanced);
        Console.WriteLine();

        PasswordUser = saltPassword;
        PasswordUserEnhanced = saltPasswordEnhanced;
        PasswordUserHash = hashPassword;
    }

    public static void VerifyUserPasswordHash()
    {
        Console.Write("Wprowadź hasło do sprawdzenia hasowanego: ");
        var passwordToVeryfyHash = Console.ReadLine();

        var veryfiedPasswordHash = BCrypt.Net.BCrypt.Verify(passwordToVeryfyHash, PasswordUser);
        Console.WriteLine("Wynik weryfikacji tylko hasowanego hasła: " + veryfiedPasswordHash);
        Console.WriteLine();
    }

    public static void VerifyUserPassword()
    {
        Console.Write("Wprowadź hasło do sprawdzenia uproszczonego: ");
        var passwordToVeryfy = Console.ReadLine();

        var veryfiedPassword = BCrypt.Net.BCrypt.Verify(passwordToVeryfy, PasswordUser, false);
        Console.WriteLine("Wynik weryfikacji: " + veryfiedPassword);
        Console.WriteLine();
    }
    
    public static void VerifyUserPasswordEnhanced()
    {
        Console.Write("Wprowadź hasło do sprawdzenia ulepszonego: ");
        var passwordToVeryfyEnhanced = Console.ReadLine();

        var veryfiedPasswordEnhanced = BCrypt.Net.BCrypt.Verify(passwordToVeryfyEnhanced, PasswordUserEnhanced, true);
        Console.WriteLine("Wynik weryfikacji: " + veryfiedPasswordEnhanced);
        Console.WriteLine();
    }
}
