using System;
using System.IO;

class Template
{
    static void Main(string[] args)
    {
        string[] inputs = File.ReadAllLines("test.txt");
        
        for (int i = 0; i < inputs.Length; i++) {
            // Do something probably
        }
    }
}