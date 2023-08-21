
using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class DeleteBookByIdExercise
{
    
    /// <summary>
    /// Delete the book by ID and indicate towards the caller whether or not the deletion was successful with a boolean
    /// (true = successful deletion)
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool DeleteBookById(int bookId)
    {
        var sql = $@"DELETE FROM library.books WHERE book_id = @bookId;";
        
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new {bookId}) == 1;
        }
    }
    
    [Test]
    public void TestDeleteBookById()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var sql =
            "insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(sql, book);
        }

        bool actual;
        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
             actual =DeleteBookByIdSolution(book.BookId);
        }
        else
        {
            actual = DeleteBookById(book.BookId);
        }

        //Assert
        using (var conn = Helper.DataSource.OpenConnection())
        {
            var doesNotExist = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM library.books WHERE book_id = @bookId;",
                new { bookId = book.BookId }) == 0;
            (doesNotExist && actual).Should().Be(true);
        }
    }
    
    public bool DeleteBookByIdSolution(int bookId)
    {
        var sql = $@"
DELETE FROM library.books WHERE book_id = @bookId;
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new { bookId }) == 1;
        }
    }


}
