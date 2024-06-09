namespace NebulousTrinket
{
    public class ScoreSystemController : BaseController, IInstance
    {
        private ScoreSystemModel Model;

        public int Matches => Model.Matches;
        public int Turns => Model.Turns;

        private void OnEnable()
        {
            GamePlayController.OnCardMatched += CardMatched;
            GamePlayController.OnCardsUnmatched += CardsUnmatched;
        }

        private void OnDisable()
        {
            GamePlayController.OnCardMatched -= CardMatched;
            GamePlayController.OnCardsUnmatched -= CardsUnmatched;
        }

        public override void Initialize(params object[] parameters)
        {
            Model = new(0,0);
        }

        private void CardMatched(string obj)
        {
            Model.IncreaseMatches();
            Model.IncreaseTurns();
        }

        private void CardsUnmatched(string arg1, string arg2)
        {
            Model.IncreaseMatches();
        }
    }
}