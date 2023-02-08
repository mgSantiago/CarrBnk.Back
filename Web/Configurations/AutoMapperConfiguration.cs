using AutoMapper;
using Core.Entities;
using Infra.Models;

namespace App.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutomapperConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ClientEntity, ClientModel>();
                    cfg.CreateMap<ClientModel, ClientEntity>();
                }
            );

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
