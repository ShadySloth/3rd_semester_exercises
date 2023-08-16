/*
Task: Implement all the methods. All of them can be completed using LINQ.
Basic conditionals and loops can also do the job.
Success criteria: All tests passing.
Learing objective: Being able to write medium difficulty algorithms.
Additional help: I put guided solutions in the ./Solutions directory.
*/

using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace gettingstarted;


public class MediumLinqExercises : IMediumLinqExercises
{
    public int CountVowels(string text)
    {
        var q = from i in text where "aeiou".Contains(i) select i;
        return q.Count();
    }

    public List<int> GetNumbersInRange(List<int> numbers, int start, int end)
    {
        var q = from i in numbers 
            where (numbers.IndexOf(i) >= start && numbers.IndexOf(i) <= end) 
            select i;
        return q.ToList();
    }

    public int GetSumOfSquares(List<int> numbers)
    {
        var q = from i in numbers select i * i;
        return q.Sum();
    }

    public List<string> GetWordsLongerThanN(List<string> words, int n)
    {
        var q = from i in words where i.Length > n select i;
        return q.ToList();
    }

    public List<string> GetDistinctWords(string text)
    {
        return text.Split(separator:" ").Distinct().ToList();
    }

    public bool AnyWordStartsWithA(List<string> words)
    {
        var q = from i in words select i.StartsWith("a");
        return q.Any();
    }

    public List<int> GetNumbersDivisibleBy3Or5(List<int> numbers)
    {
        var q = from i in numbers where i % 3 == 0 || i % 5 == 0 select i;
        return q.ToList();
    }

    public List<string> GetWordsSortedByLength(string text)
    {
        var q = text.Split(" ").ToList();
        return q.OrderBy(q => q.Length).ToList();
    }

    public List<int> GetSquaredNumbersSorted(List<int> numbers)
    {
        var q = from i in numbers select i * i;
        return q.OrderBy(q => int.Max(q,q)).ToList();
    }

    public int CountUniqueCharacters(string text)
    {
        return text.Distinct().Count();
    }

    public Dictionary<string, int> GetWordFrequencies(string text)
    {
        var dict = new Dictionary<string, int>();
        var words = text.Split(" ").ToList();
        var uniques = GetDistinctWords(text);
        foreach (var word in uniques)
        {
            var q = from w in words where w.Equals(word) select w;
            dict.Add(word, q.Count());
        }

        return dict;
    }

    public string GetLongestString(List<string> strings)
    {
        return strings.OrderBy(s => s.Length).Reverse().ToList()[0];
    }
}

public interface IMediumLinqExercises
{
    int CountVowels(string text);
    List<int> GetNumbersInRange(List<int> numbers, int startIndex, int endIndex);

    // Return the sum of squares of all numbers in the list
    int GetSumOfSquares(List<int> numbers);

    // Return a list of all words longer than n characters
    List<string> GetWordsLongerThanN(List<string> words, int n);

    // Return a list of all distinct words in a string (split by spaces)
    List<string> GetDistinctWords(string text);

    // Return true if any word in a list starts with the letter 'a', false otherwise
    bool AnyWordStartsWithA(List<string> words);

    // Return a list of all numbers in the list that are divisible by 3 or 5
    List<int> GetNumbersDivisibleBy3Or5(List<int> numbers);

    // Return a sorted list of all words in a string, sorted by length (split by spaces)
    List<string> GetWordsSortedByLength(string text);

    // Return a list of all numbers in the list squared, sorted in ascending order
    List<int> GetSquaredNumbersSorted(List<int> numbers);

    // Return the count of all unique characters in a string
    int CountUniqueCharacters(string text);

    // Return a dictionary of all unique words in a string with their frequencies (split by spaces)
    Dictionary<string, int> GetWordFrequencies(string text);

    // Return the longest string in a list of strings
    string GetLongestString(List<string> strings);
}

[TestFixture]
public class MediumLinqExercisesTests
{
    private IMediumLinqExercises _exercises;

    [SetUp]
    public void Setup()
    {
        _exercises = new MediumLinqExercises();
    }

    [Test]
    public void TestCountVowels()
    {
        string text = "Hello, World!";
        int result = _exercises.CountVowels(text);
        Assert.AreEqual(3, result);
    }

    [Test]
    public void TestGetNumbersInRange_IncludesNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Act
        var result = _exercises.GetNumbersInRange(numbers, 2, 5);

        // Assert
        Assert.That(result, Is.EquivalentTo(new List<int> { 3, 4, 5, 6 }));
    }

    [Test]
    public void TestGetNumbersInRange_DoesNotIncludeNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Act
        var result = _exercises.GetNumbersInRange(numbers, 10, 15);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void TestGetNumbersInRange_IncludesAllNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Act
        var result = _exercises.GetNumbersInRange(numbers, 0, 9);

        // Assert
        Assert.That(result, Is.EquivalentTo(numbers));
    }

    [Test]
    public void TestGetNumbersInRange_EmptyInputList()
    {
        // Arrange
        var numbers = new List<int>();

        // Act
        var result = _exercises.GetNumbersInRange(numbers, 0, 9);

        // Assert
        Assert.That(result, Is.Empty);
    }


    [Test]
    public void TestGetSumOfSquares()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3 };

        // Act
        int result = _exercises.GetSumOfSquares(numbers);

        // Assert
        Assert.AreEqual(14, result);
    }

    [Test]
    public void TestGetWordsLongerThanN()
    {
        // Arrange
        var words = new List<string> { "apple", "banana", "cherry", "kiwi", "lime" };

        // Act
        var result = _exercises.GetWordsLongerThanN(words, 4);

        // Assert
        Assert.That(result, Is.EquivalentTo(new List<string> { "apple", "banana", "cherry" }));
    }

    [Test]
    public void TestGetDistinctWords()
    {
        // Arrange
        string text = "apple apple banana cherry banana";

        // Act
        var result = _exercises.GetDistinctWords(text);

        // Assert
        Assert.That(result, Is.EquivalentTo(new List<string> { "apple", "banana", "cherry" }));
    }

    [Test]
    public void TestAnyWordStartsWithA()
    {
        // Arrange
        var words = new List<string> { "apple", "banana", "cherry" };

        // Act
        bool result = _exercises.AnyWordStartsWithA(words);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void TestGetNumberDivisibleBy3Or5()
    {
        var expected = new int[] { 3, 15, 27, 25 };
        var result = _exercises.GetNumbersDivisibleBy3Or5(new List<int>() { 1, 3, 15, -26, 27, 25 });
        Assert.AreEqual(result, expected);
    }

    [Test]
    public void TestGetWordsSortedByLength()
    {
        var expected = new List<string>() { "a", "asd", "bbbbb" };
        var actual = _exercises.GetWordsSortedByLength("a asd bbbbb");
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void TestGetSquaredNumbersSorted()
    {
        // Arrange
        var numbers = new List<int> { 5, 2, 1, 4, 3 };

        // Act
        var result = _exercises.GetSquaredNumbersSorted(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(new List<int> { 1, 4, 9, 16, 25 }));
    }

    [Test]
    public void TestCountUniqueCharacters()
    {
        // Arrange
        string text = "apple";

        // Act
        int result = _exercises.CountUniqueCharacters(text);

        // Assert
        Assert.AreEqual(4, result);
    }

    [Test]
    public void TestGetWordFrequencies()
    {
        // Arrange
        string text = "apple apple banana";

        // Act
        var result = _exercises.GetWordFrequencies(text);

        // Assert
        Assert.That(result, Is.EquivalentTo(new Dictionary<string, int> { { "apple", 2 }, { "banana", 1 } }));
    }

    [Test]
    public void TestGetLongestString()
    {
        // Arrange
        var strings = new List<string> { "apples", "banana", "cherries" };

        // Act
        string result = _exercises.GetLongestString(strings);

        // Assert
        Assert.AreEqual("cherries", result);
    }
}