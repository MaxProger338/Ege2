using Spectre.Console;
using System.Linq;

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

                if (Entry.Auth(ref user)) break;
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

                if (Entry.Reg(ref user)) break;
            }
            return user;
        }

        public static void CompleteVictory(User user)
        {
            Console.Clear();

            var quizRepo = new QuizRepository();
            int index = 1;
            string[] quizesNames = quizRepo.GetAllQuizes().Select(q => $"{index++}. {q.Name} ({q.Theme.Theme})").ToArray();

            var rule = new Rule("ВИКТОРИНА");
            AnsiConsole.Write(rule);

            int stage = Int32.Parse(AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( Colors.Format("white", "Какая тема?\n") )
                    .PageSize(10)
                    .AddChoices(quizesNames)
            ).Split(".")[0]) - 1;

            Quiz quiz = quizRepo.GetAllQuizes().ToArray()[stage];
            user.CompleteVictory(quiz);
        }

        public static void Exit()
        {
            Console.Clear();
            Colors.Print("purple", "Досвидания\n");
        }

        public static bool ShowChoose(User user)
        {
            Console.Clear();

            var rule = new Rule("СИСТЕМА ТЕСТИРОВАНИЯ");
            AnsiConsole.Write(rule);

            var stage = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( Colors.Format("white", "Что делаем?\n") )
                    .PageSize(10)
                    .AddChoices(new[] {
                        COMPLETE_VICTORY, "Выход"
            }));

            switch (stage)
            {
                case COMPLETE_VICTORY: CompleteVictory(user); break;
                default:               return true;
            }

            return false;
        }

        public static void Main()
        {
            // var quizRepo = new QuizRepository();
            // quizRepo.SaveQuiz(new Quiz("Number 1", new QuizTheme("География"), 
            //     new[] {
            //         new Question("Столица Нигерии?", new[] {"Абуджа", "Ниамей", "Коншаса", "Могадишо"}, 0),
            //         new Question("Столица Китая?", new[] {"Китай", "Поднебесная", "Ли Си Цин", "Пекин"}, 3),
            //     }
            // ));
            // quizRepo.SaveQuiz(new Quiz("Number 2", new QuizTheme("Программирование"), 
            //     new[] {
            //         new Question("Самой большой тип данных в Си?", new[] {"long long", "long double", "float", "double"}, 1),
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
            if (user == null) {
                Colors.Print("red", "Пользователь не получен!\n"); return;
            }
            Console.Clear();
            
            while (true) {
                if (ShowChoose(user)) {   
                    Exit(); 
                    return;
                }
            }
            Console.Clear();

        }
    }
}