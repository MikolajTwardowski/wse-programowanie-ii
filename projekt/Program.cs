using System;
using System.IO;

namespace projekt // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
            Console.Clear();
            //WindowDrawTest();
            //actor.Display();
            Scene mainScene = new Scene();
            
            Actor player = new Actor(
                new VisualRepresentation('#', ConsoleColor.DarkRed, ConsoleColor.Yellow), 
                new Transform(new IntVector2(5,5)));

            Actor actor1 = new Actor(
                new VisualRepresentation('#', ConsoleColor.Red, ConsoleColor.White), 
                new Transform(new IntVector2(10,10)));

            Actor actor2 = new Actor(
                new VisualRepresentation('#', ConsoleColor.Yellow, ConsoleColor.Red), 
                new Transform(new IntVector2(0,0)));

            mainScene.AddActor(player);
            mainScene.AddActor(actor1);
            mainScene.AddActor(actor2);

            Camera.Instance.RenderScene(mainScene);

            Console.ReadKey();
            }
        }

        static void WindowDrawTest()
        {
            char character = '#';
            //string screenOut = "";
            Console.ForegroundColor = ConsoleColor.Black;
            for(int x = 0; x < Console.WindowWidth; x++)
            {   
                if (x % 2 == 0) 
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }

                for(int y = 0; y < Console.WindowHeight - 1; y++)
                {
                    if (y % 2 == 0) 
                    {
                        character = '#';
                    }
                    else
                    {
                        character = '@';
                    }
                    //screenOut += character;
                    Console.SetCursorPosition(x,y);
                    Console.Write(character);
                }
            }

            //Console.Write(screenOut);
        }
    }
}