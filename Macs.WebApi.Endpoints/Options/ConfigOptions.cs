namespace Macs.WebApi.Endpoints.Options
{
    public class ConfigOptions : IConfigOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string MacsConnectionString { get; set; }
    }
}
