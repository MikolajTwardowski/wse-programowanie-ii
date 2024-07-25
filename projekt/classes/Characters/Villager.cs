using System;

namespace projekt
{
    class Villager : Character, IUpdatable
    {
        public Villager(Transform transform, IntVector2 patrolingPoint) : base(transform)
        {
            isAggressive = false;
            maxHitpoints = 10;
            hitpoints = maxHitpoints;
            defence = 3;
            damage = 2;
            
            visual.SetVisualRepresentation('V');
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

}