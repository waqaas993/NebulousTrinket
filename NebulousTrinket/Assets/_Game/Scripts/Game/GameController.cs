using UnityEngine;
using System.Collections.Generic;

namespace NebulousTrinket
{
    public class GameController : BaseController
    {
        [SerializeField]
        private List<BaseController> Controllers;

        void Awake() => Initialize();
        
        public override void Initialize()
        {
            foreach (var controller in Controllers)
            {
                controller.Initialize();
            }
        }
    }
}