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
                if (start.GetX() == end.GetX()) {
                    int high;
                    int low;   
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
                } else {
                    PopulateLine(start, end, ref smokeMap);
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

        static void PopulateLine(Point p1, Point p2, ref Dictionary<Point, int> map) {
            int slope = (p2.GetY() - p1.GetY()) / (p2.GetX() - p1.GetX());
            int b = p1.GetY() - slope * p1.GetX();
            int low = Math.Min(p1.GetX(), p2.GetX());
            int high = Math.Max(p1.GetX(), p2.GetX());
            for (int i = low; i <= high; i++) {
                int y = slope * i + b;
                Point point = new Point(i, slope * i + b);
                if (map.ContainsKey(point)) {
                    map[point]++;
                } else {
                    map.Add(point, 1);
                }
            }
        }
    }
}