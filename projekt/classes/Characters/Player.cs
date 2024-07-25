using System;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace projekt
{
    class Player : Character, IUpdatable
    {
        public int potions {
            get { return _potions;}
            set 
            {
                if(value >= 0)
                    _potions = value;
            }
        }
        int _potions = 1;
        public Player(Transform transform) : base(transform)
        {
            this._isAggressive = false;
            this.maxHitpoints = 10;
            this.hitpoints = 3;
            this.damage = 3;
            this.defence = 2;
            
            visual.SetVisualRepresentation('P');
            visual.SetForeground(ConsoleColor.White);
        }

        protected override void OnCollisionEnter(GameObject other)
        {
            if(other is Item item)
            {
                switch(item.id) // rozpiska id powinna być w Item.cs
                {
                    case 0: // potion
                    potions += 1;
                    break; 
                    case 1: // sword
                    damage += 1;
                    break;
                    case 2: // helmet
                    defence += 1;
                    break; 
                    case 3: // trap
                    hitpoints -= 1;
                    break;
                    default:
                    break;
                }
                item.OnPickUp();
                transform.SetNewPosition(item.transform.position);
            }

            base.OnCollisionEnter(other);
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
            if(playerInput == ConsoleKey.H && _potions > 0)
            {
                hitpoints = maxHitpoints;
                potions -= 1;
            }

        }

        public void DrawStatistics()
        {
            Console.Write("HP {0}/{1}   Damage {2}   Defence {3}   Potions {4} (press \'H\' to use)", hitpoints, maxHitpoints, damage, defence, _potions);
        }
    }
}