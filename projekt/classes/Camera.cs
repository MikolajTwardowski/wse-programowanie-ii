using System;

namespace projekt
{
    class Camera
    {
        private static Camera _instance = new Camera();
        //IntVector2 offset;

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

            foreach(Actor actor in scene.actors)
            {
                if(actor.transform.Position.x >= 0 && 
                actor.transform.Position.x < Console.WindowWidth && 
                actor.transform.Position.y >= 0 && 
                actor.transform.Position.y < Console.WindowHeight - 1)
                {
                    actor.visualRepresentation.TryDisplayAtPosition(actor.transform.Position);

                }
            }

            /*
            for(int x = 0; x < Console.WindowWidth; x++)
            {   


                for(int y = 0; y < Console.WindowHeight - 1; y++)
                {
                    
                    Console.SetCursorPosition(x,y);
                
                }
            }
            */
            //Console.Write(screenOut);
        }

    }
}