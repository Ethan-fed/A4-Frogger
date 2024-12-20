
﻿using Game10003;
﻿using Raylib_cs;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Game10003
{
    public class Game
    {
        float collisionThreshold = 15.0f;

        // Paddle properties
        private Vector2 paddlePosition; // Position of the paddle
        private Vector2 paddleSize;     // Size of the paddle 
        // Ball
        private Ball ball;


        // Brick Properties
        public Bricks[,] brick;

        public void Setup()
        {
            Window.TargetFPS = 60;
            Window.SetTitle("Brick Breaker");
            Window.SetSize(800, 600);

            // Initialize paddle properties
            paddleSize = new Vector2(150, 30); // Width = 150, Height = 30
            paddlePosition = new Vector2(Window.Width / 2 - paddleSize.X / 2, Window.Height - 60); // Centered at the bottom

// HEAD
            // Initialize ball 
            ball = new Ball(
                new Vector2(Window.Width / 2, Window.Height -350), // Position Ball to just above the middle of screen
                new Vector2(0, 4), // Give Ball downward velocity with 4 strength
                15 // Give ball 15 radius
            ); 

            int BrickHeight = 40;
            int BrickWidth = 80;
            int Margin = 8;
            int BrickCount = (Window.Width - Margin) / (BrickWidth + Margin);
            brick = new Bricks[5, BrickCount];
            Console.WriteLine(brick.Length);
            for (int r  = 0; r < brick.GetLength(0); r++)
            {
                for (int i = 0; i < brick.GetLength(1); i++)
                {
                    Console.WriteLine(i);
                    brick[r, i] = new Bricks(BrickHeight, BrickWidth, new Vector2((i * (BrickWidth + Margin)) + Margin, (r * (BrickHeight + Margin)) + Margin));
                    brick[r, i].Render();
                }
            }
// Olwyn-Bricks
        }

        public void Update()
        {
            // Clear the screen
            Window.ClearBackground(Color.OffWhite);

            // Update paddle position based on mouse movement
            paddlePosition.X = Math.Clamp(Input.GetMouseX() - paddleSize.X / 2, 0, Window.Width - paddleSize.X);

            // Draw the paddle
            DrawPaddle();
 
            ball.Update(); // Update ball

            IsBallCollidingWithPaddle();

            for (int r = 0; r < brick.GetLength(0); r++)
            {
                for (int i = 0; i < brick.GetLength(1); i++)
                {
                    if (IsBallCollidingWithBrick(brick[r, i]) && !brick[r, i].BrickHit);
                    {
                        brick[r, i].BrickHit = false;
                        Console.WriteLine("brick hit");
                    }

                    brick[r, i].Render();
                }
            }

        }

        // Method to draw the paddle
        private void DrawPaddle()
        {
            Draw.LineColor = Color.Black;       // Set border color
            Draw.LineSize = 2;                 // Set border thickness
            Draw.FillColor = Color.Red;   // Set fill color
            Draw.Rectangle(paddlePosition, paddleSize); // Draw the paddle
        }

        private bool IsBallCollidingWithBrick(Bricks brick)
        {
            float ballLeft = ball.position.X - ball.size;
            float ballRight = ball.position.X + ball.size;
            float ballTop = ball.position.Y - ball.size;
            float ballBottom = ball.position.Y + ball.size;

            float brickLeft = brick.BrickPosition.X;
            float brickRight = brick.BrickPosition.X + brick.BrickWidth;
            float brickTop = brick.BrickPosition.Y;
            float brickBottom = brick.BrickPosition.Y + brick.BrickHeight;

            return ballLeft <= brickRight && ballRight >= brickLeft &&
                ballTop <= brickBottom && ballBottom >= brickTop;
        }

        private void IsBallCollidingWithPaddle()
        {
            float ballLeft = ball.position.X - ball.size;
            float ballRight = ball.position.X + ball.size;
            float ballTop = ball.position.Y - ball.size;
            float ballBottom = ball.position.Y + ball.size;

            float paddleLeft = paddlePosition.X;
            float paddleRight = paddlePosition.X + paddleSize.X;
            float paddleTop = paddlePosition.Y;
            float paddleBottom = paddlePosition.Y + paddleSize.Y;

            bool colLeft = MathF.Abs(ballLeft - paddleLeft) < collisionThreshold;
            bool colRight = MathF.Abs(ballRight - paddleRight) < collisionThreshold;
            bool colTop = MathF.Abs(ballTop - paddleTop) < collisionThreshold;
            bool colBottom = MathF.Abs(ballBottom - paddleBottom) < collisionThreshold;

            if (colTop && ball.velocity.Y > 0)
            {
                ball.position.Y = paddleTop - ball.size;
                ball.velocity.Y *= -1;
            }
            if (colBottom && ball.velocity.Y < 0)
            {
                ball.position.Y = paddleBottom + ball.size;
                ball.velocity.Y *= -1;
            }
            if (colLeft && ball.velocity.X > 0)
            {
                ball.position.X = paddleLeft - ball.size;
                ball.velocity.X *= -1;
            }
            if (colRight && ball.velocity.X < 0)
            {
                ball.position.X = paddleRight + ball.size;
                ball.velocity.X *= -1;
            }
        }
    }
}
