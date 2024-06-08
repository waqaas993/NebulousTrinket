using System.Collections.Generic;

namespace NebulousTrinket
{
    public class GamePlayModel
    {
        private List<ICard> FlippedCards = new();

        public void AddFlippedCard(ICard card)
        {
            FlippedCards.Add(card);
            if (FlippedCards.Count == 2)
            {
                TryMatch();
            }
        }

        public void RemoveFlippedCard(ICard card)
        {
            FlippedCards.Remove(card);
        }

        private bool TryMatch()
        {
            if (FlippedCards[0].ID == FlippedCards[1].ID)
            {
                return true;
            }
            else
            {
                foreach (var card in FlippedCards)
                {
                    card.Unflip();
                }
                FlippedCards.Clear();
            }
            return false;
        }
    }
}