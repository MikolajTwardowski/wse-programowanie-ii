using System;

namespace projekt
{
    class Tree: GameObject
    {
        public Tree(Transform transform) : base(transform)
        {
            visual.SetVisualRepresentation('#');
            visual.SetForeground(ConsoleColor.DarkGreen);
            visual.SetBackground(ConsoleColor.Black);
        }

    }
}