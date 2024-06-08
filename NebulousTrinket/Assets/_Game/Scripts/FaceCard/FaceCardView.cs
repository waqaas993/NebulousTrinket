using UnityEngine;
using UnityEngine.UI;

namespace NebulousTrinket
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(FaceCardController))]
    public class FaceCardView : MonoBehaviour
    {
        [SerializeField]
        private Animator Animator;
        [SerializeField]
        private Image Image;

        internal void Refresh(FaceCardModel model)
        {
            Image.sprite = model.Sprite;
            if (model.IsFlipped)
            {
                Animator.SetTrigger("Flip");
            }
            else
            {
                Animator.SetTrigger("Unflip");
            }
        }
    }

}
