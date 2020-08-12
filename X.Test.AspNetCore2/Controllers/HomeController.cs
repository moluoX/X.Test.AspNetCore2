using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using X.Test.AspNetCore2.Models;
using X.Test.AspNetCore2.Service;

namespace X.Test.AspNetCore2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private IAService _a;
        private readonly IUserService _service;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IAService a, IUserService service) => (_logger, _configuration, _a, _service) = (logger, configuration, a, service);

        public async Task<IActionResult> Index()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                user = $"用户{_configuration["urls"]}";
                HttpContext.Session.SetString("User", user);
            }
            ViewBag.User = user;

            _a.Do("1");

            var userModel = await _service.Get(1);

            return View(userModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
