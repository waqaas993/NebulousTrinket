using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class GamePlayController : BaseController
    {
        private GamePlayModel GamePlayModel;

        public static Action<ICard> OnCardHit;
        public static Action<string> OnCardMatched;
        public static Action<string,string> OnCardsUnmatched;

        [SerializeField]
        private LayerMask ItemsLayerMask;

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

        private void Update()
        {
            HandleInput();
        }
        
        private void HandleInput()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 screenToWorldPoint = Vector2.zero;
#if UNITY_EDITOR
                screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
                if (Input.touchCount > 0)
                {
                    screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                }
#endif
                RaycastHit2D cardHit = Physics2D.Raycast(screenToWorldPoint, Vector2.zero, 100, ItemsLayerMask);
                if (cardHit.collider != null)
                {
                    if (cardHit.collider.transform.TryGetComponent(out ICard card))
                    {
                        OnCardHit?.Invoke(card);
                    }
                }
            }
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