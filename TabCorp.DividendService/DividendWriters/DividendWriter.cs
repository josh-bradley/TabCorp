using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService.DividendWriters
{
    public abstract class DividendWriter
    {
        protected abstract List<string> PrintDividendResults(Dictionary<string, double> combinationDividends);
    }

    public class ToteWinDividendWriter : DividendWriter
    {
        protected override List<string> PrintDividendResults(Dictionary<string, double> combinationDividends)
        {
            return new List<String>() { String.Format("Win - Runner {0}  - ${1:0.00}", combinationDividends.First().Key, combinationDividends.First().Value.ToString()) };
        }
    }
}
