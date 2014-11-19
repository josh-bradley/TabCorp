using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService
{
    public class SelectionDividend
    {
        public SelectionDividend(string selectionString, double dividend)
        {
            SelectionString = selectionString;
            Dividend = dividend;    
        }

        public string SelectionString { get; private set; }
        public double Dividend { get; private set; }
    }

    public class Bet
    {
        public Bet(string selectionString, double betAmount)
        {
            SelectionString = selectionString;
            BetAmount = betAmount;
            StarterNumberSelections = selectionString.Split(',').ToList();
        }

        public double BetAmount { get; private set; }
        public string SelectionString { get; private set; }
        public List<String> StarterNumberSelections { get; private set; } 
    }

    public class RaceResult
    {
        public RaceResult(IEnumerable<String> starterResults)
        {
            StarterResults = starterResults.ToList();
        }

        public List<String> StarterResults { get; set; }

        public string FirstPlaceStarterNumber { get { return StarterResults[0]; } }
        public string SecondPlaceStarterNumber { get { return StarterResults[1]; } }
        public string ThirdPlaceStarterNumber { get { return StarterResults[2]; } }
    }
}
