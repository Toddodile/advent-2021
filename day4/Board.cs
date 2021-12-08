using System;

namespace Bingo
{
    class Board 
    {
        private int[][] rows = new int[5][];
        private char[][] hits = {
            new char[] {'o','o','o','o','o'},
            new char[] {'o','o','o','o','o'},
            new char[] {'o','o','o','o','o'},
            new char[] {'o','o','o','o','o'},
            new char[] {'o','o','o','o','o'}
        };
        public Board(string[] numbers) {
            if (numbers.Length != 5) {
                throw new ArgumentException("Board must have 5 rows");
            }
            for (int i = 0; i < numbers.Length; i++) {
                string[] row = numbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (row.Length != 5) {
                    throw new ArgumentException("All rows of a board must have 5 numbers");
                }
                int[] numberRow = new int[row.Length];
                for (int j = 0; j < row.Length; j++) {
                    numberRow[j] = Convert.ToInt32(row[j]);
                }
                rows[i] = numberRow;
            }
        }

        public Boolean CheckHit(int number) {
            for (int i = 0; i < rows.Length; i++) {
                for (int j = 0; j < rows[i].Length; j++) {
                    if (rows[i][j] == number) {
                        hits[i][j] = 'x';
                        return CheckWin(i, j);
                    }
                }
            }
            return false;
        }

        Boolean CheckWin(int row, int column) {
            Boolean rowBroken = false;
            Boolean columnBroken = false;
            for (int i = 0; i < 5; i++) {
                if (hits[row][i] == 'o') {
                    rowBroken = true;
                }
                if (hits[i][column] == 'o') {
                    columnBroken = true;
                }
                if (rowBroken && columnBroken) {
                    return false;
                }
            }
            return true;
        }

        public int CalculateScore(int winningNumber) {
            int sum = 0;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (hits[i][j] == 'o') {
                        sum += rows[i][j];
                    }
                }
            }
            return sum * winningNumber;
        }

        public override string ToString() {
            string board = "";
            for (int i = 0; i < 5; i++) {
                board += string.Join(", ", rows[i]);
                if (i != 4) {
                    board += "\n";
                }
            }
            return board;
        }
    }
}