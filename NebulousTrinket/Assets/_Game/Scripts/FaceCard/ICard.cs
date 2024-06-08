using System;

namespace NebulousTrinket
{
    public interface ICard
    {
        string ID { get; }
        void Flip();
        void Unflip();

        public static Action<ICard> OnFlip;
        public static Action<ICard> OnUnflip;
    }
}
