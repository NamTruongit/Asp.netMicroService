using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.GRPC.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating postgresql database.");
                    using var connection = new NpgsqlConnection
                        (configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();
                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };
                    command.CommandText = "Drop table if exists Coupon";
                    command.ExecuteNonQuery();

                    command.CommandText = @"Create table Coupon(
                                            Id SERIAL PRIMARY KEY,
                                            ProductName VARCHAR(24)NOT NULL,
                                            Decription TEXT,
                                            Amount INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Coupon(ProductName,Decription,Amount) VALUES('IPHONE XR','IPHONE DISCOUNT',150);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Coupon(ProductName,Decription,Amount) VALUES('IPHONE XS MAX','IPHONE DISCOUNT',120);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Coupon(ProductName,Decription,Amount) VALUES('IPHONE 11 PRO MAX','IPHONE DISCOUNT',10);";
                    command.ExecuteNonQuery();
                    logger.LogInformation("Migrating postgresql database.");
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error  occured while migrating the postgressql database");

                    if (retryForAvailability < 5)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        host.MigrateDatabase<TContext>(retryForAvailability);
                    }

                }

            }

            return host;
        }
    }
}
