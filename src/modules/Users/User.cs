using Spectre.Console;

namespace Victory
{
    public class User(string name, string birthday, string login, string password)
    {
        public string Name { get; set; } = name;
        public string Birthday { get; set; /* ... */ } = birthday;

        public string Login { get; set; } = login;
        public string Password { get; set; } = password;

        public Dictionary<string, int> Score { get; set; } = new Dictionary<string, int>();

        public void ShowResultsAfterVictory(Quiz quiz)
        {
            Console.Clear();

            var rule = new Rule("Результаты");
            AnsiConsole.Write(rule);

            int procent = (int)((float)Score[quiz.Name] / quiz.Questions.Length * 100f);
            AnsiConsole.Write(
                new FigletText($"{Score[quiz.Name]} / {quiz.Questions.Length.ToString()} ({procent}%)")
                    .LeftJustified()
                    .Color(Color.Red));

            Console.ReadLine();
        }

        public void CompleteVictory(Quiz quiz)
        {
            Console.Clear();

            Score[quiz.Name] = 0; 

            int index = 1;
            int amountTrueAnswers = 0;
            foreach(var question in quiz.Questions)
            {
                int answerIndex = 1;

                Console.Clear();
                
                var rule = new Rule(quiz.Name);
                AnsiConsole.Write(rule);

                int stage = Int32.Parse(AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title( Colors.Format("white", $"{index++}. {question.Name}\n") )
                        .PageSize(10)
                        .AddChoices(question.Answers.Select(q => $"{answerIndex++}. {q}"))
                ).Split(".")[0]) - 1;

                if (stage == question.TrueAnswerNumber)
                    Score[quiz.Name]++;
            }

            var userRepo = new UserRepository();
            userRepo.SaveUser(this);

            ShowResultsAfterVictory(quiz);
        }
    }
}