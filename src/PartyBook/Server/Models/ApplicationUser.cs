﻿namespace PartyBook.Server.Models
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
            this.Reviews = new HashSet<Review>();
            this.Requests = new HashSet<BookRequest>();
            this.NightClubs = new HashSet<NightClub>();
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
