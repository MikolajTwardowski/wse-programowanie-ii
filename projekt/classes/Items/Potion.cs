using System;
using System.Data.Common;

namespace projekt
{
    class Potion : Item
    {
        public Potion(Transform transform) : base(transform)
        {
            this.id = 0;
            visual.SetVisualRepresentation('P');
        }

    }

}