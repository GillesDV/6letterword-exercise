using _6letterword.Business.Models;

namespace _6letterword.Business.TDD {
  public class StringCombinationFinderTdd {

    // Verantwoordelijkheden: 
    // * zoek achter combinaties
    // * hoe weet je dat een combinatie compleet is? -> opsplitsen 

    public List<MatchResult> FindCombinations(List<Combination> validCombinations, List<string> partialWords) {
      var results = new List<MatchResult>();

      foreach (var validWord in validCombinations) 
        foreach (var firstPartialWord in partialWords) 
          foreach (var secondPartialWord in partialWords) { // bar   <->     r
            if (firstPartialWord.Equals(secondPartialWord))               continue;

            if (validWord.IsFullyComposedOf(firstPartialWord, secondPartialWord) )            
              results.Add(new MatchResult {
                CompleteWord = validWord.Value,
                PartsOfCompleteWord = new List<string> { firstPartialWord, secondPartialWord }
              });

          }

      return results;
    }

    public bool IsCombinationComplete(string combination, List<string> validCombinations) {
      return validCombinations.Contains(combination);
    }
}