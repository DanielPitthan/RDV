using BLL.AccountsBLL;
using BLL.Admin.Interfaces;
using BLL.Admin.Services;
using ContexBinds.EntityCore;
using ContextBinds;
using DAL.Admin.DAO;
using DAL.Admin.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Models.Admin;
using Models.Admin.Settings;
using System.Text;

namespace RDV
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string SefOriginsRequest = "AllowRequestByTheSameOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ApplicationDbContext - Contexto de controle de login
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                              
                options.UseSqlServer(ConecxaoAtiva.StringConnection());
            },
                ServiceLifetime.Scoped
            );

            //DbContext - Usado para a persistência dos DAL
            services.AddDbContext<ContextBind>(options =>
            {
                options.UseSqlServer(ConecxaoAtiva.StringConnection());
            },
               ServiceLifetime.Scoped
           );

            

            //Identity
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>() //Provider para acesso 
                .AddDefaultTokenProviders(); //Gerador de tokens aleatórios (Confirmação de e-mail) 



            //JWT
            var appSettingsSection = Configuration.GetSection("JWTAppSettings");
            services.Configure<JWTAppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<JWTAppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,            //Valida se o Issuer é válido 
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,                  //Indica que se deve validar a origem do token
                    ValidateAudience = true,                //indica se vai validar uma url específica
                    ValidAudience = appSettings.ValidoEm,  //(IEnumerable) ValidAudiences caso esteva trabalhando com micro serviços 
                    ValidIssuer = appSettings.Emissor     //(IEnumerable) ValidIssuers caso esteva trabalhando com micro serviços 
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(SefOriginsRequest, builder =>
                {
                    builder.WithOrigins().AllowAnyHeader()
                                        .AllowAnyOrigin()
                                        .AllowAnyMethod();
                });
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
         
            #region Injeções de Dependencia
           
            services.AddScoped<IUsuarioDAO, UsuarioDAO>();
            services.AddScoped<IUserClaimDAO, UserClaimDAO>();
            services.AddScoped<IEmpresaDAO, EmpresaDAO>();
            services.AddScoped<IEmpresaRegraDAO, EmpresaRegraDAO>();
            services.AddScoped<IUserTokenDAO, UserTokenDAO>();

            services.AddScoped<IUsuarioBLL, UsuarioBLL>();
            services.AddScoped<ITokenGeradorBLL, TokenGeradorBLL>();
            services.AddScoped<IClaimsControleBLL, ClaimsControleBLL>();
            services.AddScoped<IEmpresaBLL, EmpresaBLL>();

            #endregion

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(SefOriginsRequest);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();        //Antes do MVC Sempre!

            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllers();
            });

        }
    }
}
