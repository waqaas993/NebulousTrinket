using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class FaceCardController : BaseController, ICard
    {
        private FaceCardModel Model;
        [SerializeField]
        private FaceCardView View;

        public static Action<FaceCardController> OnFlip;
        public static Action<FaceCardController> OnUnflip;

        public string ID => Model.ID;
        public Sprite Sprite => Model.Sprite;

        private void OnEnable()
        {
            GamePlayController.OnCardHit += CardHit;
            GamePlayController.OnCardMatched += CardMatched;
        }

        private void OnDisable()
        {
            GamePlayController.OnCardHit -= CardHit;
            GamePlayController.OnCardMatched -= CardMatched;
        }

        private void CardHit(ICard card)
        {
            if (this == (FaceCardController)card)
            {
                Flip();
            }
        }

        public override void Initialize(params object[] parameters)
        {
            if (parameters[0] is Sprite sprite)
            {
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

        private void CardMatched(string id)
        {
            bool isSelf = ID == id;
            if (isSelf)
            {
                Model.SetMatched();
                View.Refresh();
            }
        }
    }
}