/*
Task: Implement all the methods. All of them can be completed using LINQ.
Basic conditionals and loops can also do the job.
Success criteria: All tests passing.
Learing objective: Being able to write easy algorithms.
Additional help: I put guided solutions in the ./Solutions directory.
*/

using Castle.Components.DictionaryAdapter.Xml;
using NUnit.Framework;

namespace gettingstarted;

public class EasyLinqExercises : IEasyLinqExercises
{
    // Exercise 1: Return all odd numbers from the given list.
    public List<int> GetAllOddNumbers(List<int> numbers)
    {
        return numbers.FindAll(int.IsOddInteger);
    }

    // Exercise 2: Return the average of all numbers from the given list.
    public double GetAverage(List<int> numbers)
    {
        return numbers.Average();
    }

    // Exercise 3: Return the first 3 numbers from the given list.
    public List<int> GetFirstThreeNumbers(List<int> numbers)
    {
        return numbers.GetRange(0, 3);
    }

    // Exercise 4: Return the last number from the given list.
    public int GetLastNumber(List<int> numbers)
    {
        return numbers.Last();
    }

    // Exercise 5: Return the string "Hello, [name]!" for each name in the given list.
    public List<string> GetHelloMessages(List<string> names)
    {
        return names.ForEach();
    }

    // Exercise 6: Return the number of elements in the given list.
    public int CountElements(List<int> numbers)
    {
        return numbers.Count;
    }

    // Exercise 7: Return a list of numbers multiplied by 2.
    public List<int> GetDoubledNumbers(List<int> numbers)
    {
        return ;
    }

    // Exercise 8: Return a list of strings converted to uppercase.
    public List<string> ConvertToUpper(List<string> words)
    {
        throw new NotImplementedException();
    }

    // Exercise 9: Return true if the given number exists in the list, false otherwise.
    public bool IsNumberInList(List<int> numbers, int number)
    {
        throw new NotImplementedException();
    }

    // Exercise 10: Return a list of distinct numbers from the given list.
    public List<int> GetDistinctNumbers(List<int> numbers)
    {
        throw new NotImplementedException();
    }
}

public interface IEasyLinqExercises
{
    List<int> GetAllOddNumbers(List<int> numbers);
    double GetAverage(List<int> numbers);
    List<int> GetFirstThreeNumbers(List<int> numbers);
    int GetLastNumber(List<int> numbers);
    List<string> GetHelloMessages(List<string> names);
    int CountElements(List<int> numbers);
    List<int> GetDoubledNumbers(List<int> numbers);
    List<string> ConvertToUpper(List<string> words);
    bool IsNumberInList(List<int> numbers, int number);
    List<int> GetDistinctNumbers(List<int> numbers);
}

[TestFixture]
public class LinqExercisesTests
{
    private IEasyLinqExercises _exercises;

    [SetUp]
    public void Setup()
    {
        _exercises = new EasyLinqExercises();
    }

    [Test]
    public void TestGetAllOddNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Act
        var result = _exercises.GetAllOddNumbers(numbers);

        // Assert
        Assert.That(result, Is.EquivalentTo(new List<int> { 1, 3, 5, 7, 9 }));
    }

    [Test]
    public void TestGetAverage()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = _exercises.GetAverage(numbers);

        // Assert
        Assert.AreEqual(3, result, 0.001); // third parameter is a delta that allows for floating point inaccuracies
    }

    // Test for Exercise 2
    [Test]
    public void TestGetAverage2()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var result = _exercises.GetAverage(numbers);
        Assert.AreEqual(3, result);
    }

    // Test for Exercise 3
    [Test]
    public void TestGetFirstThreeNumbers()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var result = _exercises.GetFirstThreeNumbers(numbers);
        Assert.That(result, Is.EquivalentTo(new List<int> { 1, 2, 3 }));
    }

    // Test for Exercise 4
    [Test]
    public void TestGetLastNumber()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var result = _exercises.GetLastNumber(numbers);
        Assert.AreEqual(5, result);
    }

    // Test for Exercise 5
    [Test]
    public void TestGetHelloMessages()
    {
        var names = new List<string> { "Alice", "Bob", "Charlie" };
        var result = _exercises.GetHelloMessages(names);
        Assert.That(result, Is.EquivalentTo(new List<string> { "Hello, Alice", "Hello, Bob", "Hello, Charlie" }));
    }

    // Test for Exercise 6
    [Test]
    public void TestCountElements()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var result = _exercises.CountElements(numbers);
        Assert.AreEqual(5, result);
    }

    // Test for Exercise 7
    [Test]
    public void TestGetDoubledNumbers()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var result = _exercises.GetDoubledNumbers(numbers);
        Assert.That(result, Is.EquivalentTo(new List<int> { 2, 4, 6, 8, 10 }));
    }

    // Test for Exercise 8
    [Test]
    public void TestConvertToUpper()
    {
        var words = new List<string> { "apple", "banana", "cherry" };
        var result = _exercises.ConvertToUpper(words);
        Assert.That(result, Is.EquivalentTo(new List<string> { "APPLE", "BANANA", "CHERRY" }));
    }

    // Test for Exercise 9
    [Test]
    public void TestIsNumberInList()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        Assert.IsTrue(_exercises.IsNumberInList(numbers, 3));
        Assert.IsFalse(_exercises.IsNumberInList(numbers, 6));
    }

    // Test for Exercise 10
    [Test]
    public void TestGetDistinctNumbers()
    {
        var numbers = new List<int> { 1, 1, 2, 2, 3, 3 };
        var result = _exercises.GetDistinctNumbers(numbers);
        Assert.That(result, Is.EquivalentTo(new List<int> { 1, 2, 3 }));
    }
}