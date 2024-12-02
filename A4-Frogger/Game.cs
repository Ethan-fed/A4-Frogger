using Game10003;
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

        public void Setup()
        {
            Window.TargetFPS = 60;
            Window.SetTitle("Brick Breaker");
            Window.SetSize(800, 600);

            // Initialize paddle properties
            paddleSize = new Vector2(150, 30); // Width = 150, Height = 30
            paddlePosition = new Vector2(Window.Width / 2 - paddleSize.X / 2, Window.Height - 60); // Centered at the bottom

            // Initialize ball 
            ball = new Ball(
                new Vector2(Window.Width / 2, Window.Height -350), // Position Ball to just above the middle of screen
                new Vector2(0, 4), // Give Ball downward velocity with 4 strength
                15 // Give ball 15 radius
            ); 
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
