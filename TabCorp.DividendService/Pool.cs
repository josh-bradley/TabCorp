using System;
using TabCorp.DividendService.DividendCalculators;

namespace TabCorp.DividendService
{
    public class Pool
    {
        public Pool(BaseDividendCalculator dividendCalculator, string betTypeDescription, bool isMultiSelectionBetType = false)
        {
            BetTypeDescription = betTypeDescription;
            IsMultiSelectionBetType = isMultiSelectionBetType;
            DividendCalculator = dividendCalculator;
        }

        public String BetTypeDescription { get; private set; }
        public bool IsMultiSelectionBetType { get; private set; }
        public BaseDividendCalculator DividendCalculator { get; private set; }
    }
}