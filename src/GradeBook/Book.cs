using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      Name = name;
    }
    public string AddGrade(double grade)
    {
      if (grade >= 0 && grade <= 100)
      {
        grades.Add(grade);
        return "Success!";
      }
      else
      {
        return "Invalid Grade";
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;
      foreach (var grade in grades)
      {
        result.Low = Math.Min(grade, result.Low);
        result.High = Math.Max(grade, result.High);
        result.Average += grade;
      }
      result.Average /= grades.Count;

      return result;
    }
    private List<double> grades;
    public string Name;
  }


}