using System;
using System.Data.Common;

namespace projekt
{
    class Sword : Item
    {
        public Sword(Transform transform) : base(transform)
        {
            this.id = 1;
            visual.SetVisualRepresentation('S');
        }

    }

}