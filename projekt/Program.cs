using System;

namespace projekt // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<GameObject> objects = new List<GameObject>();
        public static bool forcePlayerDeath = false;
        public static Player player = new Player(new Transform(new IntVector2((int)Console.WindowWidth/2, (int)Console.WindowHeight/2)));

        static void Main(string[] args)
        {
            while(true)
            {
                forcePlayerDeath = false;
                Wall wall1 = new Wall(new Transform(10,3));

                Bandit b1, b2, b3;
                b1 = new Bandit(new Transform(14, 25), new IntVector2(14 + 5, 25 + 3));
                b2 = new Bandit(new Transform(70, 25), new IntVector2(70 - 5, 25 -3));
                b3 = new Bandit(new Transform(70, 3), new IntVector2(70, 13));

                Dummie d1, d2, d3;
                d1 = new Dummie(new Transform(14, 6));
                d2 = new Dummie(new Transform(14, 7));
                d3 = new Dummie(new Transform(14, 8));

                Sword s1, s2, s3;
                s1 = new Sword(new Transform(50, 6));
                s2 = new Sword(new Transform(50, 7));
                s3 = new Sword(new Transform(50, 8));

                Helmet h1, h2, h3;
                h1 = new Helmet(new Transform(52, 6));
                h2 = new Helmet(new Transform(52, 7));
                h3 = new Helmet(new Transform(52, 8));

                Potion p1, p2, p3;
                p1 = new Potion(new Transform(54, 6));
                p2 = new Potion(new Transform(54, 7));
                p3 = new Potion(new Transform(54, 8));

                Trap t1, t2, t3;
                t1 = new Trap(new Transform(56, 6));
                t2 = new Trap(new Transform(56, 7));
                t3 = new Trap(new Transform(56, 8));

                Teleport teleport = new Teleport(new Transform((int)Console.WindowWidth/2, (int)Console.WindowHeight/2 - 1), new IntVector2(48, 6));
                
                Dog doggo = new Dog(new Transform(56, 3));

                while(Program.player.hitpoints > 0)
                {
                    RedrawScreen();
                    
                    // UI
                    Console.SetCursorPosition(0,0);
                    Program.player.DrawStatistics();

                    InvokeUpdateForUbdatables();
                    RemoveObjects();

                }
                objects = new List<GameObject>();
                player = new Player(new Transform(new IntVector2((int)Console.WindowWidth/2, (int)Console.WindowHeight/2)));
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
                    obj.transform.position.y < 1 || 
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

        public static void RemoveObjects()
        {
            for(int i = objects.Count - 1; i >= 0 ; i--)
            {
                if(objects[i] is Character character && objects[i] != Program.player)
                {
                    if(character.hitpoints <= 0)
                    {
                        objects.Remove(objects[i]);
                    }
                }
                else if (objects[i] is Item item)
                {
                    if(item.isPicekdUp == true)
                    {
                        objects.Remove(objects[i]);
                    }
                }
            }
        }

    }
}