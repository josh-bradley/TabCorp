using System.Collections.Generic;
using System.Text;
using TabCorp.DividendService;

namespace TabCorp.Test
{
    public static class Mother
    {
        public static List<Bet> GetThreeWinPlaceBets()
        {
            return GetThreeWinPlaceBets(1, 1, 1);
        }

        public static List<Bet> GetThreeWinPlaceBets(double betAmountStarter1, double betAmountStarter2, double betAmountStarter3)
        {
            var bet1 = new Bet("1", betAmountStarter1);
            var bet2 = new Bet("2", betAmountStarter2);
            var bet3 = new Bet("3", betAmountStarter3);
            
            return new List<Bet>() { bet1, bet2, bet3 };
        }

        public static List<Bet> GetThreeExactaQuinellaBets()
        {
            var bet1 = new Bet("1,2", 1);
            var bet2 = new Bet("1,3", 1);
            var bet3 = new Bet("2,3", 1);
            
            return new List<Bet> { bet1, bet2, bet3 };
        }

        public static RaceResult GetRaceResult()
        {
            return new RaceResult(new [] { "1", "2", "3" });
        }
    }
}
