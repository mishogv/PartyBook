﻿namespace PartyBook.ViewModels.Event
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventCreateInputModel
    {
        public DateTime When { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public string NightClubId { get; set; }
    }
}
