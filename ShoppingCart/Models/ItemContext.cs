using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        //private string connectionString /*= "Server=(localdb)\\mssqllocaldb;Database=items.mdb;Trusted_Connection=False;"*/;
    /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        */
        public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
        {
        }
    
/*
        public ItemContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureConnection");
            
            
            
            //connectionString = configuration.GetConnectionString("LocalDBConnection");

            var builder = new SqlConnectionStringBuilder(connectionString);

            string KEYVAULT_BASE_URI = "https://eadvault.vault.azure.net/";

            try
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                var secret = keyVaultClient.GetSecretAsync(KEYVAULT_BASE_URI + "secrets/ShoppingPWD");
                builder.Password = secret.Result.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //builder.Password = "Dundalk!";
            connectionString = builder.ToString();

        }*/
    }
}
