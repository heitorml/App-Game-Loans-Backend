using Microsoft.Extensions.Configuration;
using System;


namespace AppGameLoans.Utilities.Util
{
    public static class UtilConfiguration
    {
        public static string GetKey(this IConfiguration configuration, string key)
        {
            var chave = configuration.GetSection(key)?.Value ?? configuration.GetSection(key.Replace(":", "__"))?.Value;

            if (string.IsNullOrEmpty(chave))
                throw new Exception($"Não foi possível encontrar a chave {key}");

            return chave;
        }

        public static string GetConnectionStringKey(this IConfiguration configuration, string key)
        {
            var chave = configuration.GetConnectionString(key) ?? configuration.GetConnectionString(key.Replace(":", "__"));

            if (string.IsNullOrEmpty(chave))
                throw new Exception($"Não foi possível encontrar a connection string {key}");

            return chave;
        }
    }
}
