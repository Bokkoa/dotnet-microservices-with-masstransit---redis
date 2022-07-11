using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Insfrastructure.EventBus
{
    public static class Extension
    {
        public static IServiceCollection AddRabbitMq( this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMq = new RabbitMqOption();
            configuration.GetSection("rabbitmq").Bind(rabbitMq);

            // establish connection with rabbitmq...
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitMq.ConnectionString), hostCfg =>
                    {
                        hostCfg.Username(rabbitMq.Username);
                        hostCfg.Username(rabbitMq.Password);
                    });
                }));
            });


            return services;

        }

    }
}
