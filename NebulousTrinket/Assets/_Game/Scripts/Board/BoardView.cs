using UnityEngine;
using UnityEngine.UI;

namespace NebulousTrinket
{
    [RequireComponent(typeof(BoardController))]
    public class BoardView : MonoBehaviour
    {
        public GridLayoutGroup GridLayoutGroup;

        public void Initialize(BoardModel model)
        {
            GridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            GridLayoutGroup.constraintCount = model.Columns;

            for (int i = 0; i < model.Rows * model.Columns; i++)
            {
                FaceCardController faceCardController = Instantiate(model.CardPrefab, GridLayoutGroup.transform);
                //TODO: Pass sprite param
                faceCardController.Initialize();
            }
        }
    }
}
