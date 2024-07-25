using System;
using System.Data.Common;

namespace projekt
{
    class Trap : Item
    {
        public Trap(Transform transform) : base(transform)
        {
            this.id = 3;
            visual.SetVisualRepresentation('T');
        }

    }

}