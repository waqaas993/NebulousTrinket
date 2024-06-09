using UnityEngine;

namespace NebulousTrinket
{
    public class BoardScreenSizeModel
    {
        private BoxCollider2D _CardCollider;
        private BoardConfigs _BoardConfigs;
        private ConfigsController _ConfigsController;
        private BoardConfigs BoardConfigs => _BoardConfigs ?? (_BoardConfigs = ConfigsController.GetConfig<BoardConfigs>());
        private ConfigsController ConfigsController => _ConfigsController ?? (_ConfigsController = SingletonController<ConfigsController>.Instance);

        public int Columns => BoardConfigs.Rows;
        public int Rows => BoardConfigs.Columns;
        public Vector2 Spacing => BoardConfigs.Spacing;
        public BoxCollider2D CardCollider => _CardCollider ?? (_CardCollider = BoardConfigs.FaceCardPrefab.GetComponent<BoxCollider2D>());
    }
}
