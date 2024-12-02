
﻿using Game10003;
﻿using Raylib_cs;
using System;
using System.Numerics;

namespace Game10003
{
    public class Game
    {
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
            
            for (int r = 0; r < brick.GetLength(0); r++)
            {
                for (int i = 0; i < brick.GetLength(1); i++)
                {                    
                    /* if ()
                    {
                        brick[r, i].BrickHit = true;
                    }
                    */
                    brick[r, i].Render();
                }
            }
            // Clear the screen
            Window.ClearBackground(Color.OffWhite);

            // Update paddle position based on mouse movement
            paddlePosition.X = Math.Clamp(Input.GetMouseX() - paddleSize.X / 2, 0, Window.Width - paddleSize.X);

            // Draw the paddle
            DrawPaddle();
 
            ball.Update(); // Update ball

        }

        // Method to draw the paddle
        private void DrawPaddle()
        {
            Draw.LineColor = Color.Black;       // Set border color
            Draw.LineSize = 2;                 // Set border thickness
            Draw.FillColor = Color.Red;   // Set fill color
            Draw.Rectangle(paddlePosition, paddleSize); // Draw the paddle
        }
    }
}
