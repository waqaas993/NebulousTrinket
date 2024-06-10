using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace NebulousTrinket
{
    public class BoardView : MonoBehaviour
    {
        private Transform GridParent => transform;

        public Action OnBoardGenerated;

        public void Initialize(BoardModel model)
        {
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

                DeleteFaceCards();

                if (spriteIndex != -1)
                {
                    StartCoroutine(SpawnFaceCard(3, model, spriteIndex, i));
                }
            }

            StartCoroutine(SendBoardGeneratedSignal());
        }

        private void DeleteFaceCards()
        {
            for (int i = transform.childCount - 1; i >= 0 ; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        
        private IEnumerator SpawnFaceCard(float delay, BoardModel model, int spriteIndex, int index)
        {
            yield return new WaitForEndOfFrame();

            FaceCardController faceCardController = Instantiate(model.CardPrefab, GridParent);
            faceCardController.Initialize(model.Sprites[spriteIndex]);

            float xOffset = 1.5f;

            // Calculate position in the grid
            int width = model.Columns;
            int height = model.Rows;
            int row = index / width;
            int column = index % width;
            Vector2 position = new(column - ((float)(width) / 2) + .5f, (height - row - 1) - ((float)height / 2) + .5f);
            position = new(position.x * (model.CellSize.x + model.Spacing.x) + xOffset, position.y * (model.CellSize.y + model.Spacing.y));
            faceCardController.transform.position = position;
            yield return new WaitForSeconds(delay);
            faceCardController.Unflip();
        }

        private IEnumerator SendBoardGeneratedSignal()
        {
            yield return new WaitForEndOfFrame();
            OnBoardGenerated?.Invoke();
        }
    }
}
