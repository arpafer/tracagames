using tracagamesApi.users.models;

namespace tracagamesApi.users.infraestructure.repositoriesMock
{
    public class UserGameRepo
    {
        private User user;

        internal UserGameRepo(User user)
        {
            this.user = user;
        }

        internal void loadAll()
        {

        }
    }
}
