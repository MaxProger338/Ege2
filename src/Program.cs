﻿using Spectre.Console;

namespace Victory
{
    class Program
    {
        public const string AUTH = "Авторизация";
        public const string REG  = "Регистрация";
        
        public static void Auth()
        {
            Console.Clear();
            var stage = new Rule("Авторизация");
            AnsiConsole.Write(stage);

            Entry.Auth();
        }

        public static void Reg()
        {
            while (true) {
                Console.Clear();
                var stage = new Rule("Регистрация");
                AnsiConsole.Write(stage);

                if (Entry.Reg()) break;
            }
        }

        public static void Exit()
        {
            Console.Clear();
        }

        public static void Main()
        {
            Console.Clear();

            var rule = new Rule("СИСТЕМА ТЕСТИРОВАНИЯ");
            AnsiConsole.Write(rule);

            var stage = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( Colors.Format("white", "Что делаем?\n") )
                    .PageSize(10)
                    .AddChoices(new[] {
                        AUTH, REG, "Выход"
            }));

            switch (stage)
            {
                case AUTH: Auth(); break;
                case REG:  Reg();  break;
                default:   Exit(); break;
            }

        }
    }
}