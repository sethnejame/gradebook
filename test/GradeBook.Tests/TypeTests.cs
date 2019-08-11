using System;
using Xunit;

namespace GradeBook.Tests
{

  public delegate string WriteLogDelegate(string logMessage);
  public class TypeTests
  {
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
      WriteLogDelegate log = ReturnMessage;

      log += new WriteLogDelegate(ReturnMessage);
      log += new WriteLogDelegate(IncrementCount);

      var result = log("whatever");
      Assert.Equal(3, count);
    }

    string IncrementCount(string message)
    {
      count++;
      return message;
    }
    string ReturnMessage(string message)
    {
      count++;
      return message;
    }

    [Fact]
    public void ValTypesPassByRef()
    {
      var x = GetInt();
      SetInt(ref x);

      Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
      x = 42;
    }

    [Fact]
    public void ValTypesPassByVal()
    {
      var x = GetInt();
      SetInt(x);

      Assert.Equal(3, x);
    }

    private void SetInt(int x)
    {
      x = 42;
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "Fight Club");

      Assert.Equal("Fight Club", book1.Name);
    }

    private void GetBookSetName(ref InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
    }

    [Fact]
    public void CSharpIsPassedByVal()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "Fight Club");

      Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
      book.Name = name;
    }

    [Fact]
    public void CanChangeBookName()
    {
      var book = GetBook("Book1");
      SetName(book, "Awesome Book!");

      Assert.Equal("Awesome Book!", book.Name);

    }

    private void SetName(InMemoryBook book, string name)
    {
      book.Name = name;
    }

    [Fact]
    public void GetBookRetDiffObjects()
    {
      var book1 = GetBook("Book1");
      var book2 = GetBook("Book2");

      Assert.Equal("Book1", book1.Name);
      Assert.Equal("Book2", book2.Name);
    }

    [Fact]
    public void TwoVarsCanRefSameObject()
    {
      var book1 = GetBook("Book1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
      string name = "Seth";
      var upper = MakeUppercase(name);

      Assert.Equal("Seth", name);
      Assert.Equal("SETH", upper);
    }

    private string MakeUppercase(string parameter)
    {
      return parameter.ToUpper();
    }

    InMemoryBook GetBook(string name)
    {
      return new InMemoryBook(name);
    }
  }
}
