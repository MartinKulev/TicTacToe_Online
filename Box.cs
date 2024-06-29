using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Multiplayer
{
	public class Box
	{
		public Box()
		{

		}
		public Box(int field, char symbol)
		{
			Field = field;
			Symbol = symbol;

		}
		[Key]
		public int Field { get; set; }

		public char Symbol { get; set; }
	}
}
