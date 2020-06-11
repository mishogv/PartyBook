﻿namespace PartyBook.Data.Models
{
    using PartyBook.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class Review : BaseModel<int>
    {
        [Range(1, 10)]
        public int Raiting { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string NightClubId { get; set; }
        public virtual NightClub NightClub { get; set; }
    }
}
