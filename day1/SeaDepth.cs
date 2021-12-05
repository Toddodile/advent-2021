using System;
using System.IO;

class TestClass
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("inputs.txt");
        int a = int.Parse(lines[0]);
        int b = int.Parse(lines[1]);
        int c = int.Parse(lines[2]);
        int increases = 0;
        for (int i = 3; i < lines.Length; i++) {
            int currentDepth = int.Parse(lines[i]);
            if (currentDepth > a) {
                increases++;
            }
            a = b;
            b = c;
            c = currentDepth;
        }
        // Display the number of command line arguments.
        Console.WriteLine("Increases: {0}", increases);
    }
}