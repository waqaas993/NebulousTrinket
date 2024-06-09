using UnityEngine;

namespace NebulousTrinket
{
    public class BoardController : BaseController, IInstance
    {
        [SerializeField]
        private BoardView View;
        private BoardModel Model;
        
        public override void Initialize(params object[] parameters)
        {
            Model = new BoardModel();
            DownloadAssetBundle.GetRandomSprites(this, (Model.Rows * Model.Columns) / 2,
                (Sprite[] sprites) =>
                {
                    Model.Initialize(sprites);
                    View.Initialize(Model);
                }
            );
        }
    }
}