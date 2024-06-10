using System;

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
            LevelController.OnStart += LevelStarted;
        }

        private void OnDisable()
        {
            GamePlayController.OnCardMatched -= CardMatched;
            GamePlayController.OnCardsUnmatched -= CardsUnmatched;
            LevelController.OnStart -= LevelStarted;
        }

        public override void Initialize(params object[] parameters) => LevelStarted();

        private void CardMatched(string obj)
        {
            Model.IncreaseMatches();
            Model.IncreaseTurns();
        }

        private void CardsUnmatched(string arg1, string arg2)
        {
            Model.IncreaseTurns();
        }

        private void LevelStarted() => Model = new(0, 0);
    }
}