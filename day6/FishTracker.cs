using System;
using System.IO;

class FishTracker
{
    static void Main(string[] args)
    {
        string[] inputs = File.ReadAllLines("test.txt");
        string[] initialPopulation = inputs[0].Split(",");
        
        for (int i = 0; i < inputs.Length; i++) {
            // Do something probably
        }
    }
}