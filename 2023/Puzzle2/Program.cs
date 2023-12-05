using System;
using System.IO;
using System.Linq;

namespace Puzzle2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("puzzle_input.txt");
            int red = 12;
            int blue = 14;
            int green = 13;
            bool possible = true;
            var sumId = 0;
            int minRed = 1;
            int minBlue = 1;
            int minGreen = 1;
            int sumPower = 0;

            // PART 1
            foreach (var line in lines)
            {
                var game = line.Split(':');
                var id = new String(game[0].Where(Char.IsDigit).ToArray());
                var record = game[1].Split(';');
                for (int i = 0; i < record.Length; i++)
                {
                    var iteration = record[i].Split(',');
                    for(int j = 0;j< iteration.Length;j++)
                    {
                        var num = new String(iteration[j].Where(Char.IsDigit).ToArray());
                        if(iteration[j].Contains("blue"))
                        {
                            if(Int32.Parse(num) > blue)
                            {
                                possible = false;
                                goto endOfLoops;
                            }
                        }
                        if(iteration[j].Contains("red"))
                        {
                            if(Int32.Parse(num) > red)
                            {
                                possible = false;
                                goto endOfLoops;
                            }
                        }
                        if (iteration[j].Contains("green"))
                        {
                            if (Int32.Parse(num) > green)
                            {
                                possible = false;
                                goto endOfLoops;
                            }
                        }
                    }
                }
                endOfLoops: 
                {
                    if(possible)
                    {
                        sumId += Int32.Parse(id);
                    }
                    possible = true;
                }

            }
            Console.WriteLine("Sum of IDs is: {0}", sumId);

            //PART 2
            foreach (var line in lines)
            {
                var game = line.Split(':');
                var id = new String(game[0].Where(Char.IsDigit).ToArray());
                var record = game[1].Split(';');
                for (int i = 0; i < record.Length; i++)
                {
                    var iteration = record[i].Split(',');
                    for (int j = 0; j < iteration.Length; j++)
                    {
                        var num = new String(iteration[j].Where(Char.IsDigit).ToArray());
                        if (iteration[j].Contains("blue"))
                        {
                            if (minBlue < Int32.Parse(num))
                                minBlue = Int32.Parse(num);
                        }
                        if (iteration[j].Contains("red"))
                        {
                            if (minRed < Int32.Parse(num))
                                minRed = Int32.Parse(num);
                        }
                        if (iteration[j].Contains("green"))
                        {
                            if (minGreen < Int32.Parse(num))
                                minGreen = Int32.Parse(num);
                        }
                    }
                }
                sumPower = sumPower + minRed * minGreen * minBlue;
                minBlue = 1;
                minRed = 1;
                minGreen = 1;

            }
            Console.WriteLine("Sum of powers is: {0}",sumPower);
        }
    }
}
