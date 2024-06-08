using UnityEngine;

namespace NebulousTrinket
{
    public class GamePlayController : BaseController
    {
        private GamePlayModel GamePlayModel;

        public override void Initialize()
        {
            GamePlayModel = new();
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