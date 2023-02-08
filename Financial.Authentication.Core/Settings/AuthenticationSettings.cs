namespace Infra.Settings
{
    public class AuthenticationSettings
    {
        public static string Key = "JwtAuthentication";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTime { get; set; }
    }
}
