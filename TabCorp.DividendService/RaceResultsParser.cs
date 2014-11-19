using System;
using System.Linq;

namespace TabCorp.DividendService
{
    public class RaceResultsParser : IRaceResultsParser
    {
        private const char STARTER_RESULTS_SPLITTER = ':';
        public RaceResult ParseRaceResultString(string raceResultString)
        {
            var starterResults = (raceResultString ?? String.Empty).Split(new [] {STARTER_RESULTS_SPLITTER}, StringSplitOptions.RemoveEmptyEntries).Skip(1);
            return new RaceResult(starterResults);
        }
    }
}