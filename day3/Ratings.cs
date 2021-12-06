using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Ratings
{
    static void Main(string[] args)
    {
        string[] readings = File.ReadAllLines("inputs.txt");
        string[] powerRatings = GetCommonBits(readings);
        string gammaBits = powerRatings[0];
        string epsilonBits = powerRatings[1];
        int gamma = Convert.ToInt32(powerRatings[0], 2);
        int epsilon = Convert.ToInt32(powerRatings[1], 2);
        Console.WriteLine("Power Readings: ({0}, {1})", powerRatings[0], powerRatings[1]);
        Console.WriteLine("Power Readings: ({0}, {1})", gamma, epsilon);
        Console.WriteLine("Power Draw: {0}", gamma * epsilon);

        List<string> oxygenValues = new List<string> (readings);
        List<string> co2Values = new List<string> (readings);

        int bitPos = 0;
        List<string> tempList = new List<string>();
        do {
            foreach (string reading in oxygenValues) {
                if (reading[bitPos] == powerRatings[0][bitPos]) {
                    tempList.Add(reading);
                }
            }
            oxygenValues.Clear();
            oxygenValues.AddRange(tempList);
            tempList.Clear();
            bitPos++;
            powerRatings = GetCommonBits(oxygenValues.ToArray());
        } while (oxygenValues.Count > 1);
        int oxygenValue = Convert.ToInt32(oxygenValues[0], 2);

        bitPos = 0;
        powerRatings[1] = epsilonBits;
        do {
            foreach (string reading in co2Values) {
                if (reading[bitPos] == powerRatings[1][bitPos]) {
                    tempList.Add(reading);
                }
            }
            co2Values.Clear();
            co2Values.AddRange(tempList);
            tempList.Clear();
            bitPos++;
            powerRatings = GetCommonBits(co2Values.ToArray());
        } while (co2Values.Count > 1);
        int co2Value = Convert.ToInt32(co2Values[0], 2);

        Console.WriteLine("Life Support Readings: ({0}, {1})", oxygenValues[0], co2Values[0]);
        Console.WriteLine("Life Support Readings: ({0}, {1})", oxygenValue, co2Value);
        Console.WriteLine("Life Support Status: {0}", oxygenValue * co2Value);
    }

    static string[] GetCommonBits(string[] readings) {
        int numSize = readings[0].Length;
        int[] bitSums = new int[numSize];
        
        for (int i = 0; i < readings.Length; i++) {
            for (int j = 0; j < numSize; j++) {
                if (readings[i][j] == '1') {
                    bitSums[j]++;
                }
            }
        }

        string gammaBits = "";
        string epsilonBits = "";
        for (int i = 0; i < numSize; i++) {
            //Console.WriteLine(bitSums[i]);
            if (bitSums[i] >= (readings.Length + 1) / 2) {
                gammaBits += "1";
                epsilonBits += "0";
            } else {
                gammaBits += "0";
                epsilonBits += "1";
            }
        }

        return new string[] {gammaBits, epsilonBits};
    }
}