using System.ComponentModel.DataAnnotations;

namespace PartyBook.ViewModels.Review
{
    public class ReviewCreateInputModel
    {
        [Range(1, 10)]
        public int Raiting { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string NightClubId { get; set; }
    }
}
