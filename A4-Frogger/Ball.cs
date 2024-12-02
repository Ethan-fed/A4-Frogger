using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game10003
{
    public class Ball
    {
        public Vector2 position;
        public Vector2 velocity;

        public int size = 30;
        
        
        public Ball(Vector2 startingPosition, Vector2 startingVelocity, int size = 30) 
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
            if (position.Y - size < 0)
            {
                position.Y = 0 + size;
                velocity.Y *= -1;
            }

            // Window Left collision
            if (position.X - size < 0)
            {
                position.X = 0 + size;
                velocity.X *= -1;
            }

            // Window Right collision
            if (position.X + size > Window.Width)
            {
                position.X = Window.Width - size;
                velocity.X *= -1;
            }

            // Window Bottom collision
            if (position.Y + size > Window.Height) 
            { 
                position.Y = Window.Height - size;
                velocity.Y *= -1;
            }
        }

        //private bool IsCollidingWithPaddle( DrawPaddle)
     
       
    }
}
