﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var result = 0.0;

      var book = new Book();
      book.AddGrade(89.1);
 
      var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };

      foreach (double number in grades)
      {
        result += number;
      }

      result /= grades.Count;

      Console.WriteLine($"The average grade is {result:N1}.");

    }
  }


}
