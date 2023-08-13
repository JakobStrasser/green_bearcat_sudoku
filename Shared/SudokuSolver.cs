
namespace Sudoku.Shared
{
    public class SudokuSolver
    {
        public int[] Board { get;set; }
        
        public bool Solve()
        {
            return SolveSudoku(Board);
        }
        private bool SolveSudoku(int[] board)
        {
            int emptyCellIndex = FindEmptyCell(board);

            // If there are no empty cells left, the puzzle is solved
            if (emptyCellIndex == -1)
                return true;
            int currentIndex = emptyCellIndex;
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(board, emptyCellIndex, num))
                {
                    board[emptyCellIndex] = num;

                    if (SolveSudoku(board))
                        return true; // If puzzle can be solved recursively
                    

                    // If placing the current number leads to an incorrect solution, backtrack
                    board[emptyCellIndex] = -1;
                }
            }

            // No valid number found, need to backtrack
            return false;
        }

        public int FindEmptyCell(int[] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == -1)
                    return i; // Found an empty cell
            }
            return -1; // All cells are filled
        }

        public bool IsSafe(int[] board, int index, int num)
        {
            int row = index / 9;
            int col = index % 9;

            // Check if 'num' is not present in the current row, column, and 3x3 subgrid
            for (int i = 0; i < 9; i++)
            {
                if (board[row * 9 + i] == num || board[i * 9 + col] == num || board[(row - row % 3 + i / 3) * 9 + (col - col % 3 + i % 3)] == num)
                    return false;
            }
            return true;
        }

      
    }
}
