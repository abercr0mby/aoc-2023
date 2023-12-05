using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2023
{
    class Part
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Length { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
        public bool AdjacentToGear { get; set; }
    }

    class DayThreePartTwo
    {
        public List<Part> Gears = new List<Part>();
        public List<Part> Parts = new List<Part>();
        public List<List<char>> schematic = new List<List<char>>();

        public DayThreePartTwo()
        {
            Test(467835);
        }

        public void Test(int target)
        {
            var testResultOne = SumPartNumbers("test-input-1.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part one not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
            Gears = new List<Part>();
            Parts = new List<Part>();
            schematic = new List<List<char>>();
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
            long prodOfParts = 0;
            long sumOfParts = 0;

            schematic = CreateSchematic(lines);
            PopulateParts();

            foreach (var gear in Gears)
            {
                var parts = GetAdjacentParts(gear);

                if (parts.Count == 2)
                {
                    prodOfParts = parts[0].Value * parts[1].Value;
                    Console.WriteLine("Gear: " + gear.XPos + " : " + gear.YPos + " Part 1: " + parts[0].Value + " Part 2: " + parts[1].Value);
                }
                sumOfParts += prodOfParts;
                prodOfParts = 0;
            }

            return sumOfParts;
        }

        public List<Part> GetAdjacentParts(Part gear)
        {
            var adjacentParts = new List<Part>();
            foreach (var part in Parts)
            {
                if ((gear.XPos >= part.XPos - 1 && gear.XPos <= part.XPos + part.Length)
                && (gear.YPos >= part.YPos - 1 && gear.YPos <= part.YPos + 1))
                {
                    adjacentParts.Add(part);
                }
            }
            return adjacentParts;
        }


        public List<List<char>> CreateSchematic(List<string> lines)
        {
            var schematic = new List<List<char>>();
            foreach (var line in lines.Select((line, index) => new { line, index }))
            {
                var schematicLine = new List<char>();

                foreach (var c in line.line.Select((c, index) => new { c, index }))
                {
                    if (Char.IsDigit(c.c) || c.c == '.' || c.c == '*')
                        schematicLine.Add(c.c);
                    else
                    {
                        schematicLine.Add('.');
                    }

                    if (c.c == '*')
                        Gears.Add(new Part
                        {
                            XPos = c.index,
                            YPos = line.index
                        });
                }

                schematic.Add(schematicLine);
                foreach (var c in schematicLine)
                    Console.Write(c);
                Console.WriteLine("");
            }
            Console.WriteLine("Gears: " + Gears.Count);
            foreach (var g in Gears)
            {
                Console.WriteLine(g.XPos + " - " + g.YPos);
            }
            return schematic;
        }



        public bool IsAdjacentToGear(int line, int column, List<List<char>> schematic)
        {
            //Check line above
            if (schematic[Math.Max(line - 1, 0)][Math.Max(column - 1, 0)] == '*')
                return true;

            if (schematic[Math.Max(line - 1, 0)][column] == '*')
                return true;

            if (schematic[Math.Max(line - 1, 0)][Math.Min(column + 1, schematic[0].Count - 1)] == '*')
                return true;

            //Check line below
            if (schematic[Math.Min(line + 1, schematic.Count - 1)][Math.Max(column - 1, 0)] == '*')
                return true;

            if (schematic[Math.Min(line + 1, schematic.Count - 1)][column] == '*')
                return true;

            if (schematic[Math.Min(line + 1, schematic.Count - 1)][Math.Min(column + 1, schematic[0].Count - 1)] == '*')
                return true;

            //Check left and right
            if (schematic[line][Math.Max(column - 1, 0)] == '*')
                return true;

            if (schematic[line][Math.Min(column + 1, schematic[0].Count - 1)] == '*')
                return true;

            return false;
        }

        public void PopulateParts()
        {
            Part part = null;

            try
            {
                foreach (var line in schematic.Select((line, index) => new { line, index }))
                {
                    foreach (var c in line.line.Select((c, index) => new { c, index }))
                    {
                        if (Char.IsDigit(c.c))
                        {
                            if (part == null)
                                part = new Part
                                {
                                    XPos = c.index,
                                    YPos = line.index
                                };

                            part.Text += c.c;

                            if (!part.AdjacentToGear
                            && IsAdjacentToGear(line.index, c.index, schematic))
                                part.AdjacentToGear = true;
                        }

                        if ((!Char.IsDigit(c.c) || c.index == line.line.Count - 1))
                        {
                            if (part != null && part.AdjacentToGear)
                                Parts.Add(new Part
                                {
                                    XPos = part.XPos,
                                    YPos = part.YPos,
                                    Text = part.Text,
                                    Value = Int32.Parse(part.Text),
                                    Length = part.Text.Length
                                });
                            part = null;
                        }
                    }
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
        }
    }
}