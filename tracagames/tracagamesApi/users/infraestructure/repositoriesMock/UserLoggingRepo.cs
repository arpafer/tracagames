using tracagamesApi.users.models;

namespace tracagamesApi.users.infraestructure.repositoriesMock
{
    internal class UserLoggingRepo
    {
        private User user;

        internal UserLoggingRepo(User user)
        {
            this.user = user;
        }

        internal void load()
        {
            this.user = new User("user", "pass", "email@gmail.com");
        }

        internal void signUp()
        {
            this.user = new User("user", "pass", "email@gmail.com");
        }

        internal void signIn()
        {
            this.user = new User("user", "pass", "email@gmail.com", true);
        }

        internal void logout()
        {

        }
    }
}
