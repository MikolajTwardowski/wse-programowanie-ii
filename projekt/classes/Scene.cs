using System;

namespace projekt
{
    class Scene
    {


        public List<Actor> actors {get; private set;} = new List<Actor>();

        public Scene()
        {

        
        }

        public void AddActor(Actor actor)
        {
            actors.Add(actor);
        }

        public void RemoveActor(Actor actor)
        {
            actors.Remove(actor);
        }
    }
}