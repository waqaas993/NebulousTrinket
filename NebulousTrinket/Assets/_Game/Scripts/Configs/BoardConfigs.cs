using UnityEngine;

namespace NebulousTrinket
{
    [CreateAssetMenu(menuName = "Configs/BoardConfigs", fileName = "BoardConfigs")]
    public class BoardConfigs : BaseConfigs
    {
        public FaceCardController FaceCardPrefab;

        public Vector2 CellSize;
        public Vector2 Spacing;
    }
}
