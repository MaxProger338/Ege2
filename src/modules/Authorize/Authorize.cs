namespace Victory
{
    public class Authorize
    {
        public static bool isInSystem(string login)
        {
            var userRepo = new UserRepository();

            foreach (var user in userRepo.GetAllUsers())
            {
                if (login == user.Login) return true;
            }

            return false;
        }

        public static User Auth(string login, string password)
        {
            if (!isInSystem(login)) throw new Exception($"\"{login}\" неверный логин или пароль!");    

            User user = new UserRepository().GetUserByLogin(login);
            if (password != user.Password)
                throw new Exception($"\"{password}\" неверный логин или пароль!");

            return user;
        }

        public static User Reg(string login, string password, string name, string birthday)
        {
            if (isInSystem(login)) throw new Exception($"\"{login}\" есть в системе!");

            var userRepo = new UserRepository();
            userRepo.SaveUser(new User(name, birthday, login, password));

            return Auth(login, password);
        }
    }
}