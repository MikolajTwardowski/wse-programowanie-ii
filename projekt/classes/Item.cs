using System;
using System.Data.Common;

namespace projekt
{
    class Item : GameObject
    {
        public bool isPicekdUp = false;
        public int id = -1;
        /*
        plx Don't Judge Me
        id:
        -1 -> none
        0 -> potion
        1 -> sword
        2 -> helmet
        3 -> trap

        */

        public Item(Transform transform): base(transform)
        {
            visual.SetForeground(ConsoleColor.Yellow);
        }

        public virtual void OnPickUp()
        {
            isPicekdUp = true;
        }

    }

}