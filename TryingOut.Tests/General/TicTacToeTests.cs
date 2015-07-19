using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.General;

namespace TryingOut.Tests.General
{
    [TestFixture]
    class TicTacToeTests
    {
        [SetUp]
        public void Setup()
        {
            //also do pass list of entry
            _map = new Dictionary<int, Board>();
            
            var emptyBoard = new Board(3, 3);
            
            var oneFilled = new Board(3, 3);
            oneFilled.SetValue(Player.One, 1, 1);
            
            var twoFilled = new Board(3, 3);
            twoFilled.SetValue(Player.One, 1, 1);
            twoFilled.SetValue(Player.Two, 1, 2);

            var fifthMoveToWinByRow = new Board(3, 3);
            fifthMoveToWinByRow.SetValue(Player.One, 1, 1);
            fifthMoveToWinByRow.SetValue(Player.One, 1, 2);
            fifthMoveToWinByRow.SetValue(Player.Two, 3, 1);
            fifthMoveToWinByRow.SetValue(Player.Two, 3, 2);

            var fifthMoveToWinByColumn = new Board(3, 3);
            fifthMoveToWinByColumn.SetValue(Player.One, 1, 1);
            fifthMoveToWinByColumn.SetValue(Player.One, 2, 1);
            fifthMoveToWinByColumn.SetValue(Player.Two, 1, 3);
            fifthMoveToWinByColumn.SetValue(Player.Two, 2, 3);

            var fifthMoveToWinByTopDiagonal = new Board(3, 3);
            fifthMoveToWinByTopDiagonal.SetValue(Player.One, 1, 1);
            fifthMoveToWinByTopDiagonal.SetValue(Player.One, 2, 2);
            fifthMoveToWinByTopDiagonal.SetValue(Player.Two, 1, 3);
            fifthMoveToWinByTopDiagonal.SetValue(Player.Two, 2, 3);

            var fifthMoveToWinByTopDiagonal_Reverse = new Board(3, 3);
            fifthMoveToWinByTopDiagonal_Reverse.SetValue(Player.One, 3, 3);
            fifthMoveToWinByTopDiagonal_Reverse.SetValue(Player.One, 2, 2);
            fifthMoveToWinByTopDiagonal_Reverse.SetValue(Player.Two, 1, 3);
            fifthMoveToWinByTopDiagonal_Reverse.SetValue(Player.Two, 2, 3);

            var fifthMoveToWinByBottomDiagonal = new Board(3, 3);
            fifthMoveToWinByBottomDiagonal.SetValue(Player.One, 3, 1);
            fifthMoveToWinByBottomDiagonal.SetValue(Player.One, 2, 2);
            fifthMoveToWinByBottomDiagonal.SetValue(Player.Two, 1, 1);
            fifthMoveToWinByBottomDiagonal.SetValue(Player.Two, 3, 3);

            _map.Add(1, emptyBoard);
            _map.Add(2, oneFilled);
            _map.Add(3, twoFilled);
            _map.Add(4, fifthMoveToWinByRow);
            _map.Add(5, fifthMoveToWinByColumn);
            _map.Add(6, fifthMoveToWinByTopDiagonal);
            _map.Add(7, fifthMoveToWinByTopDiagonal_Reverse);
            _map.Add(8, fifthMoveToWinByBottomDiagonal);
        }

        private readonly object[] _game =
        {
            new object[]
            {
                1,
                Player.One,
                1,
                1,
                GameState.GameNotComplete
            },
            new object[]
            {
                1,
                Player.Two,
                3,
                1,
                GameState.GameNotComplete
            },
            new object[]
            {
                2,
                Player.Two,
                1,
                2,
                GameState.GameNotComplete
            },
            new object[]
            {
                2,
                Player.Two,
                1,
                2,
                GameState.GameNotComplete
            },
            new object[]
            {
                3,
                Player.One,
                1,
                3,
                GameState.GameNotComplete
            },
            new object[]
            {
                4,
                Player.One,
                1,
                3,
                GameState.Player1
            },
            new object[]
            {
                5,
                Player.One,
                3,
                1,
                GameState.Player1
            },
            new object[]
            {
                6,
                Player.One,
                3,
                3,
                GameState.Player1
            },
            new object[]
            {
                7,
                Player.One,
                1,
                1,
                GameState.Player1
            },
            new object[]
            {
                8,
                Player.One,
                1,
                3,
                GameState.Player1
            },
        };

        private Dictionary<int, Board> _map;

        [TestCaseSource("_game")]
        public void ShouldReturnGameStateForBoard(int boardNumber, char entry, int rowNumber, int columnNumber, GameState expectedState)
        {
            var board = _map[boardNumber];
            PrintBoard(board, "before");

            var gameState = new TicTacToe(board).Play(entry, rowNumber, columnNumber);

            PrintBoard(board, "after");

            gameState.Should().Be(expectedState);
        }

        private static void PrintBoard(Board board, string msg)
        {
            Console.WriteLine(msg);
            for (var j = 1; j <= board.NumberOfColumns; j++)
            {
                Console.Write("----");
            }

            Console.WriteLine();
            for (var i = 1; i <= board.NumberOfRows; i++)
            {
                Console.Write("| ");
                
                for (var j = 1; j <= board.NumberOfColumns; j++)
                {
                    Console.Write(board.GetEntryAt(i, j) + " | ");
                }

                Console.WriteLine();
                for (var j = 1; j <= board.NumberOfColumns; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
    }
}
