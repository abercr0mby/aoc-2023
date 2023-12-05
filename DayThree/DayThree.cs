using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2023
{

    class DayThree
    {
        
        public DayThree()
        {
            Test(4361);
            //Test(0);
        }

        public void Test(int target)
        {
            var testResultOne = SumPartNumbers("test-input-1.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part one not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public long PartOne()
        {
            return SumPartNumbers("input-1.txt"); ;
        }

        public int PartTwo()
        {
            return 0;
        }

        public long SumPartNumbers(string fileName)
        {
            var lines = Utils.FileToStringList("./DayThree/" + fileName);
            long sumOfParts = 0;

            var schematic = CreateSchematic(lines);

            try
            {
                foreach (var line in schematic.Select((line, index) => new { line, index }))
                {
                    var number = "";
                    var adjacent = false;

                    foreach (var c in line.line.Select((c, index) => new { c, index }))
                    {
                        if (Char.IsDigit(c.c))
                        {
                            number += c.c;
                            if (!adjacent && IsAdjacent(line.index, c.index, schematic))
                                adjacent = true;
                        }

                        if ((!Char.IsDigit(c.c) || c.index == line.line.Count - 1))
                        {
                            if (adjacent)
                                sumOfParts += Int32.Parse(number);
                            number = "";
                            adjacent = false;
                        }
                    }

                    Console.WriteLine(line.line + " : " + line.index);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + " : " + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return sumOfParts;
        }


        public List<List<char>> CreateSchematic(List<string> lines)
        {
            var schematic = new List<List<char>>();
            foreach (var line in lines)
            {
                var schematicLine = new List<char>();

                foreach (var c in line)
                {
                    if (Char.IsDigit(c) || c == '.')
                        schematicLine.Add(c);
                    else
                    {
                        schematicLine.Add('x');
                    }
                }

                schematic.Add(schematicLine);
                foreach (var c in schematicLine)
                    Console.Write(c);
                Console.WriteLine("");
            }
            return schematic;
        }



        public bool IsAdjacent(int line, int column, List<List<char>> schematic)
        {
            //Check line above
            if (schematic[Math.Max(line - 1, 0)][Math.Max(column - 1, 0)] == 'x')
                return true;

            if (schematic[Math.Max(line - 1, 0)][column] == 'x')
                return true;

            if (schematic[Math.Max(line - 1, 0)][Math.Min(column + 1, schematic[0].Count - 1)] == 'x')
                return true;

            //Check line below
            if (schematic[Math.Min(line + 1, schematic.Count - 1)][Math.Max(column - 1, 0)] == 'x')
                return true;

            if (schematic[Math.Min(line + 1, schematic.Count - 1)][column] == 'x')
                return true;

            if (schematic[Math.Min(line + 1, schematic.Count - 1)][Math.Min(column + 1, schematic[0].Count - 1)] == 'x')
                return true;

            //Check left and right
            if (schematic[line][Math.Max(column - 1, 0)] == 'x')
                return true;

            if (schematic[line][Math.Min(column + 1, schematic[0].Count - 1)] == 'x')
                return true;

            return false;
        }



    }

}