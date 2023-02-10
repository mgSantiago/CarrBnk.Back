namespace CarrBnk.BaseConfiguration.Settings
{
    public struct AuthenticationSettings
    {
        public const string Key = "JwtAuthentication";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTime { get; set; }
    }
}
