using Dapper;
using FluentAssertions;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

[TestFixture]
public class GetAllBooksExercise
{
    public IEnumerable<Book> GetAllBooks()
    {
        var sql = $@"SELECT 
                    book_id as {nameof(Book.BookId)},
                    title as {nameof(Book.Title)},
                    publisher as {nameof(Book.Publisher)},
                    cover_img_url as {nameof(Book.CoverImgUrl)}
                    FROM library.books;";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<Book>(sql);
        }
    }

    [Test]
    public void GetAllBooksTest()
    {
        Helper.TriggerRebuild();
        var expected = new List<Book>();
        for (var i = 1; i < 10; i++)
        {

            var book = Helper.MakeRandomBookWithId(i);
            expected.Add(book);
            //Note if you're reading this: There is a more performant way of making "bulk" inserts rather than loops,
            //but since this is simply 10 inserts, it's "good enough"
            var sql = $@" 
            insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);
            ";
            using (var conn = Helper.DataSource.OpenConnection())
            {
                conn.Execute(sql, book);
            }
        }

        object actual;

        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
            actual = GetAllBooksSolution();
        }
        else
        {
            actual = GetAllBooks();
        }

        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, expected));
    }

    public IEnumerable<Book> GetAllBooksSolution()
    {
        var sql = @$"
    SELECT 
    book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)} 
    FROM library.books;";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<Book>(sql);
        }
    }
}