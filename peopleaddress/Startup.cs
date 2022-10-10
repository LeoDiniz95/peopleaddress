using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using peopleaddress.GeneralData;
using peopleaddress.Repository;
using System.Text;

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
            services.AddCors();

            //services.AddTransient<ObjectDAO>();
            services.AddTransient<Pessoas>();
            services.AddTransient<Endereco>();
            services.AddTransient<User>();

            var key = Encoding.ASCII.GetBytes(_configuration["TokenAuth"]);

            services.AddAuthentication(x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

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

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();
        }
    }
}
