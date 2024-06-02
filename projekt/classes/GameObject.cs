using System;

namespace projekt
{
    class GameObject
    {
        #region Visual
        // reprezentacja wizualna
        public char visualReprezentation {get; private set;}
        // kolor tła
        public ConsoleColor background {get; private set;}
        // kolor czcionki
        public ConsoleColor foreground {get; private set;}

        #endregion
        
        #region Transform
        // pozycja
        public IntVector2 position {get; private set;}
        // zmiana pozycji?

        // dodaj wektor do pozycji
        void Move(IntVector2 vector) => position += vector; // to powinno być w innej formie - nie możesz iść bez sprawdzenia pozycji

        public void TryMove(IntVector2 vector)
        {
            GameObject other;
            if(Program.CheckCollisionOn(position + vector, out other))
            {
                Move(vector);
            }
            else
            {
                OnCollisionEnter(other);
            }
        }

        #endregion

        #region Constructors
        public GameObject(
            char visualReprezentation = '#', 
            ConsoleColor background = ConsoleColor.Black, 
            ConsoleColor foreground = ConsoleColor.White
            )
        {
            this.position = IntVector2.Zero;
            this.visualReprezentation = visualReprezentation;
            this.background = background;
            this.foreground = foreground;
        }

        public GameObject(
            IntVector2 position, 
            char visualReprezentation = '#', 
            ConsoleColor background = ConsoleColor.Black, 
            ConsoleColor foreground = ConsoleColor.White
            )
        {
            this.position = position;
            this.visualReprezentation = visualReprezentation;
            this.background = background;
            this.foreground = foreground;
        }

        #endregion

        #region IndividualLogic
        public virtual void OnCollisionEnter(GameObject other){}

        // Update
        public virtual void Update(){}
        #endregion
    }
}