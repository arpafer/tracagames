using tracagamesApi.users.models;

namespace tracagamesApi.users.infraestructure
{
    abstract internal class UserLoggingBaseRepoBase
    {
        protected User user;

        internal UserLoggingBaseRepoBase(User user)
        {
            this.user = user;
        }
        
        abstract internal void load();

        abstract internal void signUp();

        abstract internal void signIn();

        abstract internal void logout();        
    }
}
