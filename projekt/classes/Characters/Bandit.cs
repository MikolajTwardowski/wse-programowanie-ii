using System;
using System.Data;
using System.Runtime.InteropServices;

namespace projekt
{
    class Bandit : Character, IUpdatable
    {
        IntVector2 tresurePos;
        float detectionRange = 5;

        public Bandit(Transform transform, IntVector2 tresurePos) : base(transform)
        {
            isAggressive = true;
            maxHitpoints = 5;
            hitpoints = maxHitpoints;
            defence = Program.random.Next(4);
            damage = Program.random.Next(4);
            
            visual.SetVisualRepresentation('B');

            this.tresurePos = tresurePos;
            
            Item tresure;
            switch(Program.random.Next(4))
            {
                case 0:
                tresure = new Potion(new Transform(tresurePos));
                break;
                case 1:
                tresure = new Sword(new Transform(tresurePos));
                break;
                case 2:
                tresure = new Helmet(new Transform(tresurePos));
                break;
                case 3:
                tresure = new Trap(new Transform(tresurePos));
                break;
                default:
                break;
            }
        }

        public void Update()
        {
            int deltaX;
            int deltaY;
            // odległość do gracza < wykrywania | kierunek w stronę gracza
            if((Program.player.transform.position.x - transform.position.x) * (Program.player.transform.position.x - transform.position.x) + (Program.player.transform.position.y - transform.position.y) * (Program.player.transform.position.y - transform.position.y) <= detectionRange * detectionRange)
            {
                deltaX = Program.player.transform.position.x - transform.position.x;
                deltaY = Program.player.transform.position.y - transform.position.y;
            }
            else // kierunek w stronę skarbu
            {
                deltaX = tresurePos.x + Program.random.Next(-2, 3) - transform.position.x;
                deltaY = tresurePos.y + Program.random.Next(-2, 3) - transform.position.y;
            }


            if(deltaX * deltaX > deltaY * deltaY)
            {
                if(deltaX < 0)
                {
                    TryMove(IntVector2.Left);
                }
                else
                {
                    TryMove(IntVector2.Right);
                }
            }
            else
            {
                if(deltaY < 0)
                {
                    TryMove(IntVector2.Up);
                }
                else
                {
                    TryMove(IntVector2.Down);
                }
            }

        }
    }

}