namespace _6letterword.Business.UnitTests;

public class StringCombinationFinderUnitTests
{
    private readonly StringCombinationFinderRecursive stringCombinationFinder;

    [Theory]
    [MemberData(nameof(Given_ValidInput_When_FindCombinations_Then_ReturnsExpectedResult_MemberData))]
    public void Given_ValidInput_When_FindCombinations_Then_ReturnsExpectedResult(
        List<string> inputWords, string expectedResult)
    {
        // Arrange

        // Act
        var result = stringCombinationFinder.FindCombinations(inputWords);

        // Assert
        Assert.Equivalent( expectedResult , result[0]);
    }


    public static IEnumerable<object[]> Given_ValidInput_When_FindCombinations_Then_ReturnsExpectedResult_MemberData =>
        new List<object[]>
        {
            new object[]
            {
                new List<string> { "foobar", "fo", "o", "bar", "imtoolongignoreme" },
                "fo + o + bar = foobar"
            },

            new object[]
            {
                new List<string> { "a", "b", "c", "d", "e", "f", "abcdef" },
                "a + b + c + d + e + f = abcdef"
            }
        };

    public StringCombinationFinderUnitTests()
    {
        stringCombinationFinder = new StringCombinationFinderRecursive();
    }
}
