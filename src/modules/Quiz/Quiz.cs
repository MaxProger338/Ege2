namespace Victory
{
    public class Quiz(string name, QuizTheme theme, Question[] questions)
    {
        public string Name { get; } = name;

        public QuizTheme Theme { get; } = theme;

        public Question[] Questions { get; } = questions;
    }
}