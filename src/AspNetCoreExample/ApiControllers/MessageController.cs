// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreExample.ApiControllers
{
    using Microsoft.AspNet.Mvc;

    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return "message from server";
        }

    }
}
