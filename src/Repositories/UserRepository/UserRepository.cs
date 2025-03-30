using System.Collections.Generic;
using System.Text.Json;

namespace Victory
{
    public class UserRepository
    {
        private const string PATH = "data/users.json";

        public List<User> GetAllUsers()
        {
            if (!File.Exists(PATH))
                return new List<User>();

            string json = File.ReadAllText(PATH);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        private void SaveAllUsers(List<User> users)
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // Красивый JSON
            string json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(PATH, json);
        }

        public void SaveUser(User user)
        {
            var users = GetAllUsers();
            var existingUser = users.FirstOrDefault(u => u.Login == user.Login);

            if (existingUser != null) existingUser.Score = user.Score;
            else users.Add(user);

            SaveAllUsers(users);
        }

        public User GetUserByLogin(string login)
        {
            return GetAllUsers()
                .FirstOrDefault(u => u.Login == login);
        }
    }
}