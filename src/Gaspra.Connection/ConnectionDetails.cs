using Microsoft.Extensions.Configuration;
using Gaspra.Signing.Interfaces;
using System;

namespace DataAccess
{
    public class ConnectionDetails
    {
        public string DataSource { get; }
        public string InitialCatalogue { get; set;  }
        public string UserId { get; }
        public string Password { get; set;  }

        public ConnectionDetails(
            string dataSource,
            string intialCatalogue,
            string userId,
            string password)
        {
            DataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            InitialCatalogue = intialCatalogue ?? throw new ArgumentNullException(nameof(intialCatalogue));
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public static ConnectionDetails FromConfiguration(
            IConfigurationSection ConnectionDetailSection,
            SigningService signingService)
        {
            return new ConnectionDetails(
                    signingService.Decrypt(ConnectionDetailSection[nameof(DataSource)]),
                    signingService.Decrypt(ConnectionDetailSection[nameof(InitialCatalogue)]),
                    signingService.Decrypt(ConnectionDetailSection[nameof(UserId)]),
                    signingService.Decrypt(ConnectionDetailSection[nameof(Password)])
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

        public override string ToString()
        {
            return $"Data Source={DataSource};Initial Catalog={InitialCatalogue};Persist Security Info=True;User ID={UserId};Password={Password};";
        }
    }
}
