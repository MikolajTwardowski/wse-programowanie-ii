using System;

namespace projekt
{
    class Actor
    {
        public VisualRepresentation visualRepresentation {get; private set;}
        public Transform transform {get; private set;}

        public Actor(VisualRepresentation visualRepresentation, Transform transform)
        {
            this.visualRepresentation = visualRepresentation;
            this.transform = transform;
        }
    }
}