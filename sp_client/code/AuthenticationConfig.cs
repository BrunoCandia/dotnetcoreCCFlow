using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.IO;

namespace client
{
    public class AuthenticationConfig
    {
        public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";
        public string Tenant { get; set; }
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string Authority
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture, Instance, Tenant);
            }
        }

        public string AppID { get; set; }
        public string SPPassword { get; set; }
        public static AuthenticationConfig ReadFromJsonFile(string path)
        {
            IConfigurationRoot Configuration;

            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path);

            Configuration = builder.Build();
            return Configuration.Get<AuthenticationConfig>();
        }
    }
}
