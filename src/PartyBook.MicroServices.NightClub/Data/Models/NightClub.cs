﻿namespace PartyBook.MicroServices.NightClub.Data.Models
{
    using PartyBook.Data.Common.Models;
    using PartyBook.Services.Mapping;
    using PartyBook.ViewModels.Gateway;
    using PartyBook.ViewModels.NightClub;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NightClub : BaseModel<string>, IMapTo<NightClubCreateViewModel>, IMapFrom<NightClubCreateViewModel>, IMapTo<NightClubGetAllViewModel>, IMapTo<NightClubGatewayViewModel>
    {
        private const int MinLength = 3;
        private const int MaxLength = 30;

        public NightClub()
        {
            this.Reviewes = new HashSet<string>();
            this.Events = new HashSet<Event>();
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

        [NotMapped]
        public ICollection<string> Reviewes { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
