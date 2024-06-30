using System;

namespace projekt
{
    class Player : GameObject
    {
        public Player(IntVector2 position, 
            char visualReprezentation = 'P', 
            ConsoleColor background = ConsoleColor.Black, 
            ConsoleColor foreground = ConsoleColor.White) : base(position, visualReprezentation, background, foreground)
        {}

        protected override void OnCollisionEnter(GameObject other)
        {
            if(other is Wall)
            {
                Console.Write("\nOjej, ściana. ");
                Console.ReadKey(true);
            }
            //else if (other is ...)
        }
        public override void Update()
        {
            ConsoleKey playerInput = Console.ReadKey(true).Key;

            if(playerInput == ConsoleKey.W || playerInput == ConsoleKey.UpArrow)
                TryMove(IntVector2.Up);

            if(playerInput == ConsoleKey.S || playerInput == ConsoleKey.DownArrow)
                TryMove(IntVector2.Down);

            if(playerInput == ConsoleKey.D || playerInput == ConsoleKey.RightArrow)
                TryMove(IntVector2.Right);

            if(playerInput == ConsoleKey.A || playerInput == ConsoleKey.LeftArrow)
                TryMove(IntVector2.Left);

        }

    }
}