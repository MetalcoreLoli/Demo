using System;
using Space.Datatypes;
using Space.View;

namespace Space.Logic
{
    public abstract class ActorBase : IView
    {
        int _x = 0, _y = 0;
        char _symbols = ' ';

        Vector2i _pos;
        
        public Vector2i Position { get => _pos; set => _pos = value; }

        public char Symbol { get => _symbols; set => _symbols = value; }

        public string Name { get; set; }

        public int Hp { get; set; }

        public int MaxHp { get; set; }

        public float Damage { get; set; }

        public float FovX { get; set; }

        public float FovY { get; set; }

        public SpriteBase Sprite { get; set; }

        public ConsoleColor Color { get; set; }

        public void Move(Vector2i move)
        {
            Position += move; 
        }

        public void RenderWithOffset(int offsetX, int offsetY)
        {
            Console.ForegroundColor = Color;
            foreach (var cell in Sprite.Get())
                Render.WithOffset<Cell>(cell, Position.X + offsetX, Position.Y + offsetY);
            Console.ResetColor();
        }

        public virtual bool IsInFov(ActorBase actor)
        {
            return 1 < 25;
        }
    }
}

