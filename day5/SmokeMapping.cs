using System;
using System.IO;
using System.Collections.Generic;

namespace day5
{
    class SmokeMapping
    {
        static void Main(string[] args)
        {
            string[] inputs = File.ReadAllLines("inputs.txt");

            Dictionary<Point, int> smokeMap = new Dictionary<Point, int>();
            
            for (int i = 0; i < inputs.Length; i++) {
                string[] points = inputs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Point start = new Point(points[0]);
                Point end = new Point(points[2]);
                int high;
                int low;
                if (start.GetX() == end.GetX()) {
                    if (start.GetY() > end.GetY()) {
                        high = start.GetY();
                        low = end.GetY();
                    } else {
                        high = end.GetY();
                        low = start.GetY();
                    }
                    for (int j = low; j <= high; j++) {
                        Point point = new Point(start.GetX(), j);
                        if (smokeMap.ContainsKey(point)) {
                            smokeMap[point]++;
                        } else {
                            smokeMap.Add(point, 1);
                        }
                    }
                } else if (start.GetY() == end.GetY()) {
                    if (start.GetX() > end.GetX()) {
                        high = start.GetX();
                        low = end.GetX();
                    } else {
                        high = end.GetX();
                        low = start.GetX();
                    }
                    for (int j = low; j <= high; j++) {
                        Point point = new Point(j, start.GetY());
                        if (smokeMap.ContainsKey(point)) {
                            smokeMap[point]++;
                        } else {
                            smokeMap.Add(point, 1);
                        }
                    }
                }
            }
            int heavilySmoked = 0;
            foreach(KeyValuePair<Point, int> point in smokeMap) {
                if (point.Value > 1) {
                    heavilySmoked++;
                }
            }
            Console.WriteLine("Heavily obscured points: {0}", heavilySmoked);
        }
    }
}