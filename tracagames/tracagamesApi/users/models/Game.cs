namespace tracagamesApi.users.models
{
    internal class Game
    {
        private string id;
        private string name;
        private string description;
        private string imageBase64;
        private List<User> usersPlaying;
        private List<User> guestUsers;

        internal Game(string id, string name, string description, string imageBase64)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.imageBase64 = imageBase64;
            this.usersPlaying = new List<User>();
            this.guestUsers = new List<User>();
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
            return new application.dtos.Game() { id = this.id, name = this.name, description = this.description, imageBase64 = this.imageBase64 };
        }
    }
}