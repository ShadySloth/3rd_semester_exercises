using Bogus;
using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

/// <summary>
/// Description: Please read beforehand.
/// I supplied a database schema as a SQL script
/// + some classes which correspond with query models.
/// Each test rebuilds and seeds the database, so you just have
/// to think about implementing repository methods.
///
/// Remember to add environment variable to the test running config
/// </summary>
public class InfrastructureExercises
{
    //The data source can be accessed: Helper.Datasource (public + static)

    public IEnumerable<Book> GetAllBooks()
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

    [Test]
    public void GetAllBooksTest()
    {
        //ARRANGE
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

        //ACT
        var actual = GetAllBooks();

        // Assert
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, expected));
    }

    public Book InsertAndReturnBook(string title, string publisher, string coverImgUrl)
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


    [Test]
    public void InsertAndReturnBookTest()
    {
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        //ACT
        var actual = InsertAndReturnBook(book.Title, book.Publisher, book.CoverImgUrl);

        //ASSERT
        actual.Should().BeEquivalentTo(book, Helper.MyBecause(actual, book));
    }

    //Update book by ID
    public Book UpdateBookById(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl)
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

        //ACT
        var actual = UpdateBookById(book.BookId, "NEW TITLE", book.Publisher, book.CoverImgUrl);

        //ASSERT
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, book));
    }


    //Does book with title exist true
    public bool DeleteBookById(int bookId)
    {
        var sql = $@"
DELETE FROM library.books WHERE book_id = @bookId;
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new { bookId }) == 1;
        }
    }

    [Test]
    public void TestDeleteBookByIdReturnFalseIfNoBookWasDeleted()
    {
        //Act
        var actual = DeleteBookById(12345);

        //Assert
        actual.Should().Be(false);
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

        //Act
        var actual = DeleteBookById(book.BookId);

        //Assert
        using (var conn = Helper.DataSource.OpenConnection())
        {
            var doesNotExist = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM library.books WHERE book_id = @bookId;",
                new { bookId = book.BookId }) == 0;
            (doesNotExist && actual).Should().Be(true);
        }
    }


    //Evt lav "fejle" tests, men infra bør ikke validate
    

    //Join book with author names

    //Select all books on reading list for user with ID 1

    //Get top 5 books by most added to reading list

    //
}

public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public string? CoverImgUrl { get; set; }
}