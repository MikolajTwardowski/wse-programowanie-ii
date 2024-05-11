using System;
using System.IO;

namespace projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scene mainScene = new Scene();
            TestMainSceneSetup(mainScene);

            while(true)
            {
                Camera.Instance.RenderScene(mainScene);

                TestCameraInput();
            }
        }

        static void TestCameraInput() // Camera Offset
        {
            ConsoleKey keyInfo = Console.ReadKey().Key;

            if(keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                Camera.Instance.offset += IntVector2.Up;

            if(keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                Camera.Instance.offset += IntVector2.Down;

            if(keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                Camera.Instance.offset += IntVector2.Right;

            if(keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                Camera.Instance.offset += IntVector2.Left;
        }
        

        static void TestMainSceneSetup(Scene mainScene)
        {
            Actor player = new Actor(
                new VisualRepresentation('#', ConsoleColor.DarkRed, ConsoleColor.Yellow), 
                new Transform(new IntVector2(5,5)));

            Actor actor1 = new Actor(
                new VisualRepresentation('@', ConsoleColor.Red, ConsoleColor.White), 
                new Transform(new IntVector2(10,10)));

            Actor actor2 = new Actor(
                new VisualRepresentation('%', ConsoleColor.Yellow, ConsoleColor.Red), 
                new Transform(new IntVector2(0,0)));

            mainScene.AddActor(player);
            mainScene.AddActor(actor1);
            mainScene.AddActor(actor2);
        }
    }
}