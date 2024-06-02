using System;

namespace projekt // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        

        static void Main(string[] args)
        {
            Player player = new Player(new IntVector2((int)Console.WindowWidth/2, (int)Console.WindowHeight/2));
            gameObjects.Add(player);

            Wall wall1 = new Wall(new IntVector2(10,3));
            gameObjects.Add(wall1);

            while(true)
            {
                RedrawScreen();
                InvokeUpdateForVisibleGameObjects();

            }

        }

        static void InvokeUpdateForVisibleGameObjects()
        {
            foreach(var obj in gameObjects)
            {
                if( obj.position.x < 0 || 
                    obj.position.x >= Console.WindowWidth || 
                    obj.position.y < 0 || 
                    obj.position.y >= Console.WindowHeight)
                    continue;
                obj.Update();
            }
        }

        static void RedrawScreen()
        {
            Console.Clear();
            foreach(var obj in gameObjects)
            {
                if( obj.position.x < 0 || 
                    obj.position.x >= Console.WindowWidth || 
                    obj.position.y < 0 || 
                    obj.position.y >= Console.WindowHeight)
                    continue;
                Console.SetCursorPosition(obj.position.x, obj.position.y);
                Console.BackgroundColor = obj.background;
                Console.ForegroundColor = obj.foreground;
                Console.Write(obj.visualReprezentation);
                Console.ResetColor();
            }
            Console.CursorVisible = false;
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