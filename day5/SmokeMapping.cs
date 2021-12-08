using System;
using System.IO;
using System.Collections.Generic;

namespace day5
{
    class SmokeMapping
    {
        static void Main(string[] args)
        {
            string[] inputs = File.ReadAllLines("test.txt");

            Dictionary<Point, int> smokeMap = new Dictionary<Point, int>();
            
            for (int i = 0; i < inputs.Length; i++) {
                string points = inputs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Point start = new Point(points[0]);
                Point end = new Point(points[2]);
                if (start.GetX() == end.GetX()) {
                    // Find lower and go
                } else if (start.GetY() == end.GetY()) {
                    // Find lower and go
                }
            }
        }
    }
}