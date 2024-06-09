using System;

namespace NebulousTrinket
{
    public class LevelController : BaseController
    {
        private BoardController _BoardController;
        public BoardController BoardController => _BoardController ?? (_BoardController = SingletonController<BoardController>.Instance);

        private LevelModel Model;

        public Action Restarted;
        public Action Started;
        public Action Failed;
        public Action Completed;

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
            Started?.Invoke();
        }

        //Re-initialize; temporary
        private void LevelRestarted()
        {
            Initialize();
            Restarted?.Invoke();
        }
    }
}