using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        /// <summary>
        /// Creates two players, prompts them to choose their names and creates the game.
        /// If there is no winner, null will be returned in Play method so we can decide that 
        /// is it a tie/draw, otherwise the method will return a winner's name with a congratulations message.
        /// </summary>
        static void StartGame()
        {
            Player player1 = new Player();
            Console.Write("Please enter a name for player one: ");
            player1.Name = Console.ReadLine();
            player1.Marker = "X";

            Player player2 = new Player();
            Console.Write("Please enter a name for player two: ");
            player2.Name = Console.ReadLine();
            player2.Marker = "O";

            Game game = new Game(player1, player2);
            Player winner = game.Play();
            // Winner will be null only if no winner is returned in the play method.
            if (winner == null)
            {
                Console.WriteLine("There is no winner(tie/draw).");
            }

            // TODO: Setup your game. Create a new method that creates your players and instantiates the game class. Call that method in your Main method.
            // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner. 
        }


    }
}