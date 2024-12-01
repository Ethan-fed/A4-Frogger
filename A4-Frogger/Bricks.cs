using System;
using System.Numerics;

namespace Game10003
{
    public class Bricks
    {

        public Color BrickColor;
        public int BrickWidth;
        public int BrickHeight;
        public float BrickRadius;
        public Vector2 BrickPosition;

        public Bricks(int brickHeight, int brickWidth, Vector2 newPosition) 
        {           
            BrickPosition = newPosition;

            BrickColor = Color.Gray;

            BrickWidth = brickWidth;
            BrickHeight = brickHeight;
            BrickRadius = 40;
        }        
        public void Render()
        {
            Draw.Rectangle(BrickPosition.X, BrickPosition.Y, BrickWidth, BrickHeight);
            Draw.FillColor = BrickColor;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 2;
        }
    }
}
