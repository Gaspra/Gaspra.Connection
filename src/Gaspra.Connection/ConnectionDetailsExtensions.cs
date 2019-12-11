using Microsoft.Extensions.Configuration;
using Gaspra.Signing.Interfaces;

namespace Gaspra.Connection
{
    public static class ConnectionDetailsExtensions
    {
        public static ConnectionDetails FromEncryptedConfiguration(
            IConfigurationSection ConnectionDetailSection,
            SigningService signingService)
        {
            return new ConnectionDetails(
                    signingService.Decrypt(ConnectionDetailSection[nameof(ConnectionDetails.DataSource)]),
                    signingService.Decrypt(ConnectionDetailSection[nameof(ConnectionDetails.InitialCatalogue)]),
                    signingService.Decrypt(ConnectionDetailSection[nameof(ConnectionDetails.UserId)]),
                    signingService.Decrypt(ConnectionDetailSection[nameof(ConnectionDetails.Password)])
                );
        }

        public static string ToEncryptedJson(
            ConnectionDetails connectionDetails,
            SigningService signingService)
        {
            return $@"""ConnectionDetails"": {{
                ""DataSource"": ""{signingService.Encrypt(connectionDetails.DataSource)}""
                ""InitialCatalogue"": ""{signingService.Encrypt(connectionDetails.InitialCatalogue)}""
                ""UserId"": ""{signingService.Encrypt(connectionDetails.UserId)}""
                ""Password"": ""{signingService.Encrypt(connectionDetails.Password)}""
            }}";
        }

        public static ConnectionDetails FromConfiguration(
            IConfigurationSection ConnectionDetailSection)
        {
            return new ConnectionDetails(
                    ConnectionDetailSection[nameof(ConnectionDetails.DataSource)],
                    ConnectionDetailSection[nameof(ConnectionDetails.InitialCatalogue)],
                    ConnectionDetailSection[nameof(ConnectionDetails.UserId)],
                    ConnectionDetailSection[nameof(ConnectionDetails.Password)]
                );
        }

        public static string ToConnectionString(this ConnectionDetails connectionDetails)
        {
            return $"Data Source={connectionDetails.DataSource};Initial Catalog={connectionDetails.InitialCatalogue};Persist Security Info=True;User ID={connectionDetails.UserId};Password={connectionDetails.Password};";
        }
    }
}
