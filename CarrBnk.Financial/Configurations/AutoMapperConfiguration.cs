using AutoMapper;

namespace App.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutomapperConfiguration(this IServiceCollection services)
        {
            //TODO: Validar se vou precisar mesmo do Automapper
            var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<string, string>();
                }
            );

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
