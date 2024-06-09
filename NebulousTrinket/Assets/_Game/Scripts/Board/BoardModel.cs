using UnityEngine;

namespace NebulousTrinket
{
    public class BoardModel
    {
        private BoardConfigs _BoardConfigs;
        private ConfigsController _ConfigsController;

        private BoardConfigs BoardConfigs => _BoardConfigs ?? (_BoardConfigs = ConfigsController.GetConfig<BoardConfigs>());
        private ConfigsController ConfigsController => _ConfigsController ?? (_ConfigsController = SingletonController<ConfigsController>.Instance);


        public FaceCardController CardPrefab => BoardConfigs.FaceCardPrefab;
        public Sprite[] Sprites { get; private set; }
        public int Rows => BoardConfigs.Rows;
        public int Columns => BoardConfigs.Columns;
        public Vector2 Spacing => BoardConfigs.Spacing;
        public Vector2 CellSize => BoardConfigs.CellSize;

        public void Initialize(Sprite[] sprites)
        {
            Sprites = sprites;
        }
    }
}
