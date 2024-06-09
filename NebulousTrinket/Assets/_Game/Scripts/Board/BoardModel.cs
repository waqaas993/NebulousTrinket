using UnityEngine;

namespace NebulousTrinket
{
    public class BoardModel
    {
        private BoardConfigs _Configs;
        private ConfigsController _ConfigsController;

        private BoardConfigs Configs => _Configs ?? (_Configs = ConfigsController.GetConfig<BoardConfigs>());
        private ConfigsController ConfigsController => _ConfigsController ?? (_ConfigsController = SingletonController<ConfigsController>.Instance);


        public FaceCardController CardPrefab => Configs.FaceCardPrefab;
        public Sprite[] Sprites { get; private set; }
        public int Rows => Configs.Rows;
        public int Columns => Configs.Columns;
        public Vector2 Spacing => Configs.Spacing;
        public Vector2 CellSize => Configs.CellSize;

        public void Initialize(Sprite[] sprites)
        {
            Sprites = sprites;
        }
    }
}
