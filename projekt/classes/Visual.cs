using System;

namespace projekt
{
    class Visual
    {
        // reprezentacja wizualna
        public char visualReprezentation {get; private set;}
        // kolor tła
        public ConsoleColor background {get; private set;}
        // kolor czcionki
        public ConsoleColor foreground {get; private set;}

        public Visual(char visualReprezentation = 'O', 
        ConsoleColor background = ConsoleColor.Black, 
        ConsoleColor foreground = ConsoleColor.White)
        {
            this.visualReprezentation = visualReprezentation;
            this.background = background;
            this.foreground = foreground;
        }

        public void SetVisualRepresentation(char newVisual) => visualReprezentation = newVisual;
        public void SetBackground(ConsoleColor newColor) => background = newColor;
        public void SetForeground(ConsoleColor newColor) => foreground = newColor;

    }

}