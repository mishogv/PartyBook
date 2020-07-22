using System.ComponentModel.DataAnnotations;

namespace PartyBook.ViewModels.Identity
{
    public class LoginInputModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
