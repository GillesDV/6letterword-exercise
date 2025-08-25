using System.Collections.Concurrent;

namespace _6letterword.Business;

public class StringCombinationFinderRecursive {

    //TODO can change me into a setting, so you could change it at-runtime
    private const int MAX_OUTPUT_LENGTH = 6;
 
    public List<string> FindCombinations(List<string> allInputStrings) {
        var inputSet = new HashSet<string>(
            allInputStrings.Where(s => !string.IsNullOrEmpty(s))
        );

        var orderedList = inputSet.OrderBy(s => s.Length).ToList(); 
        var results = new ConcurrentBag<string>();
        var seen = new ConcurrentDictionary<string, bool>();

        Parallel.ForEach(orderedList, firstWord => {
            if (firstWord.Length == MAX_OUTPUT_LENGTH)
                return;

            FindCombinationRecursive(orderedList, inputSet, firstWord, firstWord, results, seen);
        });

        return results.Distinct().ToList();
    }

    private static void FindCombinationRecursive(
        List<string> allInputStrings,
        HashSet<string> inputSet,
        string currentWord,
        string path,
        ConcurrentBag<string> results,
        ConcurrentDictionary<string, bool> seen) {
        if (currentWord.Length > MAX_OUTPUT_LENGTH)
            return;

        // skip recomputing if we've already explored this branch
        if (!seen.TryAdd(currentWord, true))
            return;

        if (currentWord.Length == MAX_OUTPUT_LENGTH && inputSet.Contains(currentWord)) {
            results.Add($"{path} = {currentWord}");
            return;
        }

        foreach (var nextWord in allInputStrings) {
            if (currentWord.Length + nextWord.Length > MAX_OUTPUT_LENGTH)
                break; // Early exit clause, because we've already ordered by Length. Performance improvement.

            FindCombinationRecursive(
                allInputStrings,
                inputSet,
                currentWord + nextWord,
                $"{path} + {nextWord}",
                results,
                seen);
        }
    }



}
