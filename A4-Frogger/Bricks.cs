using System;
using System.Numerics;

namespace Game10003
{
    public class Bricks
    {
        public bool BrickHit;
        public Color BrickColor;
        public int BrickWidth;
        public int BrickHeight;
        public float BrickRadius;
        public Vector2 BrickPosition;

        public Bricks(int brickHeight, int brickWidth, Vector2 newPosition) 
        {           
            BrickHit = false;

            BrickPosition = newPosition;

            BrickColor = Color.Gray;

            BrickWidth = brickWidth;
            BrickHeight = brickHeight;
            BrickRadius = 40;
        }        
        public void Render()
        {
            

            if (BrickHit)
            {
               
            }
            else
            {
                Draw.Rectangle(BrickPosition.X, BrickPosition.Y, BrickWidth, BrickHeight);
                Draw.FillColor = BrickColor;
                Draw.LineColor = Color.Black;
                Draw.LineSize = 2;
            }

            /* for (int r = 0; r < brick.GetLength(0); r++)
            {
                for (int i = 0; i < brick.GetLength(1); i++)
                {
                    /* if ()
                    {
                        brick[r, i].BrickHit = true;
                    }
                    
                    brick[r, i].Render();
                }
            }
            // Clear the screen
            Window.ClearBackground(Color.OffWhite);*/
        }
    }
}
