using System;
using Space.Datatypes;

namespace Space.View
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private int _bufferHeight;
        public Cell[] Buffer { get; set; }
        public Cell[] Cells { get; set; }

        public string Pattern { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        private Cell[] EmptyCells;

        public Map(int width, int height)
        {
            X = Y = 0;
            Width = width;
            Height = height;
            _bufferHeight = Height * 2;
            EmptyCells = new Cell[Height * Width];

            Buffer = InitMap(_bufferHeight, Width);
            Cells  = InitMap(height, width);

        }

        public Map(int width, int height, int x, int y)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            EmptyCells = new Cell[Height * Width];

            Cells = InitMap(height, width);
        }

        private Cell[] InitMap(int height, int width)
        {
            var cells = new Cell[height * width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    cells[y * width + x] = new Cell
                    {
                        Position = new Vector2i(x, y),  
                        Symbol = ' '
                    };

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1) cells[y * width + x].Symbol = '|';
                    if (y == 0 || y == height - 1) cells[y * width + x].Symbol = '-';
                }
            return cells;
        }
        
        private Cell[] FillByEmptyCells()
        {
            return null;
        }

        public void Update(int offsetX, int offsetY)
        {
            for (int y = 1; y < Height - 1; y++)
                for (int x = 1; x < Width - 1; x++)
                {
                   /* EmptyCells[y * Width - 1 + x] = new Cell
                    {
                        X = x,
                        Y = y,
                        Symbol = ' '
                    };*/
                }
            /*if (EmptyCells != null)
                foreach (var cell in EmptyCells)
                    Render.WithOffset(cell, X + offsetX, Y + offsetY);*/
        }

        public void RenderWithOffset(int offsetX, int offsetY)
        {
            foreach (var cell in Cells)
                Render.WithOffset(cell, X + offsetX, Y + offsetY);
        }

        public bool IsEmpty(int x, int y)
        {
            if (GetCell(x, y).Symbol == ' ')
                return true;
            else
                return false;
        }

        public Cell GetCell(int x, int y)
            => Cells[y * Width + x];
    }
}
