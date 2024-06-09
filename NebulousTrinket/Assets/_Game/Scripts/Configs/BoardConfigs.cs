using UnityEngine;

namespace NebulousTrinket
{
    [CreateAssetMenu(menuName = "Configs/BoardConfigs", fileName = "BoardConfigs")]
    public class BoardConfigs : BaseConfigs
    {
        public FaceCardController FaceCardPrefab;

        public int Rows;
        public int Columns;
        public Vector2 CellSize;
        public Vector2 Spacing;
    }
}
