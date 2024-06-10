using UnityEngine;

namespace NebulousTrinket
{
    public class BoardScreenSizeView : MonoBehaviour
    {
        internal void Resize(BoardScreenSizeModel model)
        {
            transform.localScale = new Vector3(1, 1, 1);

            int boardWidth = model.Columns;
            int boardHeight = model.Rows;

            if (boardWidth < 5)
                boardWidth = 5;
            if (boardHeight < 5)
                boardHeight = 5;

            float width = model.CardCollider.size.x * boardWidth + model.Spacing.x;
            float height = model.CardCollider.size.x * boardHeight + model.Spacing.y;

            float worldScreenHeight = Camera.main.orthographicSize * 2;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;


            float widthSize = worldScreenWidth / width;
            widthSize /= 3;
            //Take 1.6/3 parts of the screen
            widthSize *= 1.6f;

            float size;
            if (boardWidth >= boardHeight)
                size = widthSize;
            else
            {
                size = worldScreenHeight / height;
                size /= 3;
                //Take 2.4/3 of screen height
                size *= 2.4f;

                //override if it exceeds width
                if (size >= widthSize)
                    size = widthSize;
            }

            transform.localScale = new Vector3(size, size, 1);
        }
    }
}