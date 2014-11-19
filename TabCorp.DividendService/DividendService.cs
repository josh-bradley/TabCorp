using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService
{
    public class DividendService : IDividendService
    {
        private readonly IBetStringParser _betStringParser;
        private readonly IPoolFactory _poolFactory;
        private readonly IDividendFormater _dividendFormater;
        private readonly IRaceResultsParser _raceResultsParser;

        public DividendService(IBetStringParser betStringParser, IPoolFactory poolFactory, IDividendFormater dividendFormater, IRaceResultsParser raceResultsParser)
        {
            _betStringParser = betStringParser;
            _poolFactory = poolFactory;
            _dividendFormater = dividendFormater;
            _raceResultsParser = raceResultsParser;
        }

        public IEnumerable<String> GetListOfDividends(String betString, String raceResultString)
        {
            var raceResult = _raceResultsParser.ParseRaceResultString(raceResultString);
            var betsByType = _betStringParser.ParseBetStrings(betString);
            IEnumerable<String> formattedDividendStrings = new List<String>();

            foreach (var betTypeAndBets in betsByType)
            {
                var pool = _poolFactory.GetDividendCalculator(betTypeAndBets.Key);
                var selectionDividends = pool.DividendCalculator.GetDividends(betTypeAndBets.Value, raceResult);
                var temp = _dividendFormater.FormatDividends(selectionDividends, pool);
                formattedDividendStrings = formattedDividendStrings.Concat(temp);
            }

            return formattedDividendStrings;
        } 
    }

    public interface IDividendService
    {
        IEnumerable<String> GetListOfDividends(String betString, String raceResultString);
    }
}
