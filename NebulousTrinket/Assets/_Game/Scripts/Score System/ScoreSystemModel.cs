namespace NebulousTrinket
{
    public class ScoreSystemModel
    {
        public int Matches { get; private set; }
        public int Turns { get; private set; }

        public ScoreSystemModel(int matches, int turns)
        {
            Matches = matches;
            Turns = turns;
        }

        public void IncreaseMatches() => Matches += 1;
        public void IncreaseTurns() => Turns += 1;
    }
}