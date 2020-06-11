namespace PartyBook.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewUpdateInputModel
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Raiting { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string NightClubId { get; set; }
    }
}
