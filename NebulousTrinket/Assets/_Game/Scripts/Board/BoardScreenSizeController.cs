using UnityEngine;

namespace NebulousTrinket
{
    public class BoardScreenSizeController : BaseController
    {
        private BoardScreenSizeModel Model;
        [SerializeField]
        private BoardScreenSizeView View;

        public override void Initialize(params object[] parameters)
        {
            Model = new();
            View.Resize(Model);
        }
    }
}