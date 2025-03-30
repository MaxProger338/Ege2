using static System.Console;
using System.Text.RegularExpressions;

namespace Victory
{
    static class Entry
    {
        private static string[] errors; 

        private static bool isCorrectData(string enter, int fieldNumber, Func<string, string> validate)
        {
            if (errors[fieldNumber] != "") Colors.Print("red", $"({errors[fieldNumber]}) ");
            Colors.Print("white", enter);
            string data = Console.ReadLine();

            string error = validate(data);
            bool isValid = error == "";
            if (isValid == false)
                errors[fieldNumber] = $"\"{data}\" {error}";

            return isValid;
        }

        public static void Auth()
        {

        }

        public static bool Reg()
        {
            string login, password, name, birthday;
            errors ??= ["", "", "", ""];

            isCorrectData("Введите логин: ", 0, data => "");

            isCorrectData("Введите пароль: ", 1, data => "");

            isCorrectData("Введите имя: ", 2, data => "");

            isCorrectData("Введите дату рождения (dd.mm.yyyy): ", 3, 
                data => Regex.IsMatch(data, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") == false ? "Дебил" : ""
            );

            if (true) return false;
            errors = null;
            return true;
        }
    }
}