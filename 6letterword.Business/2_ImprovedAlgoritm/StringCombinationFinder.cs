using _6letterword.Business.Interfaces;
using _6letterword.Business.Models;

namespace _6letterword.Business {
  public class StringCombinationFinder : IStringCombinationFinder {

    //TODO can change me into a setting, so you could change it at-runtime
    private const int MAX_OUTPUT_LENGTH = 6;

    public List<MatchResult> FindCombinations(List<string> allInputStrings) {
      var filteredAllInputStrings = new HashSet<string>(
          allInputStrings.Where(s => !string.IsNullOrEmpty(s))
      );

      var results = new List<MatchResult>();

      var completeWordsToFind = allInputStrings
          .Where(s => s.Length == MAX_OUTPUT_LENGTH)
          .ToHashSet();

      foreach (var completeWord in completeWordsToFind) {
        var combinations = new List<List<string>>();
        Backtrack(completeWord, 0, new List<string>(), filteredAllInputStrings, combinations);

        foreach (var combo in combinations) {
          results.Add(new MatchResult {
            CompleteWord = completeWord,
            PartsOfCompleteWord = combo
          });
        }
      }

      return results;
    }

    private void Backtrack(
        string word,
        int index,
        List<string> current,
        HashSet<string> inputSet,
        List<List<string>> results) {
      // Base case → successfully reconstructed the whole word
      if (index == word.Length) {
        results.Add(new List<string>(current));
        return;
      }

      // Try all possible substrings starting from this index
      for (int len = 1; len <= word.Length - index; len++) {
        var sub = word.Substring(index, len);

        if (inputSet.Contains(sub) && sub != word) // skip the full word itself
        {
          current.Add(sub);
          Backtrack(word, index + len, current, inputSet, results);
          current.RemoveAt(current.Count - 1); // backtrack
        }
      }
    }
  }
}