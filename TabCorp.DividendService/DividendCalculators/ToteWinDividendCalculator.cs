using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService.DividendCalculators
{
    public class ToteWinDividendCalculator : BaseDividendCalculator
    {
        public ToteWinDividendCalculator() : base(15)
        {}
        
        protected override Dictionary<String, IEnumerable<Bet>> FindWinners(IEnumerable<Bet> bets, RaceResult raceResult)
        {
            return bets.Where(bet => bet.SelectionString == raceResult.FirstPlaceStarterNumber)
                        .GroupBy(x => x.SelectionString)
                        .ToDictionary(x => x.Key, y => y.AsEnumerable());
        }
    }
}