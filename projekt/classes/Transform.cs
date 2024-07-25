using System;

namespace projekt
{
    class Transform
    {
        // pozycja
        public IntVector2 position {get; private set;}
        // zmiana pozycji - bo trzeba będzie teleportować przy przejściach
        public void SetNewPosition(IntVector2 position) => this.position = position;
        // dodaj wektor do pozycji
        public void Move(IntVector2 vector) => position += vector; // to powinno być w innej formie - nie możesz iść bez sprawdzenia pozycji

        public Transform()
        {
            this.position = IntVector2.Zero;
        }

        public Transform(IntVector2 position)
        {
            this.position = position;
        }
        
        public Transform(int x, int y)
        {
            this.position = new IntVector2(x,y);
        }
    }

}