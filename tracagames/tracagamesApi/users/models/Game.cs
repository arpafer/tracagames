namespace tracagamesApi.users.models
{
    internal class Game
    {
        private string name;
        private string description;
        private List<User> usersPlaying;
        private List<User> guestUsers;

        internal Game(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        internal void addPlayer(User user)
        {
            this.usersPlaying.Add(user);
        }

        internal void addGuestUser(User user)
        {
            this.guestUsers.Add(user);
        }

        internal void removeGuestUser(User user)
        {
            this.guestUsers.Remove(user);
        }

        internal application.dtos.Game cloneToDto()
        {
            return new application.dtos.Game() { name = this.name, description = this.description };
        }
    }
}