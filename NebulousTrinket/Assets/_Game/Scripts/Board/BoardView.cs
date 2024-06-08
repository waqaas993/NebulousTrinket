using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

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
                int spriteIndex = -1;
                do
                {
                    int randomIndex = Random.Range(0, spriteIndexes.Count);
                    if (spriteIndexes[randomIndex] > 0)
                    {
                        spriteIndex = randomIndex;
                        spriteIndexes[randomIndex] -= 1;
                    }
                } while (spriteIndex == -1);

                if (spriteIndex != -1)
                {
                    StartCoroutine(SpawnFaceCard(3, model, spriteIndex));
                }
            }
        }

        private IEnumerator SpawnFaceCard(float delay, BoardModel model, int spriteIndex)
        {
            FaceCardController faceCardController = Instantiate(model.CardPrefab, transform, worldPositionStays: false);
            faceCardController.Initialize(model.Sprites[spriteIndex]);
            yield return new WaitForSeconds(delay);
            faceCardController.Unflip();
        }
    }
}
