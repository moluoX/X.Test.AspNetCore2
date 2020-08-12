using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Test.AspNetCore2.Service.Base;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Injector
{
    public class ConnectionStringBuilder
    {
        protected IConfiguration _configuration;
        public ConnectionStringBuilder(IConfiguration configuration) => _configuration = configuration;

        public string Get<T>(DbContextReadOrWrite readOrWrite)
        {
            string connectionName;
            if (typeof(T) == typeof(SampleContext))
            {
                connectionName = "SampleConnection";
            }
            else if (typeof(T) == typeof(SampleContext))
            {
                connectionName = "SchoolConnection";
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(T));
            }

            string connectionString;
            switch (readOrWrite)
            {
                case DbContextReadOrWrite.Read:
                    var connectionStrings = _configuration.GetSection($"ConnectionStrings:{connectionName}Read").Get<string[]>();
                    return Choose(connectionStrings);
                case DbContextReadOrWrite.Write:
                    connectionString = _configuration.GetConnectionString(connectionName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(readOrWrite));
            }
            return connectionString;
        }

        protected string Choose(string[] connectionStrings)
        {
            if (!connectionStrings.Any())
                throw new ArgumentOutOfRangeException(nameof(connectionStrings));
            return connectionStrings[new Random().Next(connectionStrings.Length)];
        }
    }
}
