
using HashSaltPassword;

Console.WriteLine("Hello, World!");
Console.WriteLine();

Console.WriteLine("Weryfikacja hasła usera");

VerifyHashPassword.SetUserPassword();

VerifyHashPassword.VerifyUserPasswordHash();
VerifyHashPassword.VerifyUserPassword();
VerifyHashPassword.VerifyUserPasswordEnhanced();

//Console.WriteLine("Person 1");
//Console.WriteLine();
//HashSaltPassword.HashSaltPassword.GetHasPassword();

//Console.WriteLine();
//Console.WriteLine();

//Console.WriteLine("Person 2");
//Console.WriteLine();
//HashSaltPassword.HashSaltPassword.GetHasPassword();
