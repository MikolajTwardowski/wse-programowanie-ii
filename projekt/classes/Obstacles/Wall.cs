using System;

namespace projekt
{
    class Wall : GameObject
    {
        public Wall(Transform transform) : base(transform)
        {
            visual.SetVisualRepresentation('#');
            visual.SetBackground(ConsoleColor.Gray);
        }
    }

}