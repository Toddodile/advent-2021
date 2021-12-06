using System;
using System.IO;

class Pathing
{
    static void Main(string[] args)
    {
        int x = 0;
        int y = 0;
        int aim = 0;
        string[] directions = File.ReadAllLines("inputs.txt");
        
        for (int i = 0; i < directions.Length; i++) {
            string[] instruction = directions[i].Split(' ');
            if (instruction[0].Equals("forward")) {
                x += int.Parse(instruction[1]);
                y += int.Parse(instruction[1]) * aim;
            } else if (instruction[0].Equals("down")) {
                aim += int.Parse(instruction[1]);
            } else {
                aim -= int.Parse(instruction[1]);
            }
        }

        Console.WriteLine("Position: ({0}, {1}) at heading {2}", x, y, aim);
        Console.WriteLine("Product: {0}", x * y);
    }
}