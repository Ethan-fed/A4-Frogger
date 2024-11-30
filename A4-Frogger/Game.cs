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
        Bricks[] bricks;
        public void Setup()
        {
            Window.TargetFPS = 60;
            Window.SetTitle("The Brick Breaker");
            Window.SetSize(800, 600);

            // Initialize paddle properties
            paddleSize = new Vector2(150, 30); // Width = 150, Height = 30
            paddlePosition = new Vector2(Window.Width / 2 - paddleSize.X / 2, Window.Height - 60); // Centered at the bottom

            bricks = new Bricks[12];
            for (int = 0; int < bricks.Length; int++)
            {

            }
        }

        public void Update()
        {
            // Clear the screen
            Window.ClearBackground(Color.OffWhite);

            // Update paddle position based on mouse movement
            paddlePosition.X = Math.Clamp(Input.GetMouseX() - paddleSize.X / 2, 0, Window.Width - paddleSize.X);

            // Draw the paddle
            DrawPaddle();

            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = new Bricks(new Vector2(i * 20, 20));
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
    }
}
