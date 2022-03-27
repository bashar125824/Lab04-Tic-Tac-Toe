using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab04_TicTacToe.Classes
{
	class Game
	{
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }
		public Player Winner { get; set; }
		public Board Board { get; set; }


		/// <summary>
		/// Require 2 players and a board to start a game. 
		/// </summary>
		/// <param name="p1">Player 1</param>
		/// <param name="p2">Player 2</param>
		public Game(Player p1, Player p2)
		{
			PlayerOne = p1;
			PlayerTwo = p2;
			Board = new Board();
		}

		/// <summary>
		/// Activate the Play of the game
		/// </summary>
		/// <returns>Winner</returns>
		public Player Play()
		{

			//TODO: Complete this method and utilize the rest of the class structure to play the game.

			/*
             * Complete this method by constructing the logic for the actual playing of Tic Tac Toe. 
             * 
             * A few things to get you started:
            1. A turn consists of a player picking a position on the board with their designated marker. 
            2. Display the board after every turn to show the most up to date state of the game
            3. Once a Winner is determined, display the board one final time and return a winner

            Few additional hints:
                Be sure to keep track of the number of turns that have been taken to determine if a draw is required
                and make sure that the game continues while there are unmarked spots on the board. 

            Use any and all pre-existing methods in this program to help construct the method logic. 
             */
			int player = 1; //By default player 1 is set
			int choice; //This holds the choice at which position user want to mark
						// The flag variable checks who has won if it's value is 1 then someone has won the match
						//if -1 then Match has Draw if 0 then match is still running
			bool flag = false;
			char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

			do
			{
				Console.Clear();// whenever loop will be again start then screen will be clear
				Console.WriteLine("Player1:X and Player2:O");
				Console.WriteLine("\n");
				if (player % 2 == 0)//checking the chance of the player
				{
					Console.WriteLine("Player 2 Chance");
				}
				else
				{
					Console.WriteLine("Player 1 Chance");
				}
				Console.WriteLine("\n");
				Board.DisplayBoard();// calling the board Function
				choice = int.Parse(Console.ReadLine());//Taking users choice
													   // checking that position where user want to run is marked (with X or O) or not
				if (arr[choice] != 'X' && arr[choice] != 'O')
				{
					if (player % 2 == 0) //if chance is of player 2 then mark O else mark X
					{
						arr[choice] = 'O';
						player++;
					}
					else
					{
						arr[choice] = 'X';
						player++;
					}
				}
				else
				//If there is any possition where user want to run
				//and that is already marked then show message and load board again
				{
					Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
					Console.WriteLine("\n");
					Console.WriteLine("Please wait 2 second board is loading again.....");
					Thread.Sleep(2000);
				}
				flag = CheckForWinner(Board);// calling of check win
			}
			while (flag != true && flag != false);
			// This loop will be run until all cell of the grid is not marked
			//with X and O or some player is not win
			Console.Clear();// clearing the console
			Board.DisplayBoard();// getting filled board again
			if (flag == true)
			// if flag value is 1 then someone has win or
			//means who played marked last time which has win
			{
				Console.WriteLine("Player {0} has won", (player % 2) + 1);
			}
			else// if flag value is -1 the match will be draw and no one is winner
			{
				Console.WriteLine("Draw");
			}
			Console.ReadLine();

			return Winner;
		}
	
		 



/// <summary>
/// Check if winner exists
/// </summary>
/// <param name="board">current state of the board</param>
/// <returns>if winner exists</returns>
public bool CheckForWinner(Board board)
		{
			int[][] winners = new int[][]
			{
				new[] {1,2,3},
				new[] {4,5,6},
				new[] {7,8,9},

				new[] {1,4,7},
				new[] {2,5,8},
				new[] {3,6,9},

				new[] {1,5,9},
				new[] {3,5,7}
			};

			// Given all the winning conditions, Determine the winning logic. 
			for (int i = 0; i < winners.Length; i++)
			{
				Position p1 = Player.PositionForNumber(winners[i][0]);
				Position p2 = Player.PositionForNumber(winners[i][1]);
				Position p3 = Player.PositionForNumber(winners[i][2]);

				string a = Board.GameBoard[p1.Row, p1.Column];
				string b = Board.GameBoard[p2.Row, p2.Column];
				string c = Board.GameBoard[p3.Row, p3.Column];

				// TODO:  Determine a winner has been reached. 
				// return true if a winner has been reached. 

				if (winners[1] == winners[2] && winners[2] == winners[3])
				{
					return true;
				}
				//Winning Condition For Second Row
				else if (winners[4] == winners[5] && winners[5] == winners[6])
				{
					return true;
				}
				//Winning Condition For Third Row
				else if (winners[6] == winners[7] && winners[7] == winners[8])
				{
					return true;
				}

                // endregion


				// region vertical Winning Condtion


				//Winning Condition For First Column
				else if (winners[1] == winners[4] && winners[4] == winners[7])
				{
					return true;
				}
				//Winning Condition For Second Column
				else if (winners[2] == winners[5] && winners[5] == winners[8])
				{
					return true;
				}
				//Winning Condition For Third Column
				else if (winners[3] == winners[6] && winners[6] == winners[9])
				{
					return true;
				}


				//endregion


				//region Diagonal Winning Condition


				else if (winners[1] == winners[5] && winners[5] == winners[9])
				{
					return true;
				}
				else if (winners[3] == winners[5] && winners[5] == winners[7])
				{
					return true;
				}

				//endregion


				// region Checking For Draw


				// If all the cells or values filled with X or O then any player has won the match
				

			}

			return false;


		}

			/// <summary>
			/// Determine next player
			/// </summary>
			/// <returns>next player</returns>
			public Player NextPlayer()
			{
				return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
			}

			/// <summary>
			/// End one players turn and activate the other
			/// </summary>
			public void SwitchPlayer()
			{
				if (PlayerOne.IsTurn)
				{

					PlayerOne.IsTurn = false;


					PlayerTwo.IsTurn = true;
				}
				else
				{
					PlayerOne.IsTurn = true;
					PlayerTwo.IsTurn = false;
				}
			}


		}
	}


