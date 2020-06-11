namespace PartyBook.ViewModels.NightClub
{
    using System.ComponentModel.DataAnnotations;

    public class NightClubDeleteInputModel
    {
        [Required]
        public string Id { get; set; }
    }
}
