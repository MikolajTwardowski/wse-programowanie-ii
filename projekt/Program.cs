using System;

namespace projekt // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<GameObject> objects = new List<GameObject>();
        public static Player player = new Player(new Transform(new IntVector2((int)Console.WindowWidth/2, (int)Console.WindowHeight/2)));

        public static Random random = new Random();
        static void Main(string[] args)
        {
            while(true)
            {
                // bad tutorial xD
                Console.Clear();
                Console.SetCursorPosition(0,0);
                Console.WriteLine("Witamy Cię w tym dzikim rogueliku! ");
                Console.WriteLine();
                Console.WriteLine("Sterowanie: ");
                Console.WriteLine("Idź w Prawo (D) (ArrowRight)");
                Console.WriteLine("Idź w Lewo (A) (ArrowLeft)");
                Console.WriteLine("Idź w Góra (W) (ArrowUp)");
                Console.WriteLine("Idź w Dół (S) (ArrowDown)");
                Console.WriteLine("Użyj potki na HP (H)");
                Console.WriteLine("Wyłącz grę (ALT + F4) *tylko windows :P");
                Console.WriteLine();
                Console.WriteLine("Jeśli chcesz z czymś wejść w interakcję, to spróbuj na tym stanąć. ");
                Console.WriteLine();
                Console.WriteLine("Biały kolor wskazuje postaci neutralne: ");
                Console.WriteLine("(D) Dog, możesz porozmawiać z pieskiem. ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Czerwonym kolorem są oznaczeni przeciwnicy. ");
                Console.WriteLine("(B) Bandit, patroluje okolice swojego skarbu, ale zacznie Cię gonić jeśli się zbliżysz. ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Żółty to przedmioty: ");
                Console.WriteLine("(P) Potion na HP");
                Console.WriteLine("(S) Sword, zwiększa zadawane obrażenia");
                Console.WriteLine("(H) Helmet, zwiększa pancerz");
                Console.WriteLine("(T) Trap, tracisz 1 HP");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Są tutaj też (T) Teleporty. \nPrzeniosą Cię na pozycję odbicia pozycji portalu względem środka mapy. ");
                Console.ResetColor();

                Console.ReadKey(true);

                int seed = random.Next();
                random = new Random(seed);

                int temp;
                // stopień zapełnienia (5%)
                for(int i = (int) (Console.WindowWidth * Console.WindowHeight * 0.05); i > 0; i--)
                {
                    IntVector2 position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    while(CheckCollisionOn(position, out temp))
                    {
                        position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    }
                    
                    Tree tree = new Tree(new Transform(position));
                }
                
                // 0.5% Zbiry
                for(int i = (int) (Console.WindowWidth * Console.WindowHeight * 0.05); i > 0; i--)
                {
                    IntVector2 position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    while(CheckCollisionOn(position, out temp))
                    {
                        position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    }
                    
                    Bandit bandit = new Bandit(new Transform(position), position + new IntVector2(random.Next(-10, 111), random.Next(-10, 11)));
                }

                // 0.25% przedmioty
                for(int i = (int) (Console.WindowWidth * Console.WindowHeight * 0.025); i > 0; i--)
                {
                    IntVector2 position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    while(CheckCollisionOn(position, out temp))
                    {
                        position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    }
                    
                    Item tresure;
                    switch(Program.random.Next(4))
                    {
                        case 0:
                        tresure = new Potion(new Transform(position));
                        break;
                        case 1:
                        tresure = new Sword(new Transform(position));
                        break;
                        case 2:
                        tresure = new Helmet(new Transform(position));
                        break;
                        case 3:
                        tresure = new Trap(new Transform(position));
                        break;
                        default:
                        break;
                    }
                }

                // Pieski zapełnienia (1%) mapy
                for(int i = (int) (Console.WindowWidth * Console.WindowHeight * 0.01); i > 0; i--)
                {
                    IntVector2 position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    while(CheckCollisionOn(position, out temp))
                    {
                        position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    }
                    
                    Dog dog = new Dog(new Transform(position));
                }

                // teleporty 
                for(int i = 4; i > 0; i--)
                {
                    IntVector2 position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    while(CheckCollisionOn(position, out temp))
                    {
                        position = new IntVector2(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
                    }
                    
                    // pozycja odbita względem punktu środka mapy
                    IntVector2 altPosition = new IntVector2(Console.WindowWidth - position.x, Console.WindowHeight - position.y);

                    Teleport teleport = new Teleport(new Transform(position), altPosition);
                }


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

        public static bool CheckCollisionOn(IntVector2 position, out int index)
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
