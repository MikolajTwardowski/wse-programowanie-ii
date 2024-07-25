using System;
using System.Data;
using System.Runtime.InteropServices;

namespace projekt
{
    class Bandit : Character, IUpdatable
    {
        Random r = new Random();
        IntVector2 tresurePos;
        float detectionRange = 5;

        public Bandit(Transform transform, IntVector2 tresurePos) : base(transform)
        {
            isAggressive = true;
            maxHitpoints = 10;
            hitpoints = maxHitpoints;
            defence = 3;
            damage = 4;
            
            visual.SetVisualRepresentation('B');

            this.tresurePos = tresurePos;

            Item tresure = new Sword(new Transform(tresurePos));
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
                deltaX = tresurePos.x - transform.position.x;
                deltaY = tresurePos.y - transform.position.y;
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