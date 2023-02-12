namespace CarrBnk.Financial.Infra.Settings
{
    public record MongoSettings
    {
        public static readonly string Key = "FinancialDatabase";
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string FinancialPostingsCollectionName { get; set; } = null!;
    }
}
