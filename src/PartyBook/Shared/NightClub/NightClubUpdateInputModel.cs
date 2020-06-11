namespace PartyBook.ViewModels.NightClub
{
    using System.ComponentModel.DataAnnotations;

    public class NightClubUpdateInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string CoverUrl { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string BusinessHours { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Location { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string TelephoneForReservations { get; set; }
    }
}
