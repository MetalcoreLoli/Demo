using System;
using Space.Datatypes;

namespace Space.View
{
    public class Window
    {

        private int _windowWidth;
        private int _windowHeight;

        public Cell[] Cells;
        private Cell[] _text;

        private string _string_text;

        public int X { get; set; }
        public int Y { get; set; }

        public string Text
        {
            get => _string_text;
            set
            {
                _string_text = value;
                _text = new Cell[_string_text.Length];
                FillCellsBySymbols(_string_text, _text);
            }
        }


        public Window(int height, int width)
        {
            _windowWidth = width;
            _windowHeight = height;

            Cells = new Cell[_windowWidth * _windowHeight];
            Init(Cells);
        }

        public Window()
        {
            _windowWidth = 15;
            _windowHeight = 10;

            Cells = new Cell[_windowWidth * _windowHeight];
            Init(Cells);
        }

        private void Init(Cell[] cells)
        {
            for (int y = 0; y < _windowHeight; y++)
                for (int x = 0; x < _windowWidth; x++)
                {
                    cells[y * _windowWidth + x] = new Cell
                    {
                        Position = new Vector2i(x, y)  
                    };
                }

            for (int y = 0; y < _windowHeight; y++)
                for (int x = 0; x < _windowWidth; x++)
                {
                    if (y == 0 || y == _windowHeight - 1)
                        cells[y * _windowWidth + x].Symbol = '-';

                    if (x == 0 || x == _windowWidth - 1)
                        cells[y * _windowWidth + x].Symbol = '|';
                }

            for (int y = 0; y < _windowHeight; y++)
                for (int x = 0; x < _windowWidth; x++)
                {
                    if ((x == 0 && y == 0) || (x == 0 && y == _windowHeight - 1)
                            || (x == _windowWidth - 1 && y == 0) || (x == _windowWidth - 1 && y == _windowHeight - 1))
                        cells[y * _windowWidth + x].Symbol = '+';
                }
        }

        private Cell[] FillCellsBySymbols(string text, Cell[] cells)
        {
            for (int i = 0; i < text.Length; i++)
                cells[i] = new Cell
                {
                   Position = new Vector2i(){
                        X = i
                   }
                };

            for (int i = 0; i < text.Length; i++)
                cells[i].Symbol = text[i];
            return cells;
        }

        public void PrintText(string data, int row, int column, bool vertical = false)
        {
            if (row == 0) row++;
            if (column == 0) column++;

            if (data.Length - 1 < _windowWidth)
                if (!vertical)
                    for (int i = 0; i < data.Length; i++)
                        Cells[row  * _windowWidth + column + i].Symbol = data[i];
                else if (data.Length < _windowHeight && vertical) 
                    for (int i = 0; i < data.Length; i++)
                        Cells[(row + i) * _windowWidth + column].Symbol = data[i];
        }

        public void RenderWithOffset(int offsetX, int offsetY)
        {
            foreach (var cell in Cells)
                Render.WithOffset<Cell>(cell, X + offsetX, Y + offsetY);
        }
    }
}
