using AutoMapper;

using ClientOrder.Service.Plain;

using ClientOrder.Data.Context;
using ClientOrder.Domain.Entities;
using ClientOrder.Domain.CudDto.CreateDto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ClientOrderWebApi
{
    public class Startup
    {
        private static ILoggerFactory loggerFactory;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            loggerFactory = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });

            services.AddDbContext<ClientOrderContext>(options =>
                                                      options.UseSqlServer(Configuration.GetConnectionString("ClientOrderConnection"))
                                                             .UseLoggerFactory(loggerFactory));
            services.AddScoped<ClientService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            var config = new MapperConfiguration(c => {
                            c.CreateMap<UpdateClientDto, Client>()
                                .ForMember(client => client.IsDirty, opt => opt.UseValue(true));
                            c.CreateMap<AddClientDto, Client>();
            });
        }
    }
}
