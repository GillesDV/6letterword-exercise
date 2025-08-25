namespace _6letterword.Business.Models {
  public class MatchResult {

    public string CompleteWord { get; set; }

    public List<string> PartsOfCompleteWord { get; set; }

    public override string ToString() {
      return $"{string.Join(" + ", PartsOfCompleteWord)} = {CompleteWord}";
    }

  }
}
