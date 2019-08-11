﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {

      var book = new InMemoryBook("Seth's Grade Book");
      book.GradeAdded += OnGradeAdded;
      EnterGrades(book);

      var stats = book.GetStatistics();

      Console.WriteLine(InMemoryBook.CATEGORY);
      Console.WriteLine($"For the book named {book.Name}");
      Console.WriteLine($"The lowest grade is {stats.Low:N1}.");
      Console.WriteLine($"The highest grade is {stats.High:N1}.");
      Console.WriteLine($"The average grade is {stats.Average:N1}.");
      Console.WriteLine($"The letter grade is {stats.Average:N1}.");

      Console.WriteLine("Exiting program . . .");

    }

    private static void EnterGrades(IBook book)
    {
      while (true)
      {
        Console.WriteLine("Enter a grade or 'q' to quit");
        var input = Console.ReadLine();

        if (input == "q")
        {
          break;
        }

        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added!");
    }
  }


}
