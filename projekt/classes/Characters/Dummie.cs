using System;

namespace projekt
{
    class Dummie : Character, IUpdatable
    {
        public Dummie(Transform transform) : base(transform)
        {
            isAggressive = true;
            maxHitpoints = 1;
            _hitpoints = maxHitpoints;
            defence = 0;
            damage = 0;

            visual.SetVisualRepresentation('D');
        }

        public void Update()
        {

        }
    }

}