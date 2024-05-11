using System;
using System.Runtime.InteropServices;

namespace projekt
{
    class Camera
    {
        private static Camera _instance = new Camera();
        public IntVector2 offset = IntVector2.Zero;

        public static Camera Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new Camera();

                return _instance;
            }

            private set{}
        }


        public void RenderScene(Scene scene)
        {
            Console.Clear();
            foreach(Actor actor in scene.actors)
            {
                actor.visualRepresentation.TryDisplayAtPosition(actor.transform.Position + offset);
            }
        }

    }
}