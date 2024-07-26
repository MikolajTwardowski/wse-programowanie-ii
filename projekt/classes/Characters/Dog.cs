using System;

namespace projekt
{
    class Dog: Character, IUpdatable
    {
        public Dog(Transform transform) : base(transform)
        {
            isAggressive = false;
            maxHitpoints = 3;
            _hitpoints = maxHitpoints;
            defence = 0;
            damage = 6;

            visual.SetVisualRepresentation('D');
            
        }

        public void Update()
        {
            // idź w losowy kierunek, dopuszczalne skosy
            TryMove(new IntVector2(Program.random.Next(-1,2),Program.random.Next(-1,2)));
        }
    }

}