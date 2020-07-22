namespace PartyBook.ViewModels.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterInputModel
    {
        private const int MinLength = 3;
        private const int MaxLength = 30;

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
