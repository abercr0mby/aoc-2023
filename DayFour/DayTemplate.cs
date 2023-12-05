using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2023
{

    class DayTemplate
    {
        public DayTemplate()
        {
            Test(0);
            Test(0);
        }

        public void Test(int target)
        {
            var testResultOne = GetTopCalories("test-input-1.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part one not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public int PartOne()
        {
            return 0;
        }

        public int PartTwo()
        {
            return 0;
        }

        public int GetTopCalories(string fileName)
        {
            var lines = Utils.FileToStringList("./DayTemplate/" + fileName);
            try
            {
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + " : " + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return 0;
        }



    }

}