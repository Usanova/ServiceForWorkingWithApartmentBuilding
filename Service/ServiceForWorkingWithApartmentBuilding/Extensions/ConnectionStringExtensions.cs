namespace ServiceForWorkingWithApartmentBuilding.Extensions
{
    internal static class ConnectionStringExtensions
    {
        public static string AppendApplicationName(string connectionString, string suffix = null)
        {
            var builder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);
            if (string.IsNullOrEmpty(builder.ApplicationName))
            {
                var @namespace = typeof(ConnectionStringExtensions).Namespace;
                builder.ApplicationName = @namespace.Remove(@namespace.LastIndexOf('.')) + (suffix != null ? "-" + suffix : string.Empty);
            }

            return builder.ConnectionString;
        }
    }
}
