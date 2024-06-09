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

        }

        private void OnDisable()
        {

        }

        public override void Initialize(params object[] parameters)
        {
            View.Initialize();
            View.OnRestart += SendOnRestart;
        }

        private void Update()
        {
            //TODO: Shouldn't be in update, and instead should be subscribed to actions, doing it this way
            //Since I'm running out of time
            View.Refresh(ScoreSystemController.Matches, ScoreSystemController.Turns);
        }

        private void SendOnRestart()
        {
            OnRestart?.Invoke();
        }
    }
}