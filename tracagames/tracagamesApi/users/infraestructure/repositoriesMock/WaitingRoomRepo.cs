using tracagamesApi.users.models;
using Microsoft.EntityFrameworkCore;

namespace tracagamesApi.users.infraestructure.repositoriesMock
{
    public class WaitingRoomRepo
    {        
        private List<WaitingUser> waitingUsers;
        private readonly GameContext _context;

        public WaitingRoomRepo(GameContext context)
        {
           this.waitingUsers = new List<WaitingUser>();
           this._context = context;
        }
               
        internal List<WaitingUser> loadAll(string gameName)
        {
            return this._context.WaitingUsers
                   .Include(u => u.user)
                   .Where(u => u.gameName == gameName)                   
                   .ToList();      
        }

        internal WaitingUser add(WaitingUser waitingUser)
        {
            this._context.WaitingUsers.Add(waitingUser);
            this._context.SaveChanges();
            return waitingUser;
        }

        internal WaitingUser delete(WaitingUser waitingUser)
        {
            List<WaitingUser> waitingUsersFilter = this._context.WaitingUsers
                .Where(u => u.user.email == waitingUser.user.email && u.gameName == waitingUser.gameName).ToList();
            
            if (waitingUsersFilter is not null && waitingUsersFilter.Count > 0)
            {                                
                _context.WaitingUsers.Remove(waitingUsersFilter[0]);
                _context.SaveChanges();
            }
            return waitingUser;
        }

        internal WaitingUser getWaitingUser(string email, string gameName)
        {            
            List<WaitingUser> aux = this._context.WaitingUsers
                .Where(u => u.user.email == email && u.gameName == gameName).ToList();
            return aux.Count > 0 ? aux[0] : null;
        }
    }
}