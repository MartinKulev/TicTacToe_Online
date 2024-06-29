using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Multiplayer
{
	public class Service
	{
		public void Code()
		{			
			TTTContext context = new TTTContext();
			Console.ForegroundColor = ConsoleColor.White;
			int counter = 0;
            bool yourTurn;
			char symbol = ' ';
			bool first;
			bool clear = true;

		    Box box1 = new Box(1, ' ');
			Box box2 = new Box(2, ' ');
			Box box3 = new Box(3, ' ');
			Box box4 = new Box(4, ' ');
			Box box5 = new Box(5, ' ');
			Box box6 = new Box(6, ' ');
			Box box7 = new Box(7, ' ');
			Box box8 = new Box(8, ' ');
			Box box9 = new Box(9, ' ');
			context.Boxes.Update(box1);
			context.Boxes.Update(box2);
			context.Boxes.Update(box3);
			context.Boxes.Update(box4);
			context.Boxes.Update(box5);
			context.Boxes.Update(box6);
			context.Boxes.Update(box7);
			context.Boxes.Update(box8);
			context.Boxes.Update(box9);
            //context.Boxes.Add(box1);
            //context.Boxes.Add(box2);
            //context.Boxes.Add(box3);
            //context.Boxes.Add(box4);
            //context.Boxes.Add(box5);
            //context.Boxes.Add(box6);
            //context.Boxes.Add(box7);
            //context.Boxes.Add(box8);
            //context.Boxes.Add(box9);
            context.SaveChanges();

            Player player1 = new Player(1, true, false, false);
			Player player2 = new Player(2, false, false, false);
			if (context.Players.Contains(player1))
			{
				context.Players.Add(player2);
				context.SaveChanges();
				symbol = 'O';
				first = false;		
			}
			else
			{
				context.Players.Add(player1);
				context.SaveChanges();
				symbol = 'X';
				first = true;
			}
			if(!context.Players.Contains(player2))
			{
                Console.WriteLine("Waiting for player 2...");
            }
			while(!context.Players.Contains(player2)){}
			Console.Clear();
			List<char> firstRow = "│   │   │   │".ToList();
			List<char> secondRow = "│   │   │   │".ToList();
			List<char> thirdRow = "│   │   │   │".ToList();			
			while (true)
			{
				counter++;
				if (first)
				{
					if (counter % 2 == 1)
					{
						player1 = context.Players.First(p => p.ID == 1);
						player1.YourTurn = true;
						yourTurn = true;						
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player1 = context.Players.First(p => p.ID == 1);
						player1.YourTurn = false;
						yourTurn = false;						
						context.Players.Update(player1);
						context.SaveChanges();
					}
				}
				else
				{
					if (counter % 2 == 0)
					{
						player2 = context.Players.First(p => p.ID == 2);
						player2.YourTurn = true;
						yourTurn = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					else
					{
						player2 = context.Players.First(p => p.ID == 2);
						player2.YourTurn = false;
						yourTurn = false;
						context.Players.Update(player2);
						context.SaveChanges();
					}
				}

				box1 = context.Boxes.AsNoTracking().First(p => p.Field == 1);
				box2 = context.Boxes.AsNoTracking().First(p => p.Field == 2);
				box3 = context.Boxes.AsNoTracking().First(p => p.Field == 3);
				box4 = context.Boxes.AsNoTracking().First(p => p.Field == 4);
				box5 = context.Boxes.AsNoTracking().First(p => p.Field == 5);
				box6 = context.Boxes.AsNoTracking().First(p => p.Field == 6);
				box7 = context.Boxes.AsNoTracking().First(p => p.Field == 7);
				box8 = context.Boxes.AsNoTracking().First(p => p.Field == 8);
				box9 = context.Boxes.AsNoTracking().First(p => p.Field == 9);

                firstRow[2] = box1.Symbol;
				firstRow[6] = box2.Symbol;
				firstRow[10] = box3.Symbol;
				secondRow[2] = box4.Symbol;
				secondRow[6] = box5.Symbol;
				secondRow[10] = box6.Symbol;
				thirdRow[2] = box7.Symbol;
				thirdRow[6] = box8.Symbol;
				thirdRow[10] = box9.Symbol;

				if(clear)
				{
					Console.Clear();
					Console.WriteLine("Your symbol: " + symbol);
					foreach (char c in firstRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in secondRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in thirdRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
				}
				
				player1 = context.Players.AsNoTracking().First(p => p.ID == 1);//
				player2 = context.Players.AsNoTracking().First(p => p.ID == 2);//
				if (yourTurn == false && first)
				{				
					if (player2.YourTurn == true)
					{
						Console.WriteLine("Opponent's turn");
					}
					while (player2.YourTurn == true)
					{
						player2 = context.Players.AsNoTracking().First(p => p.ID == player2.ID);
					}
				}
				else if (yourTurn == false && first == false)
				{		
					if(player1.YourTurn == true)
					{
                        Console.WriteLine("Opponent's turn!");
                    }
					while (player1.YourTurn == true)
					{
						player1 = context.Players.AsNoTracking().First(p => p.ID == player1.ID);
					}
				}

				player1 = context.Players.AsNoTracking().First(p => p.ID == 1);//
				player2 = context.Players.AsNoTracking().First(p => p.ID == 2);//

				if (player1.Won == true || player2.Won == true)
				{
					box1 = context.Boxes.AsNoTracking().First(p => p.Field == 1);
					box2 = context.Boxes.AsNoTracking().First(p => p.Field == 2);
					box3 = context.Boxes.AsNoTracking().First(p => p.Field == 3);
					box4 = context.Boxes.AsNoTracking().First(p => p.Field == 4);
					box5 = context.Boxes.AsNoTracking().First(p => p.Field == 5);
					box6 = context.Boxes.AsNoTracking().First(p => p.Field == 6);
					box7 = context.Boxes.AsNoTracking().First(p => p.Field == 7);
					box8 = context.Boxes.AsNoTracking().First(p => p.Field == 8);
					box9 = context.Boxes.AsNoTracking().First(p => p.Field == 9);

					firstRow[2] = box1.Symbol;
					firstRow[6] = box2.Symbol;
					firstRow[10] = box3.Symbol;
					secondRow[2] = box4.Symbol;
					secondRow[6] = box5.Symbol;
					secondRow[10] = box6.Symbol;
					thirdRow[2] = box7.Symbol;
					thirdRow[6] = box8.Symbol;
					thirdRow[10] = box9.Symbol;

					Console.Clear();
					Console.WriteLine("Your symbol: " + symbol);
					foreach (char c in firstRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in secondRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in thirdRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("You Lose!");
                    break;
				}
				if (yourTurn)
				{					
					Console.Write("Your turn:");
					string n = Console.ReadLine();

					if (n == "1")
					{
						box1 = context.Boxes.AsNoTracking().First(p => p.Field == 1);
						if(box1.Symbol == 'X' || box1.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
                        }
						else
						{
							clear = true;
							box1 = context.Boxes.First(p => p.Field == 1);
							box1.Symbol = symbol;
							context.Boxes.Update(box1);
							context.SaveChanges();
						}							
					}
					else if (n == "2")
					{
						box2 = context.Boxes.AsNoTracking().First(p => p.Field == 2);
						if (box2.Symbol == 'X' || box2.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box2 = context.Boxes.First(p => p.Field == 2);
							box2.Symbol = symbol;
							context.Boxes.Update(box2);
							context.SaveChanges();
						}
					}
					else if (n == "3")
					{
						box3 = context.Boxes.AsNoTracking().First(p => p.Field == 3);
						if (box3.Symbol == 'X' || box3.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box3 = context.Boxes.First(p => p.Field == 3);
							box3.Symbol = symbol;
							context.Boxes.Update(box3);
							context.SaveChanges();
						}
					}
					else if (n == "4")
					{
						box4 = context.Boxes.AsNoTracking().First(p => p.Field == 4);
						if (box4.Symbol == 'X' || box4.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box4 = context.Boxes.First(p => p.Field == 4);
							box4.Symbol = symbol;
							context.Boxes.Update(box4);
							context.SaveChanges();
						}
					}
					else if (n == "5")
					{
						box5 = context.Boxes.AsNoTracking().First(p => p.Field == 5);
						if (box5.Symbol == 'X' || box5.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box5 = context.Boxes.First(p => p.Field == 5);
							box5.Symbol = symbol;
							context.Boxes.Update(box5);
							context.SaveChanges();
						}
					}
					else if (n == "6")
					{
						box6 = context.Boxes.AsNoTracking().First(p => p.Field == 6);
						if (box6.Symbol == 'X' || box6.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box6 = context.Boxes.First(p => p.Field == 6);
							box6.Symbol = symbol;
							context.Boxes.Update(box6);
							context.SaveChanges();
						}
					}
					else if (n == "7")
					{
						box7 = context.Boxes.AsNoTracking().First(p => p.Field == 7);
						if (box7.Symbol == 'X' || box7.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box7 = context.Boxes.First(p => p.Field == 7);
							box7.Symbol = symbol;
							context.Boxes.Update(box7);
							context.SaveChanges();
						}
					}
					else if (n == "8")
					{
						box8 = context.Boxes.AsNoTracking().First(p => p.Field == 8);
						if (box8.Symbol == 'X' || box8.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box8 = context.Boxes.First(p => p.Field == 8);
							box8.Symbol = symbol;
							context.Boxes.Update(box8);
							context.SaveChanges();
						}
					}
					else if (n == "9")
					{
						box9 = context.Boxes.AsNoTracking().First(p => p.Field == 9);
						if (box9.Symbol == 'X' || box9.Symbol == 'O')
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Box already occupied!");
							Console.ForegroundColor = ConsoleColor.White;
							counter--;
							clear = false;
						}
						else
						{
							clear = true;
							box9 = context.Boxes.First(p => p.Field == 9);
							box9.Symbol = symbol;
							context.Boxes.Update(box9);
							context.SaveChanges();
						}
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Not a valid box number!");
						Console.ForegroundColor = ConsoleColor.White;
						counter--;
						clear = false;
                    }
					if(clear)
					{
						Console.Clear();
						Console.WriteLine("Your symbol: " + symbol);
						foreach (char c in firstRow)
						{
							Console.Write(c);
						}
						Console.WriteLine();
						foreach (char c in secondRow)
						{
							Console.Write(c);
						}
						Console.WriteLine();
						foreach (char c in thirdRow)
						{
							Console.Write(c);
						}
						Console.WriteLine();
					}				
				}

				firstRow[2] = box1.Symbol;
				firstRow[6] = box2.Symbol;
				firstRow[10] = box3.Symbol;
				secondRow[2] = box4.Symbol;
				secondRow[6] = box5.Symbol;
				secondRow[10] = box6.Symbol;
				thirdRow[2] = box7.Symbol;
				thirdRow[6] = box8.Symbol;
				thirdRow[10] = box9.Symbol;

				if (firstRow[2] == symbol && firstRow[6] == symbol && firstRow[10] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine($"│ {symbol} │ {symbol} │ {symbol} │");
					Console.WriteLine("│   │   │   │");
					Console.WriteLine("│   │   │   │");
					break;
				}
				else if (secondRow[2] == symbol && secondRow[6] == symbol && secondRow[10] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine("│   │   │   │");
					Console.WriteLine($"│ {symbol} │ {symbol} │ {symbol} │");
					Console.WriteLine("│   │   │   │");
					break;
				}
				else if (thirdRow[2] == symbol && thirdRow[6] == symbol && thirdRow[10] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine("│   │   │   │");
					Console.WriteLine("│   │   │   │");
					Console.WriteLine($"│ {symbol} │ {symbol} │ {symbol} │");
					break;
				}
				else if (firstRow[2] == symbol && secondRow[2] == symbol && thirdRow[2] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine($"│ {symbol} │   │   │");
					Console.WriteLine($"│ {symbol} │   │   │");
					Console.WriteLine($"│ {symbol} │   │   │");
					break;
				}
				else if (firstRow[6] == symbol && secondRow[6] == symbol && thirdRow[6] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine($"│   │ {symbol} │   │");
					Console.WriteLine($"│   │ {symbol} │   │");
					Console.WriteLine($"│   │ {symbol} │   │");
					break;
				}
				else if (firstRow[10] == symbol && secondRow[10] == symbol && thirdRow[10] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine($"│   │   │ {symbol} │");
					Console.WriteLine($"│   │   │ {symbol} │");
					Console.WriteLine($"│   │   │ {symbol} │");
					break;
				}
				else if (firstRow[2] == symbol && secondRow[6] == symbol && thirdRow[10] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine($"│ {symbol} │   │   │");
					Console.WriteLine($"│   │ {symbol} │   │");
					Console.WriteLine($"│   │   │ {symbol} │");
					break;
				}
				else if (firstRow[10] == symbol && secondRow[6] == symbol && thirdRow[2] == symbol)
				{
					player1 = context.Players.First(p => p.ID == 1);
					player2 = context.Players.First(p => p.ID == 2);
					if (first)
					{
						player1.YourTurn = false;
						player1.Won = true;
						context.Players.Update(player1);
						context.SaveChanges();
					}
					else
					{
						player2.YourTurn = false;
						player2.Won = true;
						context.Players.Update(player2);
						context.SaveChanges();
					}
					Console.WriteLine();
					Console.WriteLine("You Win!");
					Console.WriteLine("-------------");
					Console.WriteLine($"│   │   │ {symbol} │");
					Console.WriteLine($"│   │ {symbol} │   │");
					Console.WriteLine($"│ {symbol} │   │   │");					
					break;
				}	
				else if(counter == 9)
				{
					Console.Clear();
					foreach (char c in firstRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in secondRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in thirdRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
				
					if (first)
					{
						player1 = context.Players.First(p => p.ID == 1);						
						player1.YourTurn = false;
						context.Players.Update(player1);
						context.SaveChanges();
					}

					Console.WriteLine();
					Console.WriteLine("Draw!");
					Console.WriteLine("-------------");
					foreach (char c in firstRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in secondRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					foreach (char c in thirdRow)
					{
						Console.Write(c);
					}
					Console.WriteLine();
					break;
				}
			}

			if (context.Players.Contains(player1))
			{
				player1 = context.Players.First(p => p.ID == 1);
				context.Players.Remove(player1);
				context.Players.Remove(player2);
				context.SaveChanges();
			}			
		}
	}
}
