using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Multiplayer
{
	public class Player
	{
		public Player()
		{

		}
		public Player(int id, bool firstOrder, bool yourTurn, bool won)
		{
			ID = id;
			FirstOrder = firstOrder;
			YourTurn = firstOrder;
			Won = won;
		}
		[Key]
		public int ID { get; set; }


		public bool FirstOrder { get; set; }

		public bool YourTurn { get; set; }

		public bool Won { get; set; }

	}
}
