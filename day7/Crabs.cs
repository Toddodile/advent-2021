using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

class Crabs
{
    static void Main(string[] args)
    {
        string[] inputs = File.ReadAllLines("inputs.txt");
        string[] initialPos = inputs[0].Split(",");

        var data = new List<int>();

        for (int i = 0; i < initialPos.Length; i++) {
            data.Add(Convert.ToInt32(initialPos[i]));
        }

        int max = data.Max();
        List<int> fuel = new List<int>(new int[max]);
        
        foreach (int crab in data) {
            for (int i = 0; i < max; i++) {
                int distance = Math.Abs(crab - i);
                fuel[i] += distance * (distance + 1) / 2;
            }
        }

        int min = int.MaxValue;
        int index = 0;
        for (int i = 0; i < max; i++) {
            if (fuel[i] < min) {
                min = fuel[i];
                index = i;
            }
        }

        Console.WriteLine("Most efficient: {0} requiring {1} fuel", index, min);

    }
}