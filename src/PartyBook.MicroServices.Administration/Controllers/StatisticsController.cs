namespace PartyBook.MicroServices.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class StatisticsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            return this.View();
        }
    }
}
