namespace PartyBook.MicroServices.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Administration.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //TODO : FIX
            if (this.User.IsAdministrator())
            {
                return this.RedirectToAction("Privacy", "Home");
            }

            return this.View();
        }

        [AuthorizeAdministrator]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
            });
    }
}
