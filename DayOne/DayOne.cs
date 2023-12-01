using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2022
{

    class DayOne
    {
        public DayOne()
        {
            Test(24000, 1);
            Test(45000, 3);
        }

        public void Test(int target, int noOfPositions)
        {
            var testResultOne = GetTopCalories("test-input-1.txt", noOfPositions);
            if (testResultOne != target)
            {
                throw new Exception("Test Part one not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public int PartOne()
        {
            return GetTopCalories("input-1.txt", 1);
        }

        public int PartTwo()
        {
            return GetTopCalories("input-1.txt", 3);
        }

        public int GetTopCalories(string fileName, int noOfPositions)
        {
            String line;
            var AllElfCalories = new List<int>();

            try
            {
                //Pass the file path and file Name to the StreamReader constructor
                StreamReader sr = new StreamReader("./DayOne/" + fileName);

                var elfCalories = 0;

                //Continue to read until you reach end of file
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    if (line.Equals(""))
                    {
                        AllElfCalories.Add(elfCalories);
                        elfCalories = 0;
                    }
                    else
                    {
                        elfCalories += Int32.Parse(line);
                    }
                }

                AllElfCalories.Add(elfCalories);

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return AllElfCalories.OrderByDescending(x => x).Take(noOfPositions).Sum();

        }



    }

}