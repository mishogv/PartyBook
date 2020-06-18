namespace PartyBook.ViewModels.Reservation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReservationtCreateInputModel
    {
        [Required]
        public DateTime When { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string TelephoneNumber { get; set; }

        public string Message { get; set; }

        [Range(1, int.MaxValue)]
        public int NumberOfPeople { get; set; }

        public bool IsApproved { get; set; } = false;

        public bool IsRejected { get; set; } = false;

        public string NightClubId { get; set; }
    }
}
