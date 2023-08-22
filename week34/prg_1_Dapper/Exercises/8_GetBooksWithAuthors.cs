using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class GetBooksWithAuthorsExercise
{
    /// <summary>
    /// Hint: This requires a join between 3 tables.
    /// Another hint: Use the array_agg() to get the author names as an array
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<BookWithAuthors> GetBooksWithAuthors()
    {
        var sql = $@"SELECT books.book_id AS {nameof(BookWithAuthors.BookId)},
                            title AS {nameof(BookWithAuthors.Title)},
                            array_agg(library.authors.name) AS {nameof(BookWithAuthors.Authors)}
                    FROM library.books
                    JOIN library.author_wrote_book_items as junction on books.book_id = junction.book_id
                    JOIN library.authors on junction.author_id = authors.author_id
                    GROUP BY books.book_id, books.title;";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<BookWithAuthors>(sql);
        }
    }

    [Test]
    public void TestGetBooksWithAuthors()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var author = Helper.MakeRandomAuthorWithId(1);
        var author2 = Helper.MakeRandomAuthorWithId(2);

        var bookInsertSql =
            "insert into library.books (book_id, title, publisher, cover_img_url) VALUES (@bookId, @title, @publisher, @coverImgUrl); ";
        var authorInsertSql =
            "insert into library.authors (author_id, name, birthday, nationality) VALUES (@authorId, @name, date('2020-10-10'), @nationality); ";

        var insertions = new List<Tuple<string, object>>()
        {
            new(bookInsertSql, book),
            new(authorInsertSql, author),
            new(authorInsertSql, author2)
        };

        foreach (var tuple in insertions)
        {
            using (var conn = Helper.DataSource.OpenConnection())
            {
                conn.Execute(tuple.Item1, tuple.Item2);
            }
        }

        //Insert junctions
        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(
                "INSERT INTO library.author_wrote_book_items VALUES (1,1); INSERT INTO library.author_wrote_book_items VALUES (1,2);");
        }

        var expected = new List<BookWithAuthors>()
        {
            new()
            {
                Title = book.Title,
                BookId = book.BookId,
                Authors = new[] { author.Name, author2.Name }
            }
        };


        object actual;

        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
            //ACT
            actual = GetBooksWithAuthorsSolution();
        }
        else
        {
            actual = GetBooksWithAuthors();
        }

        //ASSERT
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, expected));
    }

    public IEnumerable<BookWithAuthors> GetBooksWithAuthorsSolution()
    {
        var sql = $@"
SELECT books.book_id as {nameof(BookWithAuthors.BookId)}, 
       title as {nameof(BookWithAuthors.Title)}, 
       array_agg(library.authors.name) as {nameof(BookWithAuthors.Authors)}
FROM library.books 
    JOIN library.author_wrote_book_items as junction on books.book_id = junction.book_id
    JOIN library.authors on junction.author_id = authors.author_id
GROUP BY books.book_id, books.title;";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<BookWithAuthors>(sql);
        }
    }
}