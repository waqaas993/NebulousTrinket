using System;
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

        private const string FLIP = "Flip";
        private const string UNFLIP = "Unflip";

        private FaceCardModel Model;

        internal void Initialize(FaceCardModel model)
        {
            Model = model;
            Image.sprite = Model.Sprite;
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
        }
    }

}
