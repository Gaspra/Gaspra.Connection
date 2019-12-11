using System;

namespace Gaspra.Connection
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
    }
}
