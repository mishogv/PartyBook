namespace PartyBook.MicroServices.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Infrastructure;

    public class IdentityController : Controller
    {
        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete("Authentication");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
