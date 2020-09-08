using BLL.AccountsBLL;
using BLL.Admin.Interfaces;
using BLL.Admin.Services;
using BLL.Cadastros.CentroCustos.Interfaces;
using BLL.Cadastros.CentroCustos.Services;
using BLL.Despesas.Interfaces;
using BLL.Despesas.Services;
using BLL.Infra;
using ContexBinds.EntityCore;
using ContextBinds;
using DAL.Admin.DAO;
using DAL.Admin.Interfaces;
using DAL.Cadastros.CentroCustos.DAO;
using DAL.Cadastros.CentroCustos.Interfaces;
using DAL.Despesas.DAO;
using DAL.Despesas.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
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
using System;
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
                ServiceLifetime.Transient
            );

            //DbContext - Usado para a persistência dos DAL
            services.AddDbContext<ContextBind>(options =>
            {
                options.UseSqlServer(ConecxaoAtiva.StringConnection());
            },
               ServiceLifetime.Transient
           );



            //Identity
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>() //Provider para acesso 
                .AddDefaultTokenProviders() //Gerador de tokens aleatórios (Confirmação de e-mail) 
                .AddErrorDescriber<CustomIdentityErrorDescriber>();//Translate de Identity to Pt-Br

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


            //Habilita a autenticação via aplicação 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/loginView";
                    options.LogoutPath = "/loginView";

                });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(48);
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
            services.AddHttpContextAccessor();


            #region Injeções de Dependencia
            //   services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUsuarioDAO, UsuarioDAO>();
            services.AddTransient<IUsuarioBLL, UsuarioBLL>();
            services.AddTransient<IUserClaimDAO, UserClaimDAO>();
            services.AddTransient<IClaimsControleBLL, ClaimsControleBLL>();
            services.AddTransient<IEmpresaDAO, EmpresaDAO>();
            services.AddTransient<IEmpresaRegraDAO, EmpresaRegraDAO>();
            services.AddTransient<IEmpresaBLL, EmpresaBLL>();
            services.AddTransient<IUserTokenDAO, UserTokenDAO>();
            services.AddTransient<ITokenGeradorBLL, TokenGeradorBLL>();
            services.AddTransient<ITipoDespesaDAO, TipoDespesaDAO>();
            services.AddTransient<ITipoDespesaService, TipoDespesaService>();

            services.AddTransient<IDespesaDAO, DespesaDAO>();
            services.AddTransient<IDespesaHeaderDAO, DespesaHeaderDAO>();
            services.AddTransient<IDespesaService, DespesaService>();
            services.AddTransient<IDespesaService, DespesaService>();

            services.AddTransient<ICentroCustoDAO, CentroCustoDAO>();
            services.AddTransient<ICentroCustoService, CentroCustoService>();

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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllers();
            });

        }
    }
}
