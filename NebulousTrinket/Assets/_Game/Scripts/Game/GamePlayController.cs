using UnityEngine;

namespace NebulousTrinket
{
    public class GamePlayController : BaseController
    {
        private GamePlayModel GamePlayModel;

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
            GamePlayModel.AddFlippedCard(card);
        }

        public void CardUnflipped(ICard card)
        {
            GamePlayModel.RemoveFlippedCard(card);
        }
    }
}