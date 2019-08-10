﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {

      var book = new Book("Seth's Grade Book");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(101);
      book.AddGrade(75);

      var stats = book.GetStatistics();

      Console.WriteLine($"The lowest grade is {stats.Low:N1}.");
      Console.WriteLine($"The highest grade is {stats.High:N1}.");
      Console.WriteLine($"The average grade is {stats.Average:N1}.");
      Console.WriteLine($"The letter grade is {stats.Letter}.");

    }
  }


}
