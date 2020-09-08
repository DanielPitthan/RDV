using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RDV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //CultureInfo ci = new CultureInfo("pt-br");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
