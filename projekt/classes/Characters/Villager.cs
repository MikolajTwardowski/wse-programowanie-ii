using System;

namespace projekt
{
    class Villager : Character, IUpdatable
    {
        IntVector2 patrolingPoint;
        Random r = new Random();
        public Villager(Transform transform, IntVector2 patrolingPoint) : base(transform)
        {
            isAggressive = false;
            maxHitpoints = 10;
            hitpoints = maxHitpoints;
            defence = 3;
            damage = 2;
            
            visual.SetVisualRepresentation('V');

            this.patrolingPoint = patrolingPoint;
        }

        public void Update()
        {
            int deltaX = patrolingPoint.x + r.Next(-2, 3) - transform.position.x;
            int deltaY = patrolingPoint.y + r.Next(-2, 3) - transform.position.y;

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