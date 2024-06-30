using System;

namespace projekt
{
    class Wall : GameObject
    {
        public Wall(IntVector2 position, 
            char visualReprezentation = '#', 
            ConsoleColor background = ConsoleColor.White, 
            ConsoleColor foreground = ConsoleColor.Black) : base(position, visualReprezentation, background, foreground)
        {

        }

        protected override void OnCollisionEnter(GameObject other)
        {
            
        }
        public override void Update()
        {
            
        }
    }

}