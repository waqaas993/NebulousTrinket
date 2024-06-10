using System;
using UnityEngine;
using System.Collections;
using System.Text;

namespace NebulousTrinket
{
    public class GamePlayController : BaseController
    {
        private GamePlayModel Model;

        public static Action<FaceCardController> OnCardHit;
        public static Action<string> OnCardMatched;
        public static Action<string,string> OnCardsUnmatched;

        private Coroutine ResetCardsCoroutineRef = null;

        [SerializeField]
        private LayerMask ItemsLayerMask;

        public override void Initialize(params object[] parameters)
        {
            Model = new();
        }

        private void OnEnable()
        {
            FaceCardController.OnFlip += CardFlipped;
            LevelController.OnStart += LevelStarted;
        }

        private void OnDisable()
        {
            FaceCardController.OnFlip -= CardFlipped;
            LevelController.OnStart -= LevelStarted;
        }

        private void LevelStarted() => ResetCards(0);

        private void Update()
        {
            //PrintCardStack();
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
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
                        if (Model.CardStatus == CardStatus.Unmatched)
                        {
                            ResetCards(delay: 0);
                        }
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
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
                        if (Model.Cards.Count < 2)
                        {
                            OnCardHit?.Invoke((FaceCardController)card);
                        }
                    }
                }
            }
        }
        
        public void CardFlipped(ICard card)
        {
            Model.AddFlippedCard(card, out string cardMatchedID);
            if (cardMatchedID != "")
            {
                //TODO: Play Matched SFX
                OnCardMatched?.Invoke(cardMatchedID);
                ResetCards(delay: 1);
            }
            if (Model.CardStatus == CardStatus.Unmatched)
            {
                //TODO: Play Unmatched SFX
                ResetCards(delay: 2);
                OnCardsUnmatched?.Invoke("","");
            }
        }

        private void ResetCards(float delay)
        {
            if (ResetCardsCoroutineRef != null)
            {
                StopCoroutine(ResetCardsCoroutineRef);
            }
            ResetCardsCoroutineRef = StartCoroutine(ResetCardsCoroutine(delay: delay));
        }

        private IEnumerator ResetCardsCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Model.ResetCards();
            ResetCardsCoroutineRef = null;
        }
        
        private void PrintCardStack()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append($"Card Stack Size: {Model.Cards.Count}\n");
            foreach (var card in Model.Cards)
            {
                stringBuilder.Append($"Card ID: {card.ID}\n");
            }
            Log(stringBuilder.ToString());
        }

        private void Log(string message)
        {
            Debug.Log($"<{GetType()}> {message}");
        }
    }
}