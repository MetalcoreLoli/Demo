using System;

namespace Space.View
{
    public interface IView 
    {
        Space.Datatypes.Vector2i Position { get; set; }
        char Symbol { get; set; }
    }
}
