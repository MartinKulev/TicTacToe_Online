using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicTacToe.Multiplayer
{
    public class TTTContext : DbContext
    {
        public DbSet<Box> Boxes { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            string jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GitSecrets.json");
            string json = File.ReadAllText(jsonFilePath);
            JsonElement root = JsonDocument.Parse(json).RootElement;

            string? connectionString = root.GetProperty("ConnectionStrings").GetProperty("TicTacToe_Online").GetString();
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

