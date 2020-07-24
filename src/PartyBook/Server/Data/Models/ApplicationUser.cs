namespace PartyBook.Data.Identity.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        private const int MinLength = 3;
        private const int MaxLength = 30;

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string LastName { get; set; }
    }
}
