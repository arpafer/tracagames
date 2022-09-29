using tracagamesApi.users.models;

namespace tracagamesApi.users.infraestructure.repositoriesMock
{
    internal class UserLoggingRepo: UserLoggingBaseRepoBase
    {        
        internal UserLoggingRepo(User user) : base(user)
        {     
        }

        internal override void load()
        {
            this.user = new User("user", "pass", "email@gmail.com");
        }

        internal override void signUp()
        {
            this.user = new User("user", "pass", "email@gmail.com");
        }

        internal override void signIn()
        {
            this.user.set("Antonio", "pass", "antonio.antoniopf@gmail.com", true);
        }

        internal override void logout()
        {
            this.user.set("Antonio", "pass", "antonio.antoniopf@gmail.com", false);
        }

        internal bool exist()
        {
            return true;
        }
    }
}
