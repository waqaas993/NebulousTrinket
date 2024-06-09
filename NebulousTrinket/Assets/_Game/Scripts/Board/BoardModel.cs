using UnityEngine;

namespace NebulousTrinket
{
    public class BoardModel
    {
        private BoardConfigs _BoardConfigs;
        private ConfigsController _ConfigsController;

        private BoardConfigs BoardConfigs => _BoardConfigs ?? (_BoardConfigs = ConfigsController.GetConfig<BoardConfigs>());
        private ConfigsController ConfigsController => _ConfigsController ?? (_ConfigsController = SingletonController<ConfigsController>.Instance);

        internal int Rows;
        internal int Columns;

        public FaceCardController CardPrefab => BoardConfigs.FaceCardPrefab;
        public Sprite[] Sprites { get; private set; }
        public Vector2 CellSize => BoardConfigs.CellSize;
        public Vector2 Spacing => BoardConfigs.Spacing;

        public BoardModel(int rows, int columns, Sprite[] sprites)
        {
            Rows = rows;
            Columns = columns;
            Sprites = sprites;
        }
    }
}
