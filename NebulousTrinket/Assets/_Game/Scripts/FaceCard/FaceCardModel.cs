using UnityEngine;

namespace NebulousTrinket
{
    public class FaceCardModel
    {
        public string ID { get => Sprite.name; }
        public bool IsFlipped { get; private set; }
        public Sprite Sprite { get; private set; }

        public FaceCardModel(Sprite sprite)
        {
            Sprite = sprite;
            IsFlipped = false;
        }

        public bool Flip()
        {
            if (!IsFlipped)
            {
                IsFlipped = true;
                return true;
            }
            return false;
        }

        public bool Unflip()
        {
            if (IsFlipped)
            {
                IsFlipped = false;
                return true;
            }
            return false;
        }
    }
}
