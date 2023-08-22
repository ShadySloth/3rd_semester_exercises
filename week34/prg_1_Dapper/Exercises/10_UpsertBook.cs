using Dapper;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

public class UpsertBookExercise
{
    public Book UpsertAndReturnBook(int bookId, string title, string publisher, string coverImgUrl)
    {
        var sql = $@"INSERT INTO library.books (book_id, title, publisher, cover_img_url)
                    VALUES (@bookId, @title, @publisher, @coverImgUrl)
                    ON CONFLICT (book_id)
                    DO UPDATE SET title = @title, publisher = @publisher, cover_img_url = @coverImgUrl
                    RETURNING book_id as {nameof(Book.BookId)},
                        title as {nameof(Book.Title)},
                        publisher as {nameof(Book.Publisher)},
                        cover_img_url as {nameof(Book.CoverImgUrl)};";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { bookId, title, publisher, coverImgUrl });
        }
    }

    [Test]
    public void UpsertAndReturnBookTest()
    {
        Helper.TriggerRebuild();
        Book book = Helper.MakeRandomBookWithId(1);

        object actualInsert;
        object actualUpdate;

        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
            actualInsert = UpsertAndReturnBookSolution(book.BookId, book.Title, book.Publisher, book.CoverImgUrl);
            actualUpdate = UpsertAndReturnBookSolution(book.BookId, book.Title, book.Publisher, book.CoverImgUrl);
        }
        else
        {
            actualInsert = UpsertAndReturnBook(book.BookId, book.Title, book.Publisher, book.CoverImgUrl);
            actualUpdate = UpsertAndReturnBook(book.BookId, book.Title, book.Publisher, book.CoverImgUrl);
        }

        using (new AssertionScope())
        {
            actualInsert.Should().BeEquivalentTo(book);
            actualUpdate.Should().BeEquivalentTo(book);
        }
    }

    public Book UpsertAndReturnBookSolution(int bookId, string title, string publisher, string coverImgUrl)
    {
        var sql = $@"

INSERT INTO library.books (book_id, title, publisher, cover_img_url) 
VALUES (@bookId, @title, @publisher, @coverImgUrl)
ON CONFLICT (book_id)
DO UPDATE SET 
              book_id = @bookId,
              title = @title,
              publisher = @publisher,
              cover_img_url = @coverImgUrl
RETURNING book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)};
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { bookId, title, publisher, coverImgUrl });
        }
    }
}