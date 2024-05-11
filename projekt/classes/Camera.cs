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
                if(actor.transform.Position.x + offset.x >= 0 && 
                actor.transform.Position.x + offset.x < Console.WindowWidth && 
                actor.transform.Position.y + offset.y >= 0 && 
                actor.transform.Position.y + offset.y< Console.WindowHeight - 1)
                {
                    actor.visualRepresentation.TryDisplayAtPosition(actor.transform.Position + offset);

                }
            }
            
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(offset.x + "  " + offset.y);
        }

    }
}