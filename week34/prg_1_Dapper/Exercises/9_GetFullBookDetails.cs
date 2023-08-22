using Dapper;
using FluentAssertions;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

public class GetFullBookDetailsExercise
{
    public FullBookDetails GetFullBookDetails(int bookid)
    {
        var sql = $@"SELECT books.book_id AS {nameof(Book.BookId)},
                            title AS {nameof(Book.Title)},
                            publisher AS {nameof(Book.Publisher)},
                            cover_img_url AS {nameof(Book.CoverImgUrl)},
                            array_agg(library.authors.name) AS {nameof(BookWithAuthors.Authors)}
                    FROM library.books
                    JOIN library.author_wrote_book_items AS junction ON books.book_id = junction.book_id
                    JOIN library.authors ON junction.author_id = authors.author_id
                    WHERE books.book_id = @bookid
                    GROUP BY books.book_id, books.title;";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<FullBookDetails>(sql, new {bookid});
        }
    }

    [Test]
    public void GetFullBookDetailsTest()
    {
        Helper.TriggerRebuild();

        var mockBook = Helper.MakeRandomBookWithId(1);
        var mockAuthor1 = Helper.MakeRandomAuthorWithId(1);
        var mockAuthor2 = Helper.MakeRandomAuthorWithId(2);

        var insertBookSql =
            "INSERT INTO library.books (book_id, title, publisher, cover_img_url) VALUES (@bookId, @title, @publisher, @coverImgUrl);";
        var insertAuthorSql =
            "INSERT INTO library.authors (author_id, name, birthday, nationality) VALUES (@authorId, @name, date('2020-10-10'), @nationality);";
        var insertJunction =
            "INSERT INTO library.author_wrote_book_items (book_id, author_id) VALUES (@bookId, @authorId);";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(insertBookSql, mockBook);
            conn.Execute(insertAuthorSql, mockAuthor1);
            conn.Execute(insertAuthorSql, mockAuthor2);
            conn.Execute(insertJunction, new { bookId = 1, authorId = 1 });
            conn.Execute(insertJunction, new { bookId = 1, authorId = 2 });
        }

        var expected = new FullBookDetails()
        {
            Title = mockBook.Title,
            BookId = mockBook.BookId,
            Authors = new[] { mockAuthor1.Name, mockAuthor2.Name },
            Publisher = mockBook.Publisher,
            CoverImgUrl = mockBook.CoverImgUrl
        };

        object actual;

        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
            actual = GetFullBookDetailsSolution(1);
        }
        else
        {
            actual = GetFullBookDetails(1);
        }

        actual.Should().BeEquivalentTo(expected);
    }


    public FullBookDetails GetFullBookDetailsSolution(int bookid)
    {
        var sql = $@"
SELECT
    library.books.book_id as {nameof(Book.BookId)}, 
    library.books.title as {nameof(Book.Title)}, 
    library.books.publisher as {nameof(Book.Publisher)}, 
    library.books.cover_img_url as {nameof(Book.CoverImgUrl)},
    array_agg(library.authors.name) as {nameof(BookWithAuthors.Authors)}
FROM library.books
join library.author_wrote_book_items awbi on books.book_id = awbi.book_id
join library.authors on authors.author_id = awbi.author_id
WHERE library.books.book_id = @bookId
GROUP BY books.book_id, title, publisher, cover_img_url;

";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<FullBookDetails>(sql, new { bookid });
        }
    }
}