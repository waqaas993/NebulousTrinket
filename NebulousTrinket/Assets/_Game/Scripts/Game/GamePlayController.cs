using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class GamePlayController : BaseController
    {
        private GamePlayModel GamePlayModel;

        public static Action<string> OnCardMatched;

        public override void Initialize(params object[] parameters)
        {
            GamePlayModel = new();
        }

        private void OnEnable()
        {
            ICard.OnFlip += CardFlipped;
            ICard.OnUnflip += CardUnflipped;
        }

        private void OnDisable()
        {
            ICard.OnFlip -= CardFlipped;
            ICard.OnUnflip -= CardUnflipped;
        }

        public void CardFlipped(ICard card)
        {
            GamePlayModel.AddFlippedCard(card, out string cardMatchedID);
            if (cardMatchedID != "")
            {
                OnCardMatched?.Invoke(cardMatchedID);
            }
        }

        public void CardUnflipped(ICard card)
        {
            GamePlayModel.RemoveFlippedCard(card);
        }
    }
}