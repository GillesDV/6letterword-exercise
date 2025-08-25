using _6letterword.Business.Models;

namespace _6letterword.Business.UnitTests.TDD {
  public class StringCombinationFinderTddUnitTests {

    private readonly StringCombinationFinderTdd _stringCombinationFinder;

    [Fact]
    public void Given_SimpleValid2WordInput_When_FindCombinations_ReturnsValidCombinations() {
      // Arrange
      var partialWords = new List<string> {
        "abc", "def",
        "foo", "bar", "imtoolongignoreme"
      };

      var validCombinations = new List<Combination> {
        new Combination("abcdef"), new Combination("foobar"), new Combination("yyyyyy")
      };

      // Act
      var wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);

      // Assert
      Assert.Equal(2, wordEntities.Count);

      Assert.Contains(wordEntities, item => item.CompleteWord == "abcdef" &&
        item.PartsOfCompleteWord.Contains("abc") &&
        item.PartsOfCompleteWord.Contains("def"));
      Assert.Contains(wordEntities, item => item.CompleteWord == "foobar" &&
        item.PartsOfCompleteWord.Contains("foo") &&
        item.PartsOfCompleteWord.Contains("bar"));

    }

    [Fact]
    public void Given_SimpleValid6WordInput_When_FindCombinations_ReturnsValidCombinations() {
      // Arrange
      var partialWords = new List<string> {
        "a", "b", "c", "e", "f", "d"
      };

      var validCombinations = new List<Combination> {
        new Combination("abcdef")
      };

      // Act
      var wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);

      // Assert
      Assert.Single(wordEntities);
      Assert.Contains(wordEntities, item => item.CompleteWord == "abcdef" &&
        item.PartsOfCompleteWord.Contains("a") &&
        item.PartsOfCompleteWord.Contains("b") &&
        item.PartsOfCompleteWord.Contains("c") &&
        item.PartsOfCompleteWord.Contains("d") &&
        item.PartsOfCompleteWord.Contains("e") &&
        item.PartsOfCompleteWord.Contains("f"));

    }

    [Fact]
    public void Given_IncompleteInput_When_FindCombinations_ReturnsValidCombinations() {
      // Arrange
      var partialWords = new List<string> {
        "abc", "f"
      };

      var validCombinations = new List<Combination> {
        new Combination("abcdef"),
      };

      // Act
      var wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);

      // Assert
      Assert.Empty(wordEntities);
    }

    [Fact]
    public void Given_InvalidInput_When_FindCombinations_ReturnsEmptyList() {
      // Arrange
      var partialWords = new List<string> {
        "a", "b", "c", "d", "e", "f",
        "fo", "o", "bar", "imtoolongignoreme"
      };
      var validCombinations = new List<Combination>();

      // Act
      var wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);

      // Assert
      Assert.Empty(wordEntities);
    }


    public StringCombinationFinderTddUnitTests() {
      _stringCombinationFinder = new StringCombinationFinderTdd();
    }
  }
}
