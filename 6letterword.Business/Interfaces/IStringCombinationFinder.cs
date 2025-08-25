using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6letterword.Business.Models;

namespace _6letterword.Business.Interfaces {
  public interface IStringCombinationFinder {
    List<MatchResult> FindCombinations(List<string> allInputStrings);

  }
}
