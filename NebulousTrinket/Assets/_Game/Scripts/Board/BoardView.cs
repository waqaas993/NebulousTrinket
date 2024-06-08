using UnityEngine;
using UnityEngine.UI;

namespace NebulousTrinket
{
    public class BoardView : MonoBehaviour
    {
        public GridLayoutGroup GridLayoutGroup;
        public GameObject CardPrefab;

        public void Initialize(BoardModel boardModel)
        {
            GridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            GridLayoutGroup.constraintCount = boardModel.Columns;

            for (int i = 0; i < boardModel.Rows * boardModel.Columns; i++)
            {
                Instantiate(CardPrefab, GridLayoutGroup.transform);
            }
        }
    }
}
