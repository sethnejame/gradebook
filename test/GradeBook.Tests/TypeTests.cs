using System;
using Xunit;

namespace GradeBook.Tests
{ 
  public class TypeTests
  {
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

    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CSharpIsPassedByVal()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "Fight Club");

      Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name);
      book.Name = name;
    }

    [Fact]
    public void CanChangeBookName()
    {
      var book = GetBook("Book1");
      SetName(book, "Awesome Book!");

      Assert.Equal("Awesome Book!", book.Name);

    }

    private void SetName(Book book, string name)
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

    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
