using System;
using UnityEngine;

namespace NebulousTrinket
{
    public class FaceCard : MonoBehaviour, ICard
    {
        public string ID { get => Sprite.name; }
        private bool IsFlipped = false;

        [SerializeField]
        private Animator Animator;
        [SerializeField]
        private Sprite Sprite;

        public static Action<ICard> OnFlip;
        public static Action<ICard> OnUnflip;

        void OnMouseDown()
        {
            if (!IsFlipped)
            {
                Flip();
            }
        }

        public void Flip()
        {
            IsFlipped = true;
            Animator.SetTrigger("Flip");
            OnFlip.Invoke(this);
        }

        public void Unflip()
        {
            IsFlipped = false;
            Animator.SetTrigger("Unflip");
            OnUnflip.Invoke(this);
        }
    }

}
