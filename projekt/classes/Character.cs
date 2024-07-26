using System;

namespace projekt
{
    class Character: GameObject
    {
        public bool isAggressive
        {
            get {return _isAggressive;}

            set 
            {
                if(value)
                {
                    visual.SetForeground(ConsoleColor.Red);
                }
                else
                {
                    visual.SetForeground(ConsoleColor.White);
                }
                _isAggressive = value;
            }
        }
        protected bool _isAggressive;
        public float maxHitpoints {get; protected set;}
        public float hitpoints
        {
            get
            {
                return _hitpoints;
            }

            set
            {
                _hitpoints = value;
                if(_hitpoints <= 0) // ostatecznie nie używane, ale można dorobić spawnowanie / przenoszenie przedmiotów po śmierci pod pozycję pokonanego
                {

                }
            }
        }
        protected float _hitpoints;
        public float damage{get; protected set;}
        public float defence{get; protected set;}

        public Character(Transform transform) : base(transform)
        {

        }

        public void Attack(Character character)
        {
            if(damage > character.defence)
                character.hitpoints -= damage - character.defence;
        }

        public virtual void Talk(Character character)
        {
            Console.WriteLine("bla, bla, bla");
            Console.ReadKey(true);
        }

        protected void TryMove(IntVector2 vector)
        {
            int index;
            if(Program.CheckCollisionOn(transform.position + vector, out index))
            {
                OnCollisionEnter(Program.objects[index]);
            }
            else
            {
                transform.Move(vector);
            }
        }

        // logika kolizji (ten obiekt natrafia na inny podczas próby ruchu)
        protected virtual void OnCollisionEnter(GameObject other)
        {
            if(other is Character character)
            {
                if(isAggressive)
                    Attack(character);
                else
                {
                    if(character.isAggressive)
                    {
                        Attack(character);
                    }

                }
            }
            else if (other is Teleport teleport)
            {
                transform.SetNewPosition(teleport.destination);
            }
        }

    }


}