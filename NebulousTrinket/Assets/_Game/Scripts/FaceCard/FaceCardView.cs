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
        private SpriteRenderer[] SpriteRenderers;

        private const string FLIP = "Flip";
        private const string UNFLIP = "Unflip";
        private const string MATCHED = "Matched";

        private FaceCardModel Model;

        internal void Initialize(FaceCardModel model)
        {
            Model = model;
            foreach (SpriteRenderer spriteRenderer in SpriteRenderers)
            {
                spriteRenderer.sprite = Model.Sprite;
            }
        }

        internal void Refresh()
        {
            if (Model == null || Animator == null)
            {
                return;
            }
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

        /// <summary>
        /// Animation Event
        /// </summary>
        public void DestroyMe() 
        {
            Destroy(gameObject);
        }
    }

}
