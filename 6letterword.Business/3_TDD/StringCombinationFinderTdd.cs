using System.Collections.Concurrent;
using _6letterword.Business.Models;

namespace _6letterword.Business.UnitTests {
  public class StringCombinationFinderTdd { // TODO add interface

    // Verantwoordelijkheden: 
    // * zoek achter combinaties
    // * hoe weet je dat een combinatie compleet is? -> opsplitsen 

    public List<MatchResult> FindCombinations(List<Combination> validCombinations, List<string> partialWords) {
      var results = new ConcurrentBag<MatchResult>();

      Parallel.ForEach(validCombinations, validWord =>
      {
        // Try splitting the word into 2..N parts
        for (int partCount = 2; partCount <= partialWords.Count; partCount++) {
          foreach (var parts in GetPermutations(partialWords, partCount)) {

            if (validWord.IsFullyComposedOf(parts.ToArray())) {
              results.Add(new MatchResult {
                CompleteWord = validWord.Value,
                PartsOfCompleteWord = parts.ToList()
              });
            }

          }
        }
      });

      return results.ToList();
    }

    /// <summary>
    /// Generate all ordered permutations of the given items with a fixed length.
    /// </summary>
    private IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int length) {
      if (length == 1) {
        foreach (var item in items)
          yield return new[] { item };
        yield break;
      }

      foreach (var perm in GetPermutations(items, length - 1)) {
        foreach (var item in items.Except(perm))
          yield return perm.Append(item);
      }
    }

  }
}