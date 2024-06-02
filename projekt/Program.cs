using System;

namespace projekt // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        

        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey = new ConsoleKeyInfo();

            //FinalizerTest();

            GameObject go = new GameObject();

            //go = null;

            while(exitKey.Key != ConsoleKey.W)
            {
                //Console.Clear();


                exitKey = Console.ReadKey(true);
            }

        }

        static void DrawGameObjects()
        {
            
            foreach(var obj in gameObjects)
            {
                
            }
        }

        public static bool CheckCollisionOn(IntVector2 position, out GameObject other)
        {
            other = new GameObject();
            foreach(var obj in Program.gameObjects)
            {
                if(obj.position == position)
                {
                    other = obj;
                    return true;
                }
            }
            return false;
        }


    }
}