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

                var dayOne = new DayOne();
                Console.WriteLine("Part One Result: " + dayOne.PartOne());
                //Console.WriteLine("Part Two Result: " + dayNine.PartTwo());

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


