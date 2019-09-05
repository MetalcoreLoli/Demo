using System;

namespace Space.Datatypes
{
    public class Vector2i
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2i() {}
        public Vector2i (int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Vector2i operator +(Vector2i v, Vector2i vv)
        {
            return new Vector2i()
            {
                X = v.X + vv.X,
                Y = v.Y + vv.Y
            };
        }

        public static Vector2i operator -(Vector2i v, Vector2i vv)
        {
            return new Vector2i(){ X = v.X - vv.X, Y = v.Y - vv.Y };
        }

        public static Vector2i Scale(Vector2i v, int scale)
            => new Vector2i(){ X = v.X * scale, Y = v.Y * scale };
    }
}
