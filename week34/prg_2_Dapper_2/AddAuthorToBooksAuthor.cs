using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

namespace gettingstarted.week34.prg_2_Dapper_2;

public class AddAuthorToBooksAuthor
{
    public bool AddAuthorToBooksAuthorExcercise(int bookId, int authorId)
    {
        var sql = $@"INSERT INTO";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new {bookId, authorId}) == 1;
        }
    }

    [Test]
    public void TestAddAuthorToBooksAuthor()
    {
        //Arrange
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var author = Helper.MakeRandomAuthorWithId(1);
        var sql1 = $@"insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        var sql2 = $@"insert into library.authors (name, birthday, nationality) VALUES (@name, @birthday, @nationality)";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(sql1, book);
            conn.Execute(sql2, author);
        }

        bool actual;
        //Act
        actual = AddAuthorToBooksAuthorExcercise(book.BookId, author.AuthorId);

        //Assert
        using (var conn = Helper.DataSource.OpenConnection())
        {
            var doesNotExist = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM library.author_wrote_book_items WHERE book_id = @bookId",
                new {bookId = book.BookId}) == 0;
            (doesNotExist && actual).Should().Be(true);
        }
    }
}