using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Get()
        {
            return Content("Hello world");
        }
    }
}
