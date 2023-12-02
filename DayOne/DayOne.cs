using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2023
{

    class DayOne
    {
        List<string> numbers = new List<string>()
      {
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
      };

        public DayOne()
        {
            Test1(142);
            Test2(281);
        }

        public void Test1(int target)
        {
            var testResultOne = GetCalibrationValue("test-input-1.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part one not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public void Test2(int target)
        {
            var testResultOne = GetCalibrationValue("test-input-2.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part two not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public int PartOne()
        {
            return GetCalibrationValue("input-1.txt"); ;
        }

        public int PartTwo()
        {
            return 0;
        }

        public int GetCalibrationValue(string fileName)
        {
            String line;
            var AllCalibrationValues = new List<int>();

            try
            {
                //Pass the file path and file Name to the StreamReader constructor
                StreamReader sr = new StreamReader("./DayOne/" + fileName);

                char firstNumber = ' ';
                char lastNumber = ' ';
                var numberString = "";
                var lineNo = 0;

                //Continue to read until you reach end of file
                while (!sr.EndOfStream)
                {
                    lineNo++;

                    line = sr.ReadLine();
                    foreach (var c in line)
                    {
                        if (Char.IsDigit(c))
                        {
                            if (firstNumber == ' ')
                                firstNumber = c;
                            else
                                lastNumber = c;

                            numberString = "";
                        }
                        else
                        {
                            numberString = numberString + c.ToString();
                            while (true)
                            {
                                if (numbers.Any(n => n.StartsWith(numberString)))
                                {
                                    break;
                                }
                                else
                                    numberString = numberString.Substring(1);
                            }


                            try
                            {
                                var numberMatch = numbers.Select((n, i) => new { n, i }).Where(n => n.n.Equals(numberString)).First();
                                if (firstNumber == ' ')
                                    firstNumber = (char)(numberMatch.i + 49);
                                else
                                    lastNumber = (char)(numberMatch.i + 49);
                                numberString = c.ToString();
                            }
                            catch (Exception e)
                            { }

                        }

                    }
                    if (lastNumber == ' ')
                        lastNumber = firstNumber;

                    Console.WriteLine("lineNo: " + lineNo + " " + firstNumber.ToString() + " " + lastNumber.ToString());
                    AllCalibrationValues.Add(Int32.Parse(firstNumber.ToString() + lastNumber.ToString()));

                    firstNumber = ' ';
                    lastNumber = ' ';
                    numberString = "";

                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + " " + e.Source + " " + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }



            Console.WriteLine(AllCalibrationValues.Count);
            return AllCalibrationValues.Sum();

        }



    }

}