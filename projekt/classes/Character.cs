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
                    visual.SetForeground(ConsoleColor.Green);
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
                if(_hitpoints <= 0)
                {
                    OnDeath();
                }
            }
        }
        protected float _hitpoints;
        public float damage{get; protected set;}
        public float defence{get; protected set;}


        public Character() : base()
        {
            /*
            this.isAggressive = true;
            this.maxHitpoints = 3;
            this._hitpoints = maxHitpoints;
            this.damage = 1;
            this.defence = 0;
            */
        }

        public Character(Transform transform) : base(transform)
        {
            /*
            this.isAggressive = true;
            this.maxHitpoints = 3;
            this._hitpoints = maxHitpoints;
            this.damage = 1;
            this.defence = 0;
            */
        }

        public void Attack(Character character)
        {
            if(damage > character.defence)
                character.hitpoints -= damage - character.defence;
        }

        public void Talk(Character character)
        {
            Console.WriteLine("bla, bla, bla");
            Console.ReadKey(true);
        }

        protected virtual void OnDeath()
        {
            //Program.objects.Remove(this);
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
                    else
                    {
                        Talk(character);
                    }
                }

            }
        }

    }


}