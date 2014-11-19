using System;
using System.Linq;
using System.Collections.Generic;

namespace TabCorp.DividendService.DividendCalculators
{
    public class ToteExactaDividendCalculator : BaseDividendCalculator
    {
        public ToteExactaDividendCalculator() : base(18)
        {
                
        }

        protected override Dictionary<String, IEnumerable<Bet>> FindWinners(IEnumerable<Bet> bets, RaceResult raceResult)
        {
            return bets.Where(bet => bet.StarterNumberSelections[0] == raceResult.FirstPlaceStarterNumber &&
                                                bet.StarterNumberSelections[1] == raceResult.SecondPlaceStarterNumber)
                                                .GroupBy(x => x.SelectionString)
                                                .ToDictionary(x => x.Key, y => y.AsEnumerable()); ;
        }
    }
}
