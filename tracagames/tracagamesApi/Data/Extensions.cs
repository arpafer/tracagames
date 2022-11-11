using tracagamesApi.users.models;

namespace tracagamesApi.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<GameContext>();
                    if (context.Database.EnsureCreated())
                    {
                        DbInitializer.Initialize(context);
                    }
                }
            }
        }

        public static GameContext context(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                return services.GetRequiredService<GameContext>();
            }
        }
    }
}
