using System;
using System.Collections.Generic;
using System.IO;

namespace aoc_2023
{

    class Utils
    {
        public static List<String> FileToStringList(string fileName)
        {
            var lines = new List<string>();

            try
            {
                //Pass the file path and file Name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Continue to read until you reach end of file
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }

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

            return lines;

        }
    }
}
