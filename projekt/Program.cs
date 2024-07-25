using System;

namespace projekt // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<GameObject> objects = new List<GameObject>();

        static void Main(string[] args)
        {
            while(true)
            {
                Player player = new Player(new Transform(new IntVector2((int)Console.WindowWidth/2, (int)Console.WindowHeight/2)));

                Wall wall1 = new Wall(new Transform(10,3));

                Dummie d1, d2, d3;
                d1 = new Dummie(new Transform(14, 6));
                d2 = new Dummie(new Transform(14, 7));
                d3 = new Dummie(new Transform(14, 8));
                
                Dog doggo = new Dog(new Transform(12, 8));

                while(player.hitpoints >= 0)
                {
                    RedrawScreen();
                    
                    Console.SetCursorPosition(0,0);
                    Console.Write(player.hitpoints + " / " + player.maxHitpoints);

                    InvokeUpdateForUbdatables();
                    RemoveDeadCharacters();


                }
                objects = new List<GameObject>();
                Console.Clear();
                Console.Write("Grałeś swoim i zginął! Zaczynaj od nowa!");
                Console.ReadKey();
            }
        }

        static void InvokeUpdateForUbdatables()
        {
            foreach(var obj in objects)
            {
                if(obj is IUpdatable ubdatable)
                    ubdatable.Update();
            }
        }

        static void RedrawScreen()
        {
            Console.Clear();
            foreach(var obj in objects)
            {
                if( obj.transform.position.x < 0 || 
                    obj.transform.position.x >= Console.WindowWidth || 
                    obj.transform.position.y < 0 || 
                    obj.transform.position.y >= Console.WindowHeight)
                    continue;
                Console.SetCursorPosition(obj.transform.position.x, obj.transform.position.y);
                Console.BackgroundColor = obj.visual.background;
                Console.ForegroundColor = obj.visual.foreground;
                Console.Write(obj.visual.visualReprezentation);
                Console.ResetColor();
            }

            Console.CursorVisible = false;
        }

        public static bool CheckCollisionOn(IntVector2 position, out int index) // jeśli tu będzie tlyko game object to mi się wysra przy sprawdzaniu ruchu xD
        {
            index = -1;
            foreach(var obj in Program.objects)
            {
                if(obj.transform.position == position)
                {
                    index = objects.IndexOf(obj);
                    return true;
                }
            }
            
            return false;
        }

        public static void RemoveDeadCharacters()
        {
            for(int i = objects.Count - 1; i >= 0 ; i--)
            {
                if(objects[i] is Character character)
                {
                    if(character.hitpoints <= 0)
                    {
                        objects.Remove(objects[i]);
                    }
                }
            }
        }

    }
}