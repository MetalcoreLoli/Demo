using System;
using Space.Datatypes;
using Space.View;

namespace Space.Logic
{
    public abstract class ActorBase : IView
    {
        int _x = 0, _y = 0;
        char _symbols = ' ';

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public char Symbol { get => _symbols; set => _symbols = value; }

        public string Name { get; set; }

        public int Hp { get; set; }

        public int MaxHp { get; set; }

        public float Damage { get; set; }

        public SpriteBase Sprite { get; set; }

        public ConsoleColor Color { get; set; }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public void RenderWithOffset(int offsetX, int offsetY)
        {
            Console.ForegroundColor = Color;
            foreach(var cell in Sprite.Get())
                Render.WithOffset<Cell>(cell, X + offsetX, Y + offsetY);        
            Console.ResetColor();
        }
    }
}

