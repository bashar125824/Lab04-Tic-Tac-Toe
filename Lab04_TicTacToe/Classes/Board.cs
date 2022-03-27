using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    class Board
    {
		/// <summary>
		/// Tic Tac Toe Gameboard states
		/// </summary>
		public string[,] GameBoard = new string[,]
		{
			{"1", "2", "3"},
			{"4", "5", "6"},
			{"7", "8", "9"},
		};


		public void DisplayBoard()
		{

			//TODO: Output the board to the console

			// Convert GameBoard array to integer array

			int[,] intGameboard = new int[GameBoard.GetLength(0), GameBoard.GetLength(1)];

			for (int j = 0; j < GameBoard.GetLength(0); j++)
			{
				for (int i = 0; i < GameBoard.GetLength(1); i++)
				{
					int number;
					bool ok = int.TryParse(GameBoard[j, i], out number);
					if (ok)
					{
						intGameboard[j, i] = number;
					}
					else
					{
						intGameboard[j, i] = 0;
					}
				}
			}

			// Consoling the converted array (intGameboard)

			for (int i = 0; i < intGameboard.GetLength(0); i++)
			{
				for (int j = 0; j < intGameboard.GetLength(1); j++)
				{
					Console.Write("{0} ", intGameboard[i, j]);
				}
				Console.WriteLine();
			}

		}
	}
}
