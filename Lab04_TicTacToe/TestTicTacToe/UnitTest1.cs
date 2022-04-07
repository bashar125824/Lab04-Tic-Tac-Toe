using System;
using Xunit;
using Lab04_TicTacToe.Classes;

namespace TestGame
{
    public class TestMethods
    {
        [Fact]
        public void TestWinnerBoard()
        {
            Game testGame = new Game(new Player(), new Player());
            for (int i = 0; i < 3; i++)
                testGame.Board.GameBoard[0, i] = "X";
            Assert.True(testGame.CheckForWinner(testGame.Board));

            for (int i = 0; i < 3; i++)
                testGame.Board.GameBoard[i, i] = "O";
            Assert.True(testGame.CheckForWinner(testGame.Board));
        }

        [Fact]
        public void TestSwitch()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Game testGame = new Game(player1, player2);
            // By default, it sets the turn for playerOne when called.
            testGame.SwitchPlayer();
            Assert.Equal(player1, testGame.NextPlayer());

            // After first call, it will switch the turns since it was playerOne's turn.
            testGame.SwitchPlayer();
            Assert.Equal(player2, testGame.NextPlayer());
        }


        [Fact]
        public void TestPosition()
        {
            Position middleMiddle = new Position(1, 1);
            Assert.Equal(middleMiddle.Row, Player.PositionForNumber(5).Row);
            Assert.Equal(middleMiddle.Column, Player.PositionForNumber(5).Column);

            Position bottomRight = new Position(2, 2);
            Assert.Equal(bottomRight.Row, Player.PositionForNumber(9).Row);
            Assert.Equal(bottomRight.Column, Player.PositionForNumber(9).Column);

            Position topLeft = new Position(0, 0);
            Assert.Equal(topLeft.Row, Player.PositionForNumber(1).Row);
            Assert.Equal(topLeft.Column, Player.PositionForNumber(1).Column);
        }

        [Fact]
        public void TestNotWinnerBoard()
        {
            Game testGame = new Game(new Player(), new Player());
            testGame.Board.GameBoard = new string[,]
            {
                {"X", "O", "X"},
                {"O", "O", "X"},
                {"X", "X", "O"},
            };
            Assert.False(testGame.CheckForWinner(testGame.Board));

            testGame.Board.GameBoard = new string[,]
            {
                {"1", "2", "X"},
                {"O", "5", "6"},
                {"7", "X", "O"},
            };
            Assert.False(testGame.CheckForWinner(testGame.Board));
        }
    }
}