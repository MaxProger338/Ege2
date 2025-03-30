using static System.Console;
using System.Text.RegularExpressions;

namespace Victory
{
    public static class Entry
    {
        private static string[] errors; 

        private static string isCorrectData(string enter, ref string errorField, Func<string, string> validate)
        {
            if (errorField != "") Colors.Print("red", $"({errorField}) ");
            Colors.Print("white", enter);
            string data = Console.ReadLine();

            string error = validate(data);
            if (error != "")
                errorField = $"\"{data}\" {error}";
            else
                errorField = "";

            return data;
        }

        public static bool Auth(User? user)
        {
            string login, password;
            errors ??= ["", ""];

            // login = isCorrectData("Введите логин: ", ref errors[0], data => !Authorize.isInSystem(data) ? "неверный логин или пароль" : "");
            login    = isCorrectData("Введите логин: ",  ref errors[0], data => "");
            password = isCorrectData("Введите пароль: ", ref errors[1], data => "");

            try
            {
                user = Authorize.Auth(login, password);
            }
            catch (Exception e)
            {
                Colors.Print("red", $"{e.Message}\n");
            }

            foreach (string error in errors) 
                if (error != "") return false;
            errors = null;

            return true;
        }

        public static bool Reg(User? user)
        {
            string login, password, name, birthday;
            errors ??= ["", "", "", ""];

            // login = isCorrectData("Введите логин: ", ref errors[0], data => Authorize.isInSystem(data) ? "есть в системе" : "");
            login    = isCorrectData("Введите логин: ",  ref errors[0], data => "");
            password = isCorrectData("Введите пароль: ", ref errors[1], data => "");
            name     = isCorrectData("Введите имя: ",    ref errors[2], data => "");
            birthday = isCorrectData("Введите дату рождения (dd.mm.yyyy): ", ref errors[3], 
                data => !Regex.IsMatch(data, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") ? "неверный формат" : ""
            );

            try
            {
                user = Authorize.Reg(login, password, name, birthday);
            }
            catch (Exception e)
            {
                Colors.Print("red", $"{e.Message}\n");
            }

            foreach (string error in errors) 
                if (error != "") return false;
            errors = null;

            return true;
        }
    }
}