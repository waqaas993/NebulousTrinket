using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class InGameUIController : BaseController
    {
        private ScoreSystemController _ScoreSystemController;
        public ScoreSystemController ScoreSystemController => _ScoreSystemController ?? (_ScoreSystemController = SingletonController<ScoreSystemController>.Instance);

        [SerializeField]
        private InGameUIView View;

        public static Action OnRestart;

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

        private void CardMatched(string obj) => Refresh();
        private void CardsUnmatched(string arg1, string arg2) => Refresh();
        private void LevelStarted() => Refresh();

        public override void Initialize(params object[] parameters)
        {
            View.Initialize();
            View.OnRestart += SendOnRestartSignal;
        }
        
        private void Refresh()
        {
            View.Refresh(ScoreSystemController.Matches, ScoreSystemController.Turns);
        }

        private void SendOnRestartSignal()
        {
            OnRestart?.Invoke();
        }
    }
}