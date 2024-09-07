namespace Blog
{
    public static class Configuration
    {
        //Token - JWT - Json Web Token
        public static string JwtKey = "057c28db-23c2-49b7-b026-283b0eee5abb";

        public static string ApiKeyName = "api_key";

        public static string ApiKey = "gabriel_dev_dotnet6";

        public static SmtpConfiguration Smtp = new();


        public class SmtpConfiguration 
        {
            public string host {  get; set; }
            public int port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}