using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ContaBancaria.API.Data;
using System.Collections.Generic;
using ContaBancaria.API.Domain.Models;
using Microsoft.Data.Sqlite;

namespace ContaBancaria.API.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
        private readonly SqliteConnection _connection;

        public CustomWebApplicationFactory()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
 
            _connection = new SqliteConnection(connectionString);
 
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkSqlite()
                    .BuildServiceProvider();

                services.AddDbContext<DataContext>(options => 
                {
                    options.UseSqlite(_connection);
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DataContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            $"database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }

        private void InitializeDbForTests(DataContext db)
        {
            db.Contas.AddRange(new List<ContaCorrente> {
                new ContaCorrente(1, 1),
                new ContaCorrente(2, 100),
                new ContaCorrente(3, 100)
            });
            db.Transacoes.AddRange(new List<Transacao> {
                new Transacao(new ContaCorrente(1, 1), TipoTransacao.Credito, DateTime.Now, 0, 0, 0, "Crédito")
            }); 
            db.SaveChanges();
        }
    }
}