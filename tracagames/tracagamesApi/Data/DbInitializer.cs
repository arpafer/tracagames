using tracagamesApi.users.models;

namespace tracagamesApi.Data
{
    internal static class DbInitializer
    {
        internal static void Initialize(GameContext context)
        {            
            context.SaveChanges();
        }
    }
}
