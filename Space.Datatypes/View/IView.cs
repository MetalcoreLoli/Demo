using System;

namespace Space.Datatypes.View
{
    public interface IView 
    {
        int X { get; set; }
        int Y { get; set; }
        char Symbol { get; set; }
    }
}
