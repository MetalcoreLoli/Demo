using System;
using Space.Datatypes;
using Space.View;

namespace Space.Datatypes
{
    public class Cell : IView 
    {
        int _x = 0, _y = 0;
        char _sym  = '.';

        public Vector2i Position { get; set; }

        public char Symbol { get => _sym; set => _sym = value; }        
    }
}
