using UnityEngine;

namespace NebulousTrinket
{
    public class BoardController : BaseController
    {
        [SerializeField]
        private BoardView View;
        private BoardModel Model;

        [SerializeField]
        private int Rows;
        [SerializeField]
        private int Columns;

        public override void Initialize(params object[] parameters)
        {
            DownloadAssetBundle.GetRandomSprites(this, (Rows * Columns) / 2,
                (Sprite[] sprites) =>
                {
                    Model = new BoardModel(Rows, Columns, sprites);
                    View.Initialize(Model);
                }
            );
        }
    }
}