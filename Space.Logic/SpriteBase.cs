using System;
using Space.Datatypes;


namespace Space.Logic
{
    public class SpriteBase : ISprite
    {
        public Cell[] _spriteToDraw;
        
        public SpriteBase(string pattern)
        {
            _spriteToDraw = CreateFromPattern(pattern, 5, 5);
        }

        public SpriteBase()
        {
        
        }

        public Cell[] CreateFromPattern(string pattern, int height, int width) 
        {
        
            _spriteToDraw = new Cell[height * width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    _spriteToDraw[y * width + x] = new Cell
                    {
                        Position = new Vector2i(x, y)
                    };
                }
            for (int i = 0; i < width * height; i++)
            {
                if (pattern[i] == '.')
                  _spriteToDraw[i].Symbol = ' '; 
                else 
                   _spriteToDraw[i].Symbol = pattern[i];
            }
            return _spriteToDraw;
        }

        public static SpriteBase FromPattern(string pattern, int height, int width)
        {
            var spriteToDraw = new Cell[height * width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                     spriteToDraw[y * width + x] = new Cell
                    {
                        Position = new Vector2i(x ,y)
                    };

                }
            for (int i = 0; i < width * height; i++)
            {
                if (pattern[i] == '.')
                   spriteToDraw[i].Symbol = ' '; 
                else 
                    spriteToDraw[i].Symbol = pattern[i];
            }
           return  new SpriteBase() {
                _spriteToDraw = spriteToDraw
           };
        }
        public Cell[] Get() => this._spriteToDraw;
    }
}

