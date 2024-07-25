using System;
using System.Data.Common;

namespace projekt
{
    class Helmet : Item
    {
        public Helmet(Transform transform) : base(transform)
        {
            this.id = 2;
            visual.SetVisualRepresentation('H');
        }

    }

}