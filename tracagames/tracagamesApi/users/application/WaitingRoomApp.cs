using System.Globalization;
using tracagamesApi.users.models;
using tracagamesApi.users.infraestructure.repositoriesMock;
using tracagamesApi.Data;
using tracagamesApi.users.application.mappers;

namespace tracagamesApi.users.application
{
    internal class WaitingRoomApp
    {
         WaitingRoomRepo waitingRoomRepo;

        internal WaitingRoomApp(tracagamesApi.users.infraestructure.repositoriesMock.WaitingRoomRepo waitingRoomRepo) {
           this.waitingRoomRepo = waitingRoomRepo;
        }

        internal List<dtos.WaitingUser> loadWaitingUsers(string gameName)
        {
            List<dtos.WaitingUser> result = new List<dtos.WaitingUser>();           
           List<WaitingUser> waitingUsers= waitingRoomRepo.loadAll(gameName);
           foreach (WaitingUser waitingUser in waitingUsers) {            
              result.Add(new MappingFromModelToDto().map(waitingUser));
           }   
           return result;
        }

        internal dtos.WaitingUser Add(dtos.WaitingUser waitingUser) {
            WaitingUser _waitingUser = waitingRoomRepo.add(new MappingFromDtoToModel().map(waitingUser));            
            return new MappingFromModelToDto().map(_waitingUser);
        }

        internal dtos.WaitingUser GetWaitingUser(string email, string gameName)
        {
            WaitingUser _waitingUser = waitingRoomRepo.getWaitingUser(email, gameName);
            if (_waitingUser != null)
               return new MappingFromModelToDto().map(_waitingUser);
            return null;
        }

        internal dtos.WaitingUser Delete(dtos.WaitingUser waitingUser)
        {
            WaitingUser _waitingUser = waitingRoomRepo.delete(new MappingFromDtoToModel().map(waitingUser));
            return new MappingFromModelToDto().map(_waitingUser);
        }
    }
}