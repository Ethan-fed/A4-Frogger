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

        public Bricks() 
        {
            BrickColor = Color.White;

        }
        public void Render()
        {
            Draw.FillColor = BrickColor;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 2;
        }
    }
}
