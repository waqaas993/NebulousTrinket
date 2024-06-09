using UnityEngine;

namespace NebulousTrinket
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(FaceCardController))]
    public class FaceCardView : MonoBehaviour
    {
        [SerializeField]
        private Animator Animator;
        [SerializeField]
        private SpriteRenderer SpriteRenderer;

        private const string FLIP = "Flip";
        private const string UNFLIP = "Unflip";
        private const string MATCHED = "Matched";

        private FaceCardModel Model;

        internal void Initialize(FaceCardModel model)
        {
            Model = model;
            SpriteRenderer.sprite = Model.Sprite;
        }

        internal void Refresh()
        {
            if (Model.IsFlipped)
            {
                Animator.SetTrigger(FLIP);
            }
            else
            {
                Animator.SetTrigger(UNFLIP);
            }
            if (Model.IsMatched)
            {
                Animator.SetTrigger(MATCHED);
            }
        }
    }

}
