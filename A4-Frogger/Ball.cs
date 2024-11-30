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
        Vector2 position;
        Vector2 velocity;

        int size = 25;
        
        
        public Ball(Vector2 startingPosition, Vector2 startingVelocity, int size = 25) 
        {
            position = startingPosition;
            velocity = startingVelocity;
            this.size = size;
        }
    }
}
