using Microsoft.EntityFrameworkCore;

namespace tracagamesApi.users.models
{
    public class GameContext: DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        internal DbSet<User> Users => Set<User>();
        internal DbSet<WaitingUser> WaitingUsers => Set<WaitingUser>();        
    }
}
