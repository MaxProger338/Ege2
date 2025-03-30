namespace Victory
{
    public class Question(string name, string[] answers, int trueAnswerNumber)
    {
        public string Name { get; } = name;

        public string[] Answers { get; } = answers;

        public int TrueAnswerNumber { get; } = trueAnswerNumber;
    }
}