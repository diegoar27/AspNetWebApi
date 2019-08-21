using AutoMapper;
using InsuranceCompany.API.Domain.Repositories;
using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Infrastructure.Data;
using InsuranceCompany.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCompany
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();

            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddAutoMapper(typeof(Startup));

            ConfigureAdditionalServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        protected virtual void ConfigureAdditionalServices(IServiceCollection services)
        {
        }   
    }
}
