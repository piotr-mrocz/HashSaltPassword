using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSaltPassword
{
    public static class HashSaltPassword
    {
        public static void GetHasPassword()
        {
            Console.Write("Wprowadź hasło: ");
            var password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Nie wprowadzono hasła!");
                return;
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine("HashPassword: " + hashPassword);
            Console.WriteLine();

            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            Console.WriteLine("Salt: " + salt);
            Console.WriteLine();

            var saltPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            Console.WriteLine("SaltPassword: " + saltPassword);
            Console.WriteLine();


            var saltPasswordEnhanced = BCrypt.Net.BCrypt.HashPassword(password, salt, true);
            Console.WriteLine("SaltPasswordEnhanced: " + saltPasswordEnhanced);
            Console.WriteLine();

            Console.Write("Wprowadź hasło do sprawdzenia uproszczonego: ");
            var passwordToVeryfy = Console.ReadLine();

            var veryfiedPassword = BCrypt.Net.BCrypt.Verify(passwordToVeryfy, saltPassword, false);
            Console.WriteLine("Wynik weryfikacji: " + veryfiedPassword);
            Console.WriteLine();

            Console.Write("Wprowadź hasło do sprawdzenia ulepszonego: ");
            var passwordToVeryfyEnhanced = Console.ReadLine();

            var passwordToVeryfyEnhancedHashed = BCrypt.Net.BCrypt.HashPassword(passwordToVeryfyEnhanced, BCrypt.Net.BCrypt.GenerateSalt(), true);
            Console.WriteLine("passwordToVeryfyEnhancedHashed: " + passwordToVeryfyEnhancedHashed);
            Console.WriteLine();

            var veryfiedPasswordEnhanced = BCrypt.Net.BCrypt.Verify(passwordToVeryfyEnhanced, passwordToVeryfyEnhancedHashed, true);
            Console.WriteLine("Wynik weryfikacji: " + veryfiedPasswordEnhanced);
            Console.WriteLine();
        }
    }
}
