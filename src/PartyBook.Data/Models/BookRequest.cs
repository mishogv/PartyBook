namespace PartyBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookRequest : BaseModel<int>
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
        public virtual NightClub NightClub { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
