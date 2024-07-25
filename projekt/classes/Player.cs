using System;

namespace projekt
{
    class Player : Character, IUpdatable
    {
        /*
        public Player() : base()
        {
            //this.isAggressive = false;
            this._isAggressive = false;
            this.maxHitpoints = 5;
            this.hitpoints = maxHitpoints;
            this.damage = 3;
            this.defence = 2;

            visual.SetVisualRepresentation('P');
            visual.SetForeground(ConsoleColor.White);
        } */

        public Player(Transform transform) : base(transform)
        {
            this._isAggressive = true;
            this.maxHitpoints = 5;
            this.hitpoints = maxHitpoints;
            this.damage = 3;
            this.defence = 2;

            visual.SetVisualRepresentation('P');
            visual.SetForeground(ConsoleColor.White);
        }

        protected override void OnCollisionEnter(GameObject other)
        {
            if(other is Character character)
            {
                if(character.isAggressive)
                {
                    Attack(character);
                }
                else
                {
                    Talk(character);
                }
            }
        }
        public void Update()
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