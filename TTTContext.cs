using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Multiplayer
{
	public class TTTContext: DbContext
	{
		public DbSet<Box> Boxes { get; set; }

		public DbSet<Player> Players { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.UseMySQL("Server=mysql-210770ab-techstore.b.aivencloud.com;Database=ttt;Uid=avnadmin;Pwd=AVNS_ECNjUML_9rCSuGwr_PA;Port=15039"); //Exposed for testing purposes
			base.OnConfiguring(optionsBuilder);
		}
	}
}
