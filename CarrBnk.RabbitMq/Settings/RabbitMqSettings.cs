namespace CarrBnk.RabbitMq.Settings
{
    public class RabbitMqSettings 
    {
        public static readonly string Key = "RabbitMq";
        public string ConnectionString { get; set; } = string.Empty;
    }
}
