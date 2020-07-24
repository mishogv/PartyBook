namespace PartyBook.Common
{
    public static class GlobalConstants
    {
        public static class Administration    
        {
            public const string AdministrationRoleName = "Administration";
        }

        public static class Infrastructure
        {
            public const string AuthenticationCookieName = "Authentication";
            public const string AuthorizationHeaderName = "authorization";
            public const string AuthorizationHeaderValuePrefix = "Bearer";
        }
    }
}
