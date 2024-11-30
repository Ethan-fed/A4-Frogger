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

        public Bricks(Vector2 newPosition) 
        {
            BrickColor = Color.White;

            BrickPosition = newPosition;
        }
        public void Render()
        {
            Draw.FillColor = BrickColor;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 2;
            Draw.Rectangle(5, 5, 40, 20);
        }
    }
}
