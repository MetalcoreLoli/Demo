using System;
using Space.Datatypes;
using Space.View;

namespace Space.Datatypes
{
    public class Cell : IView 
    {
        int _x = 0, _y = 0;
        char _sym  = '.';

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public char Symbol { get => _sym; set => _sym = value; }        
    }
}
