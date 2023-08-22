using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class AddBookToUsersReadingListExercise
{

    /// <summary>
    /// Add a book to the reading list by adding a row to the junction table (bookId + userId)
    /// return true in case of a successful insert
    /// </summary>
    /// <param name="bookId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool AddBookToUsersReadingList(int bookId, int userId)
    {
        var sql = $@"INSERT INTO library.reading_list_items (user_id, book_id) VALUES (@userId, @bookId);";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new { userId, bookId }) == 1;
        }
    }
    
    
    [Test]
    public void AddBookToUsersReadingListTest()
    {
        Helper.TriggerRebuild();
        EndUser user = Helper.MakeRandomUserWithId(1);
        var book = Helper.MakeRandomBookWithId(1);

        var insertUser =
            "INSERT INTO library.end_users (email, status, password_hash, salt, role, profile_img_url) VALUES ( @email, @status, @passwordHash, @salt, @role, @profileImgUrl);";
        var insertBook =
            "INSERT INTO library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(insertUser, user);
            conn.Execute(insertBook, book);
        }

        bool actual;

        //Change the mode by changing Helper.Mode value in Helper.cs, don't modify the test
        if (Helper.Mode == "Guided Solution")
        {
            actual = AddBookToUsersReadingListSolution(book.BookId, user.EndUserId);
        }
        else
        {
            actual = AddBookToUsersReadingList(book.BookId, user.EndUserId);
        }

        using (var conn = Helper.DataSource.OpenConnection())
        {
            var onReadingList =
                conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM library.reading_list_items WHERE book_id = @bookId AND user_id = @userId;",
                    new { userId = user.EndUserId, bookId = book.BookId }) == 1;
            (actual && onReadingList).Should().BeTrue();
        }
    }

    public bool AddBookToUsersReadingListSolution(int bookId, int userId)
    {
        var sql = $@"
     INSERT INTO library.reading_list_items (book_id, user_id) VALUES (@bookId, @userId);
     ";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new { bookId, userId }) == 1;
        }
    }
}