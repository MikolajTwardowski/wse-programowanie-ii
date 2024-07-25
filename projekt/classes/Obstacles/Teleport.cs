using System;

namespace projekt
{
    class Teleport : GameObject
    {
        public IntVector2 destination;
        public Teleport(Transform transform, IntVector2 destination) : base(transform)
        {
            this.destination = destination;
            visual.SetVisualRepresentation('T');
            visual.SetForeground(ConsoleColor.Magenta);
        }


    }

}