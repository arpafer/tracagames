using tracagamesApi.users.application.exceptions;
using tracagamesApi.users.application.types;
using tracagamesApi.users.infraestructure.repositoriesMock;
using tracagamesApi.users.models;

namespace tracagamesApi.users.application
{
    public class UserLoggingApp
    {
        public dtos.User login(dtos.User userDto)
        {
            User user = new User("", userDto.email, "");            
            new UserLoggingRepo(user).signIn();
            user.setLogged();
            return user.cloneToDto();
        }

        public dtos.User logout(dtos.User userDto)
        {
            User user = new User("", userDto.email, "");
            new UserLoggingRepo(user).logout();
            user.setLogout();
            return user.cloneToDto();
        }
       
        public dtos.User signUp(dtos.User userDto)
        {
            User user = new User(userDto.userName, userDto.password, userDto.email);
            UserLoggingRepo userRepo = new UserLoggingRepo(user);
            if (!userRepo.exist())
                userRepo.signUp();
            else
                throw new UserException(ErrorMessage.USER_EXIST);

            return user.cloneToDto();
        }
    }
}
