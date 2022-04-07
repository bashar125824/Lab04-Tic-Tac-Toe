using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
	public class Game
	{
		/// <summary>
		/// Set player one, player two, winner and the Game Board.
		/// </summary>
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
		/// Activates the Play of the game and displays the game board each time 
		/// a player chooses, then keep switching until the board is full or if a 
		/// winning board is found. If yes, print a congratulations message with the 
		/// winner's name and end the game by returning a winner, otherwise return null 
		/// so it's a tie/draw(will be checked at StartGame method).
		/// </summary>
		/// <returns> Winner or null if there is no winner(tie/draw)</returns>
		public Player Play()
		{
			int counter = 1;
			Board.DisplayBoard();
			while (counter < 10)
			{
				SwitchPlayer();
				Player currentPlayer = NextPlayer();
				currentPlayer.TakeTurn(Board);
				if (CheckForWinner(Board) == true)
				{
					Board.DisplayBoard();
					Console.WriteLine($"Player {currentPlayer.Name} has won!");
					return currentPlayer;
				}
				Board.DisplayBoard();
				counter++;
			}
			return null;

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

				// If we have three positions with the same Marker, 
				//depending on the winning conditions above
				// true is returned so we have a winner board.
				if (a == b && a == c)
				{
					return true;
				}
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