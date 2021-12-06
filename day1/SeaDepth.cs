using System;
using System.IO;

class TestClass
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("inputs.txt");
        int increases = 0;
        for (int i = 3; i < lines.Length; i++) {
            int currentDepth = int.Parse(lines[i]);
            if (int.Parse(lines[i]) > int.Parse(lines[i-3])) {
                increases++;
            }
        }
        // Display the number of command line arguments.
        Console.WriteLine("Increases: {0}", increases);
    }
}