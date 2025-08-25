using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6letterword.Business.Models;

namespace _6letterword.Business.UnitTests {
  public class StringCombinationFinderTddUnitTests {

    private readonly StringCombinationFinderTdd _stringCombinationFinder;

    [Fact]
    public void Given_SimpleValid2WordInput_When_FindCombinations_ReturnsValidCombinations() {
      // Arrange
      var partialWords = new List<string> {
        "abc", "def",
        //"ab", "cd", "ef",
        "foo", "bar", "imtoolongignoreme"
      };

      var validCombinations = new List<string> {
        "abcdef", "foobar", "yyyyyy"
      };

      // Act
      List<MatchResult> wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);
      
      // Assert
      Assert.Equal(2, wordEntities.Count);

      Assert.Collection(wordEntities,
          we => {
            Assert.Equal("abcdef", we.CompleteWord);
            Assert.All(new[] { "abc", "def", },
          part => Assert.Contains(part, we.PartsOfCompleteWord));
          },
          we => {
            Assert.Equal("foobar", we.CompleteWord);
            Assert.All(new[] { "foo", "bar" },
          part => Assert.Contains(part, we.PartsOfCompleteWord));
          }
      );
    }

    [Fact]
    public void Given_IncompleteInput_When_FindCombinations_ReturnsValidCombinations() {
      // Arrange
      var partialWords = new List<string> {
        "abc", "f"
      };

      var validCombinations = new List<string> {
        "abcdef",
      };

      // Act
      List<MatchResult> wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);

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
      var validCombinations = new List<string>();

      // Act
      List<MatchResult> wordEntities = _stringCombinationFinder.FindCombinations(validCombinations, partialWords);
      
      // Assert
      Assert.Empty(wordEntities);
    }


    public StringCombinationFinderTddUnitTests() {
      _stringCombinationFinder = new StringCombinationFinderTdd();
    }
  }
}
