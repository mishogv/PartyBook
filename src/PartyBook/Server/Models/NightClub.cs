﻿namespace PartyBook.Server.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NightClub : BaseModel<string>
    {
        private const int MinLength = 3;
        private const int MaxLength = 30;

        public NightClub()
        {
            this.Reviewes = new HashSet<Review>();
            this.Events = new HashSet<Event>();
            this.Requests = new HashSet<BookRequest>();
        }

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
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

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<Review> Reviewes { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<BookRequest> Requests { get; set; }
    }
}
