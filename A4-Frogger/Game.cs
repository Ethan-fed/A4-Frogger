using Raylib_cs;
using System;
using System.Numerics;

namespace Game10003
{
    public class Game
    {
        // Paddle properties
        private Vector2 paddlePosition; // Position of the paddle
        private Vector2 paddleSize;     // Size of the paddle

        // Brick Properties
        public Bricks[,] brick;
        public void Setup()
        {
            Window.TargetFPS = 60;
            Window.SetTitle("The Brick Breaker");
            Window.SetSize(800, 600);

            // Initialize paddle properties
            paddleSize = new Vector2(150, 30); // Width = 150, Height = 30
            paddlePosition = new Vector2(Window.Width / 2 - paddleSize.X / 2, Window.Height - 60); // Centered at the bottom

            int BrickHeight = 40;
            int BrickWidth = 80;
            int Margin = 8;
            int BrickCount = (Window.Width - Margin) / (BrickWidth + Margin);
            brick = new Bricks[BrickCount, 5];
            Console.WriteLine(brick.Length);
            for (int )
            {
                for (int i = 0; i < brick.Length; i++)
                {
                    Console.WriteLine(i);
                    brick[i] = new Bricks(BrickHeight, BrickWidth, new Vector2((i * (BrickWidth + Margin)) + Margin, Margin));
                    brick[i].Render();
                }
            }
        }

        public void Update()
        {

            for (int i = 0; i < brick.Length; i++)
            {
                brick[i].Render();
            }

            // Clear the screen
            Window.ClearBackground(Color.OffWhite);

            // Update paddle position based on mouse movement
            paddlePosition.X = Math.Clamp(Input.GetMouseX() - paddleSize.X / 2, 0, Window.Width - paddleSize.X);

            // Draw the paddle
            DrawPaddle();

            

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
