using _6letterword.Business.Models;

namespace _6letterword.Business.UnitTests {
  public class StringCombinationFinderTdd { // TODO add interface

    // Verantwoordelijkheden: 
    // * zoek achter combinaties
    // * hoe weet je dat een combinatie compleet is? -> opsplitsen 

    public List<MatchResult> FindCombinations(List<Combination> validCombinations, List<string> partialWords) {
      var results = new List<MatchResult>();

      foreach (var validWord in validCombinations) { // foobar

        foreach (var firstPartialWord in partialWords) { // foo

          foreach (var secondPartialWord in partialWords) { // bar   <->     r
            if (firstPartialWord.Equals(secondPartialWord, StringComparison.InvariantCultureIgnoreCase)) {
              continue;
            }

            if (validWord.IsFullyComposedOf(firstPartialWord, secondPartialWord)) {

              results.Add(new MatchResult {
                CompleteWord = validWord.Value,
                PartsOfCompleteWord = [firstPartialWord, secondPartialWord]
              });

            }

          }

        }
      }

      return results;
    }

  }
}