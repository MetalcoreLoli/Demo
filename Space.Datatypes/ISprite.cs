using System;

namespace Space.Datatypes
{
    public interface ISprite
    {
        Cell[] CreateFromPattern(string pattern, int height, int width);
    }
}
