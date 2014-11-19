using System;
using System.Collections.Generic;

namespace TabCorp.DividendService
{
    public class DividendFormater : IDividendFormater
    {
        public List<string> FormatDividends(List<SelectionDividend> selectionDividends, Pool pool)
        {
            var formattedDividends = new List<string>();
            
            foreach (var selectionDividend in selectionDividends)
            {
                var pluralExtension = pool.IsMultiSelectionBetType ? "s" : String.Empty;
                var formattedDividend = String.Format("{0} - Runner{1} {3} - ${2:0.00}", pool.BetTypeDescription, pluralExtension, selectionDividend.Dividend, selectionDividend.SelectionString);
                formattedDividends.Add(formattedDividend);
            }

            return formattedDividends;
        }
    }

    public interface IDividendFormater
    {
        List<string> FormatDividends(List<SelectionDividend> selectionDividends, Pool pool);
    }
}