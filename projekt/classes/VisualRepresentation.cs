using System;

namespace projekt
{
    class VisualRepresentation
    {
        char character;
        ConsoleColor displayColor;
        ConsoleColor backgroundColor;

        public VisualRepresentation(char character = '$', ConsoleColor displayColor = ConsoleColor.Black, ConsoleColor backgroundColor = ConsoleColor.Magenta)
        {
            this.character = character;
            this.displayColor = displayColor;
            this.backgroundColor = backgroundColor;
        }

        public void TryDisplayAtPosition(IntVector2 position)
        {
            if(position.x < 0 || position.x >= Console.WindowWidth || position.y < 0 || position.y >= Console.WindowHeight)
                return;
            Console.SetCursorPosition(position.x, position.y);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = displayColor;
            Console.Write(character);
            Console.ResetColor();
        }
    }
}