using UnityEngine;
using System.Collections.Generic;

namespace NebulousTrinket
{
    public class GameController : BaseController
    {
        [SerializeField]
        private List<BaseController> Controllers;

        void Awake() => Initialize();
        
        public override void Initialize(params object[] parameters)
        {
            foreach (var controller in Controllers)
            {
                controller.Initialize();
            }
        }
    }
}