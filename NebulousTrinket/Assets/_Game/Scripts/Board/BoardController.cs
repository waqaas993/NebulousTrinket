using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class BoardController : BaseController, IInstance
    {
        [SerializeField]
        private BoardView View;
        private BoardModel Model;

        public static Action OnBoardGenerated;

        public override void Initialize(params object[] parameters)
        {
            Model = new BoardModel();
            if (Model.Rows * Model.Columns % 2 != 0)
            {
                Debug.LogError($"Re-adjust rows and columns for possible card pairs!");
                return;
            }
            DownloadAssetBundle.GetRandomSprites(this, (Model.Rows * Model.Columns) / 2,
                (Sprite[] sprites) =>
                {
                    Model.Initialize(sprites);
                    View.Initialize(Model);
                }
            );
            View.OnBoardGenerated += SendBoardGeneratedSignal;
        }

        private void SendBoardGeneratedSignal()
        {
            OnBoardGenerated?.Invoke();
        }
    }
}