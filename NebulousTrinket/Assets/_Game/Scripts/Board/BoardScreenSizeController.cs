using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class BoardScreenSizeController : BaseController
    {
        private BoardScreenSizeModel Model;
        [SerializeField]
        private BoardScreenSizeView View;

        private void OnEnable()
        {
            BoardController.OnBoardGenerated += BoardGenerated;
        }

        private void OnDisable()
        {
            BoardController.OnBoardGenerated -= BoardGenerated;
        }
        
        public override void Initialize(params object[] parameters)
        {
            Model = new();
            
        }
        
        private void BoardGenerated()
        {
            View.Resize(Model);
        }
    }
}