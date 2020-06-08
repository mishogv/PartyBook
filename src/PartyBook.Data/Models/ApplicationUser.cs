namespace PartyBook.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        private const int MinLength = 3;
        private const int MaxLength = 30;

        public ApplicationUser()
        {
            Reviews = new HashSet<Review>();
            Requests = new HashSet<BookRequest>();
            NightClubs = new HashSet<NightClub>();
        }

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string LastName { get; set; }

        public virtual ICollection<NightClub> NightClubs { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<BookRequest> Requests { get; set; }
    }
}
