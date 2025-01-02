using App.Domain.AppServices.TransactionAggrigate;
using Microsoft.AspNetCore.Mvc;
using MVCApp.EndPoint.Models;
using System.Diagnostics;

namespace MVCApp.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        TransactionAppService transactionAppService = new TransactionAppService();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            transactionAppService.PassCreate();

            if (OnlineCrad.card == null)
            {
               return RedirectToAction("LogIn", "User");
            }

            if (OnlineCrad.card != null)
            {
                ViewBag.Card = OnlineCrad.card;
            }
            
            return View();
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
