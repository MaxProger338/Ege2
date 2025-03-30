using System.Collections.Generic;
using System.Text.Json;

namespace Victory
{
    public class QuizRepository
    {
        private const string PATH = "data/quizes.json";

        public List<Quiz> GetAllQuizes()
        {
            if (!File.Exists(PATH))
                return new List<Quiz>();

            string json = File.ReadAllText(PATH);
            return JsonSerializer.Deserialize<List<Quiz>>(json) ?? new List<Quiz>();
        }

        private void SaveAllQuizes(List<Quiz> quizes)
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // Красивый JSON
            string json = JsonSerializer.Serialize(quizes, options);
            File.WriteAllText(PATH, json);
        }

        public void SaveQuiz(Quiz quiz)
        {
            var quizes = GetAllQuizes();
            var existingQuiz = quizes.FirstOrDefault(u => u.Name == quiz.Name);

            if (existingQuiz == null)
                quizes.Add(quiz);

            SaveAllQuizes(quizes);
        }

        // Получить пользователя по логину
        public Quiz GetQuizByName(string name)
        {
            return GetAllQuizes()
                .FirstOrDefault(u => u.Name == name);
        }
    }
}