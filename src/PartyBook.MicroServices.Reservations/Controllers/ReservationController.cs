namespace PartyBook.MicroServices.Reservations.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using PartyBook.Common.Controllers;

    [Authorize]
    public class ReservationController : ApiController
    {
    }
}
