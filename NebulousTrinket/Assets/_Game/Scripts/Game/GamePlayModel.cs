using System.Linq;
using System.Collections.Generic;

namespace NebulousTrinket
{
    public enum CardStatus
    {
        None,
        Matched,
        Unmatched
    }

    public class GamePlayModel
    {
        public Stack<ICard> Cards { get; private set; }
        public CardStatus CardStatus 
        {
            get
            {
                if (Cards.Count == 2)
                {
                    string lastCardID = Cards.Last().ID;
                    int matchedCardsCount = Cards.Where(fc => fc.ID == lastCardID).Count();
                    return matchedCardsCount >= 2 ? CardStatus.Matched : CardStatus.Unmatched;
                }
                return CardStatus.None;
            }
        }

        public GamePlayModel()
        {
            Cards = new();
        }

        public void AddFlippedCard(ICard card, out string cardMatchedID)
        {
            cardMatchedID = "";
            Cards.Push(card);
            if (Cards.Count == 2)
            {
                TryMatch(out cardMatchedID);
            }
        }
        
        private void TryMatch(out string cardMatchedID)
        {
            cardMatchedID = "";
            string lastCardID = Cards.Last().ID;
            int matchedCardsCount = Cards.Where(fc => fc.ID == lastCardID).Count();
            if (matchedCardsCount >= 2)
            {
                cardMatchedID = lastCardID;
            }
        }

        public void ResetCards()
        {
            do
            {
                ICard card = Cards.Pop();
                card.Unflip();
            } while (Cards.Count != 0);
        }
    }
}