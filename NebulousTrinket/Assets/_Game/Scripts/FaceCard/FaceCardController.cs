using System;
using UnityEngine;
using UnityEngine.UI;

namespace NebulousTrinket
{
    public class FaceCardController : BaseController, ICard
    {
        private FaceCardModel Model;
        [SerializeField]
        private FaceCardView View;
        [SerializeField]
        private Button Button;

        public static Action<ICard> OnFlip;
        public static Action<ICard> OnUnflip;

        public string ID => Model.ID;
        
        private void OnEnable()
        {
            GamePlayController.OnCardMatched += CardMatched;
        }

        private void OnDisable()
        {
            GamePlayController.OnCardMatched -= CardMatched;
        }

        private void Awake()
        {
            Button.onClick.AddListener(Flip);
        }
        
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
            else
            {
                Unflip();
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