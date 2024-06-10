using System;

namespace NebulousTrinket
{
    public class LevelController : BaseController
    {
        private BoardController _BoardController;
        public BoardController BoardController => _BoardController ?? (_BoardController = SingletonController<BoardController>.Instance);

        private LevelModel Model;

        public static Action OnRestart;
        public static Action OnStart;
        public static Action OnFail;
        public static Action OnComplete;

        private void OnEnable()
        {
            InGameUIController.OnRestart += LevelRestarted;
        }

        private void OnDisable()
        {
            InGameUIController.OnRestart -= LevelRestarted;
        }

        public override void Initialize(params object[] parameters)
        {
            Model = new();
            BoardController.Initialize();
            OnStart?.Invoke();
        }

        //Re-initialize; temporary
        private void LevelRestarted()
        {
            Initialize();
            OnRestart?.Invoke();
        }
    }
}