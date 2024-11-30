using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace A4_Frogger
{
    public class Ball
    {
        public Vector2 position;
        public Vector2 velocity;

        int size = 25;
        
        
        public Ball(Vector2 startingPosition, Vector2 startingVelocity, int size = 25) 
        {
            position = startingPosition;
            velocity = startingVelocity;
            this.size = size;
        }


        public void Update()
        {
            UpdatePosition();
            CheckWindowCollisions();
            
            DrawBall();
        }


        private void DrawBall()
        {
            Draw.LineColor = Color.Black; 
            Draw.LineSize = 2;
            Draw.FillColor = Color.Green;
            Draw.Circle(position, size);
        }


        private void UpdatePosition()
        {
            position += velocity;
        }


        private void CheckWindowCollisions()
        {
            // Window Top collision
            if (position.Y - size < 0) position.Y = 0 + size;

            // Window Left collision
            if (position.X - size < 0) position.X = 0 + size;

            // Window Right collision
            if (position.X + size > Window.Height) position.X = Window.Height - size;
        }
    }
}
