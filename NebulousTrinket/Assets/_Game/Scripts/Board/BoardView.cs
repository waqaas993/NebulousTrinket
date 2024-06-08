using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

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

            List<int> spriteIndexes = new();
            for (int i = 0; i < (model.Rows * model.Columns) / 2; i++)
            {
                spriteIndexes.Add(2);
            }

            for (int i = 0; i < model.Rows * model.Columns; i++)
            {
                int index = -1;
                do
                {
                    int randomIndex = Random.Range(0, spriteIndexes.Count);
                    if (spriteIndexes[randomIndex] > 0)
                    {
                        index = randomIndex;
                        spriteIndexes[randomIndex] -= 1;
                    }
                } while (index == -1);

                if (index != -1)
                {
                    FaceCardController faceCardController = Instantiate(model.CardPrefab, transform, worldPositionStays: false);
                    faceCardController.Initialize(model.Sprites[index]);
                }
            }
        }
    }
}
