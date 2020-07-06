namespace PartyBook.MicroServices.Reservations.Data.Models
{
    using PartyBook.Data.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reservation : BaseModel<int>
    {
        [Required]
        public DateTime When { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string TelephoneNumber { get; set; }

        public string Message { get; set; }

        [Range(1, double.MaxValue)]
        public int NumberOfPeople { get; set; }

        public bool IsApproved { get; set; } = false;

        public bool IsRejected { get; set; } = false;

        public string NightClubId { get; set; }

        public string NightClubOwnerId { get; set; }

        public string UserId { get; set; }
    }
}
