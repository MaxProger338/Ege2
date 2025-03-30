using Spectre.Console;

namespace Victory
{
    class Program
    {
        public const string AUTH              = "Авторизация";
        public const string REG               = "Регистрация";
        public const string COMPLETE_VICTORY  = "Пройти викторину";
        
        public static User Auth()
        {
            User user = null; 

            while (true) {
                Console.Clear();
                var stage = new Rule("Авторизация");
                AnsiConsole.Write(stage);

                if (Entry.Auth(user)) break;
            }
            return user;
        }

        public static User Reg()
        {
            User user = null; 

            while (true) {
                Console.Clear();
                var stage = new Rule("Регистрация");
                AnsiConsole.Write(stage);

                if (Entry.Reg(user)) break;
            }
            return user;
        }

        public static void CompleteVictory()
        {

        }

        public static void Exit()
        {
            Console.Clear();
            Colors.Print("purple", "Досвидания\n");
        }

        public static bool ShowChoose()
        {
            Console.Clear();

            var rule = new Rule("СИСТЕМА ТЕСТИРОВАНИЯ");
            AnsiConsole.Write(rule);

            var stage = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( Colors.Format("white", "Что делаем?\n") )
                    .PageSize(10)
                    .AddChoices(new[] {
                        COMPLETE_VICTORY
            }));

            switch (stage)
            {
                case COMPLETE_VICTORY: CompleteVictory(); break;
                default:               return true;
            }

            return false;
        }

        public static void Main()
        {
            // var quizRepo = new QuizRepository();
            // quizRepo.SaveQuiz(new Quiz("Number 1", new QuizTheme("Geography"), 
            //     new[] {
            //         new Question("Столица Нигерии?", new[] {"Абуджа", "Ниамей", "Коншаса", "Могадишо"}, 0)
            //     }
            // ));
            Console.Clear();
            User user = null;

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
                case AUTH: user = Auth(); break;
                case REG:  user = Reg();  break;
                default:   Exit();        return;
            }
            if (user == null) return;
            Console.Clear();

            
            while (true) {
                if (ShowChoose()) Exit(); return;
            }
            Console.Clear();

        }
    }
}