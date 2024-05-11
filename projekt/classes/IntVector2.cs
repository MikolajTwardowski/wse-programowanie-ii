using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace projekt
{
    class IntVector2
    {
        public static readonly IntVector2 Zero = new IntVector2(0,0);
        public static readonly IntVector2 Up = new IntVector2(0,-1);
        public static readonly IntVector2 Down = new IntVector2(0,1);
        public static readonly IntVector2 Left = new IntVector2(-1,0);
        public static readonly IntVector2 Right = new IntVector2(1,0);
        public int x;
        public int y;

        public IntVector2(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public static IntVector2 operator +(IntVector2 a) => a;
        public static IntVector2 operator -(IntVector2 a) => new IntVector2(-a.x, -a.y);

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        => new IntVector2(a.x * b.x, a.y + b.y);

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        => a + (-b);

        public static bool operator ==(IntVector2 a, IntVector2 b)
        => (a.x == b.x && a.y == b.y);

        public static bool operator !=(IntVector2 a, IntVector2 b)
        => !(a == b);
    }
}