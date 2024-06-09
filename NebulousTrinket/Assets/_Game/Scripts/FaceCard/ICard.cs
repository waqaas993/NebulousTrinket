using System;

namespace NebulousTrinket
{
    public interface ICard
    {
        string ID { get; }
        void Flip();
        void Unflip();
    }
}