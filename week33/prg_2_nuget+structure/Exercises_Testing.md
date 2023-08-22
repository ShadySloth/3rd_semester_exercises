
### Before exercises: Install dependencies

Make a new .csproj for testing. Depending on how you run your tests, you will need to install these dependencies to get started with NUnit and Fluent Assertions:

- Microsoft.NET.Test.Sdk
- NUnit3TestAdapter
- NUnit
- FluentAssertions

## First test

**Task:** Make a test with NUnit and assert that 2 + 2 = 4. Run the test either using the CLI or using your IDE.

**Success criteria**: A test should run and pass.

**Learning objective**: You must know how to "mark" a method as a test, make a basic assertion and run the test using any test runner.

## Triple A pattern

**Task:** Make a test where you call some method from a object of some type. You must divide it into 3 sections:
1. Arrange: Instantiate the object.
2. Act: Call the method.
3. Assert: Make some assertion about the "act"

**Success criteria:** Your test method should now have 3 clearly readable segments

**Learning objective**: You must know how to use basic testing conventions in order to make your tests more readable and maintainable.

## Exploring Fluent Assertions

**Task**: Make tests assertions by chaining an assertion onto an "actual" object. The assertions have very good naming. Try and find assertions, that let you write the following tests:

- Test that two objects have the same values
- Test that two objects have the same reference
- Test that the number 42 is not 24
- Test that a string starts with some value
- Test that every number in an array is above 42
- Test that an exception is thrown by the called method

**Success criteria:** When should be able to run your tests and get the expected test outcome using the assertions.

**Learning objective:** You must know how to use some built-in assertions from the Fluent Assertions library by "chaining" these onto the "act"-ual object.

## Adding "because"

**Task**: Add a "because" into an assertion (typically second parameter in an assertion). Make the test fail, and see the "because" message in the test runner. Is it clear to you why your tests failed?

**Success criteria:** It should be clear to you as a reader why the tests failed.

**Learning objective**: You must know how to write expressive tests by adding a "because".

## Get creative

**Task:** Write your own algorithms and test these with NUnit + Fluent Assertions. Here's some inspiration to get started:

- Sorting Algorithm.
- Leap Year Checker.
- Convert decimal to binary.