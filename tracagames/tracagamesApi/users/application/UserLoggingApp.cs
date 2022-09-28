using tracagamesApi.users.infraestructure.repositoriesMock;
using tracagamesApi.users.models;

namespace tracagamesApi.users.application
{
    public class UserLoggingApp
    {
        public dtos.User login(string userName)
        {
            User user = new User(userName, "", "");            
            new UserLoggingRepo(user).load();
            user.setLogged();
            return user.cloneToDto();
        }

        public dtos.User logout(string userName)
        {
            User user = new User(userName, "", "");
            new UserLoggingRepo(user).load();
            user.setLogout();
            return user.cloneToDto();
        }
       
    }
}
