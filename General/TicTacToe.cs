using System;
using System.Collections.Generic;
using System.Linq;

namespace TryingOut.General
{
    public class TicTacToe
    {
        private readonly Board _board;
        private char[] _rowEntry;
        private int[] _rowEntryCount;
        private char[] _columnEntry;
        private int[] _columnEntryCount;
        private char[] _topDiagonalEntry;
        private char[] _bottomDiagonalEntry;
        private GameState _previousGameState = GameState.GameNotComplete;
        private GameState _currentGameState = GameState.GameNotComplete;

        public TicTacToe(int rowNumber, int columnNumber)
        {
            _board = new Board(rowNumber, columnNumber);

            InitializeMonitor(_board);
        }

        public TicTacToe(Board board)
        {
            _board = board;

            InitializeMonitor(board);

            InitializeMonitors(board);
        }

        private void InitializeMonitor(Board board)
        {
            _rowEntry = new char[board.NumberOfRows];
            _rowEntryCount = new int[board.NumberOfRows];

            _columnEntry = new char[board.NumberOfColumns];
            _columnEntryCount = new int[board.NumberOfColumns];

            _topDiagonalEntry = new char[board.NumberOfRows];
            
            _bottomDiagonalEntry = new char[board.NumberOfRows];
        }

        private void InitializeMonitors(Board board)
        {
            for (var i = 1; i <= board.NumberOfRows; i++)
            {
                for (var j = 1; j <= board.NumberOfColumns; j++)
                {
                    var entry = board.GetEntryAt(i, j);
                    if (entry != default(char))
                    {
                        UpdateMonitor(entry, i - 1, _rowEntry, _rowEntryCount);
                        UpdateMonitor(entry, j - 1, _columnEntry, _columnEntryCount);

                        if (i == j)
                        {
                            _topDiagonalEntry[i - 1] = entry;
                        }

                        if (j == board.NumberOfColumns - i + 1)
                        {
                            _bottomDiagonalEntry[j - 1] = entry;
                        }
                    }
                }
            }
        }

        public GameState Play(char entry, int rowNumber, int columnNumber)
        {
            //can also check previous player and current player are same by saving previous entry and throw exception if needed

            if (IsGameComplete() || IsBoardFull())
            {
                throw new Exception("Game is already over, start over");
            }

            _board.SetValue(entry, rowNumber, columnNumber);

            if(UpdateMonitorAndCheckIfGameIsOver(entry, rowNumber - 1, _rowEntry, _rowEntryCount))
            {
                return _currentGameState;
            }

            if (UpdateMonitorAndCheckIfGameIsOver(entry, columnNumber - 1, _columnEntry, _columnEntryCount))
            {
                return _currentGameState;
            }

            if (rowNumber == columnNumber && UpdateMonitorForDiagonalAndCheckIfGameIsOver(entry, rowNumber - 1, _topDiagonalEntry))
            {
                return _currentGameState;
                //_topDiagonalEntry[rowNumber - 1] = entry;

                //if (_topDiagonalEntry.All(x => x == entry))
                //{
                //    _currentGameState = entry == Player.One ? GameState.Player1 : GameState.Player2;
                //    _previousGameState = _currentGameState;
                //    return _currentGameState;
                //}
            }

            if ((columnNumber == _board.NumberOfColumns - rowNumber + 1) && UpdateMonitorForDiagonalAndCheckIfGameIsOver(entry, columnNumber - 1, _bottomDiagonalEntry))
            {
                return _currentGameState;
                //_bottomDiagonalEntry[columnNumber - 1] = entry;
                
                //if (_bottomDiagonalEntry.All(x => x == entry))
                //{
                //    _currentGameState = entry == Player.One ? GameState.Player1 : GameState.Player2;
                //    _previousGameState = _currentGameState;
                //    return _currentGameState;
                //}
            }

            //if (UpdateMonitorForBottomDiagonalAndCheckIfGameIsOver(entry, rowNumber - 1, columnNumber - 1, _bottomDiagonalEntry, _bottomDiagonalEntryCount))
            //{
            //    return _currentGameState;
            //}

            /*
            second set of optimization
            UpdateMonitor(entry, rowNumber - 1, _rowEntry, _rowEntryCount);
            if (CheckIfGameIsOver(rowNumber - 1, _rowEntry, _rowEntryCount))
            {
                return _currentGameState;
            }

            UpdateMonitor(entry, columnNumber - 1, _columnEntry, _columnEntryCount);
            if (CheckIfGameIsOver(columnNumber - 1, _columnEntry, _columnEntryCount))
            {
                return _currentGameState;
            }*/

            //UpdateRowMonitor(entry, rowNumber - 1);
            //UpdateColumnMonitor(entry, columnNumber - 1);

            //if (CheckIfRowIfFull(rowNumber - 1))
            //{
            //    return _currentGameState;
            //}

            //if (CheckIfColumnIsFull(columnNumber - 1))
            //{
            //    return _currentGameState;
            //}

            if (IsBoardFull())
            {
                _previousGameState = _currentGameState = GameState.NoResult;
                return _currentGameState;
            }

            return _currentGameState;
        }

        private bool UpdateMonitorForDiagonalAndCheckIfGameIsOver(char entry, int index, char[] diagonalEntry)
        {
            diagonalEntry[index] = entry;

            if (diagonalEntry.All(x => x == entry))
            {
                _currentGameState = entry == Player.One ? GameState.Player1 : GameState.Player2;
                _previousGameState = _currentGameState;
                return true;
            }
            return false;
        }

        private bool UpdateMonitorAndCheckIfGameIsOver(char entry, int index, IList<char> monitor, IList<int> monitorEntryCount)
        {
            UpdateMonitor(entry, index, monitor, monitorEntryCount);
            return CheckIfGameIsOver(index, monitor, monitorEntryCount);
        }

        private bool CheckIfGameIsOver(int index, IList<char> monitor, IList<int> monitorEntryCount)
        {
            if (monitorEntryCount[index] == monitorEntryCount.Count && monitor[index] != Player.NoResult)
            {
                _currentGameState = monitor[index] == Player.One ? GameState.Player1 : GameState.Player2;
                _previousGameState = _currentGameState;
                return true;
            }
            return false;
        }

        private void UpdateMonitor(char entry, int index, IList<char> monitor, IList<int> monitorEntryCount)
        {
            if (monitor[index] == default(char))
            {
                monitor[index] = entry;
            }
            else if (monitor[index] != entry)
            {
                monitor[index] = Player.NoResult;
            }

            monitorEntryCount[index] = monitorEntryCount[index] + 1;
        }
        
        private bool IsBoardFull()
        {
            return _rowEntry.All(x => x == Player.NoResult);
        }

        private bool IsGameComplete()
        {
            return _previousGameState == GameState.Player1 || _previousGameState == GameState.Player2 || _previousGameState == GameState.NoResult;
        }

        //private bool CheckIfColumnIsFull(int columnIndex)
        //{
        //    if (_columnEntryCount[columnIndex] == _columnEntryCount.Length && _columnEntry[columnIndex] != Player.NoResult)
        //    {
        //        _currentGameState = _columnEntry[columnIndex] == Player.One ? GameState.Player1 : GameState.Player2;
        //        return true;
        //    }
        //    return false;
        //}

        //private bool CheckIfRowIfFull(int rowIndex)
        //{
        //    if (_rowEntryCount[rowIndex] == _rowEntryCount.Length && _rowEntry[rowIndex] != Player.NoResult)
        //    {
        //        _currentGameState = _rowEntry[rowIndex] == Player.One ? GameState.Player1 : GameState.Player2;
        //        return true;
        //    }
        //    return false;
        //}

        //private void UpdateRowMonitor(char entry, int rowIndex)
        //{
        //    if (_rowEntry[rowIndex] == default (char))
        //    {
        //        _rowEntry[rowIndex] = entry;
        //    }
        //    else if(_rowEntry[rowIndex] != entry)
        //    {
        //        _rowEntry[rowIndex] = Player.NoResult;
        //    }

        //    _rowEntryCount[rowIndex] = _rowEntryCount[rowIndex] + 1;
        //}

        //private void UpdateColumnMonitor(char entry, int columnIndex)
        //{
        //    if (_columnEntry[columnIndex] == default(char))
        //    {
        //        _columnEntry[columnIndex] = entry;
        //    }
        //    else if (_rowEntry[columnIndex] != entry)
        //    {
        //        _columnEntry[columnIndex] = Player.NoResult;
        //    }

        //    _columnEntryCount[columnIndex] = _columnEntryCount[columnIndex] + 1;
        //}
    }

    public class Player
    {
        public const char One = 'x';
        public const char Two = 'o';
        public const char NoResult = 'i';
    }

    public class Board
    {
        private char[][] _board;
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;

        public Board() : this(3, 3)
        {
            
        }

        public Board(int row, int column)
        {
            _numberOfRows = row;
            _numberOfColumns = column;

            _board = new char[row][];
            for (var i = 0;  i < _numberOfRows; i++)
            {
                _board[i] = new char[_numberOfColumns];
            }
        }

        public int NumberOfRows
        {
            get { return _numberOfRows; }
        }

        public int NumberOfColumns
        {
            get { return _numberOfColumns; }
        }

        public char GetEntryAt(int rowNumber, int columnNumber)
        {
            if (rowNumber > NumberOfRows || rowNumber < 1 ||
                columnNumber > NumberOfColumns || columnNumber < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _board[rowNumber - 1][columnNumber - 1];
        }

        public void SetValue(char entry, int rowNumber, int columnNumber)
        {
            ThrowExceptionIfInvalidRange(rowNumber, columnNumber);

            if (_board[rowNumber - 1][columnNumber - 1] != default (char))
            {
                throw new Exception("Already filled");
            }

            _board[rowNumber - 1][columnNumber - 1] = entry;
        }

        private void ThrowExceptionIfInvalidRange(int rowNumber, int columnNumber)
        {
            if (rowNumber > NumberOfRows || rowNumber < 1 ||
                columnNumber > NumberOfColumns || columnNumber < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum GameState
    {
        GameNotComplete = 0,
        Player1,
        Player2,
        NoResult
    }
}
