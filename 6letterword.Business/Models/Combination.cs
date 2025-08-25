using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6letterword.Business.Models {

  // Record (as opposed to class) overwrites the Equals by default
  public record Combination(string Value) {
    public bool IsFullyComposedOf(params string[] possibleWords) {
      if (possibleWords == null || possibleWords.Length == 0)
        return false;

      var combined = string.Concat(possibleWords);
      return string.Equals(Value, combined, StringComparison.InvariantCultureIgnoreCase);
    }

  }
}
