using System;
using System.Collections.Generic;

namespace Space.Datatypes.View
{
    public class Render
    {
        private IView obj;

        public Render(IView obj)
        {
            this.obj = obj;
        }   

        public void WithOffset(int offsetX, int offsetY)
        {
            int pLeft = Console.CursorLeft;
            int pTop = Console.CursorTop;
            Console.CursorVisible = false;
            
            Console.SetCursorPosition(obj.X + offsetX, obj.Y + offsetY);
            Console.Write(obj.Symbol);
            
            Console.SetCursorPosition(pLeft, pTop);
            Console.CursorVisible = true;
        }
        
        public void WithOutOffset() => 
            WithOffset(0, 0);

        public static void WithOffset<T>(T obj, int offsetX, int offsetY) where T : IView 
        {
            int pLeft = Console.CursorLeft;
            int pTop = Console.CursorTop;
            Console.CursorVisible = false;
            
            Console.SetCursorPosition(obj.X + offsetX, obj.Y + offsetY);
            Console.Write(obj.Symbol);
            
            Console.SetCursorPosition(pLeft, pTop);
            Console.CursorVisible = true;

        }

        public static void WithOutOffset<T>(T obj) where T : IView 
        {
            int pLeft = Console.CursorLeft;
            int pTop = Console.CursorTop;
            Console.CursorVisible = false;
            
            Console.SetCursorPosition(obj.X, obj.Y);
            Console.Write(obj.Symbol);
            
            Console.SetCursorPosition(pLeft, pTop);
            Console.CursorVisible = true;
        }
    }
}
