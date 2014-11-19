using System;
using System.Collections.Generic;

namespace TabCorp.DividendService
{
    public class BetStringParser : IBetStringParser
    {
        private const char BET_STRING_SPLITTER = ';';
        private const char BET_STRING_PARTS_SPLITTER = ':';

        public Dictionary<string, List<Bet>> ParseBetStrings(String source)
        {
            var betsByType = new Dictionary<String, List<Bet>>();
            var betStrings = source.Split(new [] { BET_STRING_SPLITTER },  StringSplitOptions.RemoveEmptyEntries);

            foreach (var betString in betStrings)
            {
                // Bet strings in the format of "BetType:Selection:BetAmount"
                var betStringParts = betString.Split(BET_STRING_PARTS_SPLITTER);
                var betType = betStringParts[0];
                var selectionString = betStringParts[1];
                var betAmount = Int32.Parse(betStringParts[2]);

                if (!betsByType.ContainsKey(betType))
                {
                    betsByType.Add(betType, new List<Bet>());
                }

                var bets = betsByType[betType];
                bets.Add(new Bet(selectionString, betAmount));
            }

            return betsByType;
        }
    }

    public interface IBetStringParser
    {
        Dictionary<string, List<Bet>> ParseBetStrings(String source);
    }
}