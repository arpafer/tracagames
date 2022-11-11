using System.Diagnostics;
namespace tracagamesApi.users.models
{
   internal class WaitingRoom {
       private List<User> players;
        private string gameName;

        internal WaitingRoom(string gameName)
        {
            this.players = new List<User>();
            this.gameName = gameName;
        }

        internal void add(User user) {

          Debug.Assert(user != null);
          this.players.Add(user);
       }

       internal void remove(User user) {
          Debug.Assert(user != null);
          this.players.Remove(user);
       }

       internal List<User> getAll() {
         return this.players;
       }

        internal tracagamesApi.users.application.dtos.WaitingRoom cloneToDto()
        {
            tracagamesApi.users.application.dtos.WaitingRoom waitingRoomDto = new tracagamesApi.users.application.dtos.WaitingRoom();
            foreach (User user in this.players)
            {
                // waitingRoomDto.players.Add(user.cloneToDto());
            }
            return waitingRoomDto;
        }
    }
}