namespace PartyBook.MicroServices.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Infrastructure;
    using PartyBook.ViewModels.Identity;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using static PartyBook.Common.GlobalConstants.Infrastructure;
    using Microsoft.AspNetCore.Http;
    using System;

    public class IdentityController : Controller
    {
        private readonly HttpClient httpClient;

        public IdentityController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var response = await this.httpClient.PostJsonAsync<UserOutputModel>("Identity/Login", model);

            this.Response.Cookies.Append(
                AuthenticationCookieName,
                response.Token,
                new CookieOptions
                {
                    HttpOnly = true,
                    MaxAge = TimeSpan.FromDays(1)
                });

            return this.RedirectToAction("Privacy", "Home");
        }

        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete("Authentication");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
