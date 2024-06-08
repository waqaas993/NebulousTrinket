using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class FaceCardController : BaseController, ICard
    {
        private FaceCardModel Model;
        [SerializeField]
        private FaceCardView View;

        public static Action<ICard> OnFlip;
        public static Action<ICard> OnUnflip;

        public string ID => Model.ID;

        public override void Initialize(params object[] parameters)
        {
            if (parameters[0] is Sprite sprite1)
            {
                Sprite sprite = sprite1;
                Model = new FaceCardModel(sprite);
                View.Initialize(Model);
            }
            else
            {
                Debug.LogError("Invalid parameters for FaceCardController Initialization!");
            }
        }

        public void Flip()
        {
            if (Model.Flip())
            {
                View.Refresh();
                OnFlip?.Invoke(this);
            }
        }

        public void Unflip()
        {
            if (Model.Unflip())
            {
                View.Refresh();
                OnUnflip?.Invoke(this);
            }
        }
    }
}