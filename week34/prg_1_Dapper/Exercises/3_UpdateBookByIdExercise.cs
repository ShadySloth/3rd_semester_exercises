using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class UpdateBookByIdExercise
{
    
    /// <summary>
    /// When you update the book, return the updated book with all its values to the caller
    /// </summary>
    /// <param name="bookIdToUpdate"></param>
    /// <param name="newTitle"></param>
    /// <param name="newPublisher"></param>
    /// <param name="newCoverImgUrl"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Book UpdateBookById(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl)
    {
        var sql = $@"UPDATE library.books SET 
                        title = @newTitle, 
                        publisher = @newPublisher, 
                        cover_img_url = @newCoverImgUrl 
                        WHERE book_id = @bookIdToUpdate
                        RETURNING book_id as {nameof(Book.BookId)},
                        title as {nameof(Book.Title)},
                        publisher as {nameof(Book.Publisher)},
                        cover_img_url as {nameof(Book.CoverImgUrl)};";
        
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new {bookIdToUpdate, newTitle, newPublisher, newCoverImgUrl});
        }
    }
    
    [Test]
    public void TestUpdateBookById()
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

        book.Title = "NEW TITLE";
        var expected = book;

        object actual;
        
        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
             actual = UpdateBookByIdSolution(book.BookId, "NEW TITLE", book.Publisher, book.CoverImgUrl);
        }
        else
        {
            actual = UpdateBookById(book.BookId, "NEW TITLE", book.Publisher, book.CoverImgUrl);

        }

        //ASSERT
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, book));
    }
    
    public Book UpdateBookByIdSolution(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl)
    {
        var sql = @$"
UPDATE library.books SET title = @newTitle, publisher = @newPublisher, cover_img_url = @newCoverImgUrl WHERE book_id = @bookIdToUpdate
RETURNING 
    book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)};
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { bookIdToUpdate, newTitle, newPublisher, newCoverImgUrl });
        }
    }
}