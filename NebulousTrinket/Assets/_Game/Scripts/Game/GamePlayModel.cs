using System.Collections.Generic;

namespace NebulousTrinket
{
    public class GamePlayModel
    {
        private List<ICard> FlippedCards = new();

        public void AddFlippedCard(ICard card, out string cardMatchedID)
        {
            cardMatchedID = "";
            FlippedCards.Add(card);
            if (FlippedCards.Count == 2)
            {
                TryMatch(out cardMatchedID);
            }
        }

        public void RemoveFlippedCard(ICard card)
        {
            FlippedCards.Remove(card);
        }

        private void TryMatch(out string cardMatchedID)
        {
            cardMatchedID = "";
            if (FlippedCards[0].ID == FlippedCards[1].ID)
            {
                cardMatchedID = FlippedCards[0].ID;
            }
            else
            {
                foreach (var card in FlippedCards)
                {
                    card.Unflip();
                }
                FlippedCards.Clear();
            }
        }
    }
}