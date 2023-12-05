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

                var day = new DayThreePartTwo();
                Console.WriteLine("Part One Result: " + day.PartOne());
                //Console.WriteLine("Part Two Result: " + day.PartTwo());

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


