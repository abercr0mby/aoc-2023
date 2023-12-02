using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2023
{

    class DayTwo
    {

      Dictionary<string, int> cubeCounts = new Dictionary<string, int>();

        public DayTwo()
        {
          cubeCounts.Add("red",12);
          cubeCounts.Add("green",13);
          cubeCounts.Add("blue",14);
          
            Test1(8);
            Test2(2286);
        }

        public void Test1(int target)
        {
            var testResultOne = FindPossibleGames("test-input-1.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part one not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public void Test2(int target)
        {
            var testResultOne = FindGamesPower("test-input-1.txt");
            if (testResultOne != target)
            {
                throw new Exception("Test Part two not equal to " + target.ToString() + " :" + testResultOne.ToString());
            }
        }

        public int PartOne()
        {
            return FindPossibleGames("input-1.txt");;
        }

        public int PartTwo()
        {
            return FindGamesPower("input-1.txt");
        }

      public int FindGamesPower(string fileName)
      {
          String line;
          var gamePower = 0;

          try
          {
              //Pass the file path and file Name to the StreamReader constructor
              StreamReader sr = new StreamReader("./DayTwo/" + fileName);

              //Continue to read until you reach end of file
              while (!sr.EndOfStream)
              {
                  line = sr.ReadLine();
                  var gameBits = line.Split(":");
                  var gameNo = Int32.Parse(gameBits[0].Split(" ")[1]);
                  gamePower += FindGamePower(gameBits[1]);
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

          return gamePower;

      }


      public int FindGamePower(string gameString)
      {
        Dictionary<string, int> cubeCounts = new Dictionary<string, int>();
        cubeCounts["red"] = 0;
        cubeCounts["green"] = 0;
        cubeCounts["blue"] = 0;
        
        var sets = gameString.Split(";");
        foreach(var set in sets)
        {
          var cubes = set.Split(","); 
          foreach(var cubeColour in cubes)
          {
            var colourAndCount = cubeColour.Trim().Split(" ");
            if(Int32.Parse(colourAndCount[0]) > cubeCounts[colourAndCount[1]])
              cubeCounts[colourAndCount[1]] = Int32.Parse(colourAndCount[0]);
          }
        }
        return cubeCounts["red"] * cubeCounts["green"] * cubeCounts["blue"];
      }
      
        public int FindPossibleGames(string fileName)
        {
            String line;
            var possibleSum = 0;

            try
            {
                //Pass the file path and file Name to the StreamReader constructor
                StreamReader sr = new StreamReader("./DayTwo/" + fileName);
              
                //Continue to read until you reach end of file
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    var gameBits = line.Split(":");
                    var gameNo = Int32.Parse(gameBits[0].Split(" ")[1]);
                    if (IsGamePossible(gameBits[1]))
                      possibleSum += gameNo;
                    
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
          
            return possibleSum;

        }

        public bool IsGamePossible(string gameString)
        {
          var sets = gameString.Split(";");
          foreach(var set in sets)
          {
            var cubes = set.Split(","); 
            foreach(var cubeColour in cubes)
            {
              var colourAndCount = cubeColour.Trim().Split(" ");
              if(Int32.Parse(colourAndCount[0]) > cubeCounts[colourAndCount[1]])
                return false;
            }
          }
          return true;
        }
    }

}