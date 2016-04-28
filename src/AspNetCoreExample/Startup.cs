namespace AspNetCoreExample
{
    using Core;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;
    using Serilog;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<ICoreLibraryService, CoreLibraryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationEnvironment appEnv,
            ILoggerFactory loggerFactory)
        {
            app.Map(
                Configuration["VirtualDir"],
                (virtualDir) => ConfigureWithVirtualDirectory(virtualDir, env, appEnv, loggerFactory));
        }

        public void ConfigureWithVirtualDirectory(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationEnvironment appEnv,
            ILoggerFactory loggerFactory)
        {
            appEnv.SetData("Environment", Configuration["Environment"]);

//            if (env.IsDevelopment())
//            {
                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                //app.UseExceptionHandler("/Home/Error");
//            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });

            // this will serve up wwwroot
            app.UseFileServer();

            // this will serve up node_modules
//                var provider = new PhysicalFileProvider(
//                    Path.Combine(appEnv.ApplicationBasePath, "node_modules")
//                    );
//                var options = new FileServerOptions();
//                options.RequestPath = "/node_modules";
//                options.StaticFileOptions.FileProvider = provider;
//                options.EnableDirectoryBrowsing = true;
//                app.UseFileServer(options);

            loggerFactory.MinimumLevel = LogLevel.Warning; // Set the framework logging level
            loggerFactory.AddSerilog(); // To tie into the framework logging and write all of its events
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}