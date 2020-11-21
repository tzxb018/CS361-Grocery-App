using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _361Example
{
    /**
     * This is the driver class of the program.
     * The Program class contains the main method for the program,
     * which builds the host of the web app and runs the web app.
     **/
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //The Web Builder uses the Startup class, which configures the web app's services and HTTP requests
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
