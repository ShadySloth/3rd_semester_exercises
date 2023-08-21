using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class InsertAndReturnBookExercise
{
    
    public Book InsertAndReturnBook(string title, string publisher, string coverImgUrl)
    {
        var sql = $@"INSERT INTO library.books (title, publisher, cover_img_url) 
                        VALUES (@title, @publisher, @coverImgUrl)
                        RETURNING book_id as {nameof(Book.BookId)},
                        title as {nameof(Book.Title)},
                        publisher as {nameof(Book.Publisher)},
                        cover_img_url as {nameof(Book.CoverImgUrl)};";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { title, publisher, coverImgUrl });
        }
    }
    
    

    [Test]
    public void InsertAndReturnBookTest()
    {
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        //ACT
        
        object actual;
        
        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
             actual = InsertAndReturnBookSolution(book.Title, book.Publisher, book.CoverImgUrl);
        }
        else
        {
            actual = InsertAndReturnBook(book.Title, book.Publisher, book.CoverImgUrl);

        }

        //ASSERT
        actual.Should().BeEquivalentTo(book, Helper.MyBecause(actual, book));
    }
    
    #region solution
    public Book InsertAndReturnBookSolution(string title, string publisher, string coverImgUrl)
    {
        var sql =
            $@"INSERT INTO library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl) 
                                                            RETURNING     book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)};";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { title, publisher, coverImgUrl });
        }
    }
    
    #endregion


}