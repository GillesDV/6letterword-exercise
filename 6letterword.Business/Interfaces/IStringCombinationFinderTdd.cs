using _6letterword.Business.Models;

namespace _6letterword.Business.Interfaces {
  public interface IStringCombinationFinderTdd {
    List<MatchResult> FindCombinations(List<Combination> validCombinations, List<string> partialWords);

  }
}
