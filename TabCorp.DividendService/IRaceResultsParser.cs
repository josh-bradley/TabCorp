namespace TabCorp.DividendService
{
    public interface IRaceResultsParser
    {
        RaceResult ParseRaceResultString(string raceResultString);
    }
}