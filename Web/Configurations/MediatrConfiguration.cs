using MediatR;

namespace App.Configurations
{
    public static class MediatrConfiguration
    {
        public static void AddMediatrConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Program));
        }
    }
}
