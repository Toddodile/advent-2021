using System;
using System.Collections.Generic;
using System.IO;

namespace Bingo
{
    class Bingo
    {
        static void Main(string[] args)
        {
            string[] inputs = File.ReadAllLines("inputs.txt");
            
            List<Board> boards = new List<Board>();
            for (int i = 2; i < inputs.Length - 4; i += 6) {
                string[] rows = new string[5];
                Array.Copy(inputs, i, rows, 0, 5);
                boards.Add(new Board(rows));
            }

            List<Board> winningBoards = new List<Board>();
            foreach (string call in inputs[0].Split(",")) {
                int calledNum = Convert.ToInt32(call);
                foreach (Board board in boards) {
                    if (board.CheckHit(calledNum)) {
                        // Console.WriteLine("WINNER! Total Score: {0}", board.CalculateScore(calledNum));
                        // return;
                        if (boards.Count == 1) {
                            Console.WriteLine("LOSER! Total Score: {0}", board.CalculateScore(calledNum));
                            return;
                        }
                        winningBoards.Add(board);
                    }
                }
                foreach (Board board in winningBoards) {
                    boards.Remove(board);
                }
                winningBoards.Clear();
            }
        }
    }
}