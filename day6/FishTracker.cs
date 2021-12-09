using System;
using System.IO;

class FishTracker
{
    static void Main(string[] args)
    {
        string[] inputs = File.ReadAllLines("inputs.txt");
        string[] initialPopulation = inputs[0].Split(",");

        long[] population = new long[9];
        
        for (int i = 0; i < initialPopulation.Length; i++) {
            population[Convert.ToInt64(initialPopulation[i])]++;
        }

        for (int i = 0; i < 80; i++) {
            AdvanceDay(ref population);
        }
        long totalPopulation = 0;
        for (int i = 0; i < population.Length; i++) {
            totalPopulation += population[i];
        }

        Console.WriteLine("Lanternfish Population Size: {0}", totalPopulation);
    }

    static void AdvanceDay(ref long[] population) {
        long numSpawning = population[0];
        for (int i = 0; i < population.Length - 1; i++) {
            population[i] = population[i+1];
        }
        population[8] = numSpawning;
        population[6] += numSpawning;
    }
}