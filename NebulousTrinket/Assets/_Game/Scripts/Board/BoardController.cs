using UnityEngine;

namespace NebulousTrinket
{
    public class BoardController : BaseController
    {
        [SerializeField]
        private BoardView View;
        private BoardModel Model;
        
        public override void Initialize(params object[] parameters)
        {
            Model = new BoardModel(4, 4);
            View.Initialize(Model);
        }
    }
}