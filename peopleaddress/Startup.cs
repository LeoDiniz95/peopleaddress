using Microsoft.AspNetCore.Builder;
using peopleaddress.General;
using peopleaddress.GeneralData;
using peopleaddress.Repository;

namespace peopleaddress
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ObjectDAO>();
            services.AddTransient<Pessoas>();
            services.AddTransient<Endereco>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Avaliação Técnica");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
        }
    }
}
