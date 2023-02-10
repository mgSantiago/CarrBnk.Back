namespace CarrBnk.Financial.Settings
{
    public class AuthenticationSettings
    {
        public static readonly string Key = "JwtAuthentication";
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpirationTime { get; set; }
    }
}
