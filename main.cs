using System;

namespace aoc_2023
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var dayTwo = new DayTwo();
                Console.WriteLine("Part One Result: " + dayTwo.PartOne());
                Console.WriteLine("Part Two Result: " + dayTwo.PartTwo());

                watch.Stop();
                Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}


