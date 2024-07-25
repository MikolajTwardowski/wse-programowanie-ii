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
            
            TryMove(IntVector2.Down);
        }
    }

}