using System;

namespace projekt
{
    class Transform
    {
        public IntVector2 Position {get; private set;}

        public Transform(IntVector2 position)
        {
            this.Position = position;
        }
        
        public void SetNewPosition(IntVector2 position)
        {
            this.Position = position;
        }

        public void Move(IntVector2 vector)
        {
            Position += vector;
        }
    }
}