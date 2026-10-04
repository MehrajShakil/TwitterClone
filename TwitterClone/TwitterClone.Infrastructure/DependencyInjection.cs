using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastructure.Repositories;

namespace TwitterClone.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Singletons because the repositories keep their data in memory.
            // Switch to scoped when they are backed by a real database (e.g. EF Core DbContext).
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITweetRepository, TweetRepository>();

            return services;
        }
    }
}
