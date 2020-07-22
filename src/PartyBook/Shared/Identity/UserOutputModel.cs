namespace PartyBook.ViewModels.Identity
{
    public class UserOutputModel
    {
        public UserOutputModel()
        {

        }

        public UserOutputModel(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
