namespace PartyBook.MicroServices.Statistics.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Controllers;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Statistics.Services;
    using PartyBook.ViewModels.Statistics;
    using System.Threading.Tasks;

    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [AuthorizeAdministrator]
        [HttpGet]
        public async Task<ActionResult<StatisticsGetAllViewModel>> GetAll()
        {
            return await this.statisticsService.GetAllAsync();
        }
    }
}
