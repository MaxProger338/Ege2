namespace Victory
{
    class User(string name, string birthday, string login, string password)
    {
        public string Name { get; set; } = name;
        public string Birthday { get; set; /* ... */ } = birthday;

        public string Login { get; set; } = login;
        public string Password { get; set; } = password;
    }
}