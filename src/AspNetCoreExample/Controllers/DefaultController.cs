// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreExample.Controllers
{
    using Core;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Extensions.Logging;
    using Serilog;

    public class DefaultController : Controller
    {
        private ILogger<DefaultController> logger;
        private ICoreLibraryService coreLibraryService;

        public DefaultController(ILogger<DefaultController> logger, ICoreLibraryService coreLibraryService)
        {
            this.logger = logger;
            this.coreLibraryService = coreLibraryService;
        }

        public IActionResult Index()
        {
//            logger.LogWarning("In Controller"); // Using the framework to log
//            Log.Logger.Information("Serilog: In Controller"); // Using Serilog to log
            Log.Logger.Information(coreLibraryService.CreateMessage());

            ViewBag.Title = "AspNet Core Example";

            return View();
        }
    }
}
