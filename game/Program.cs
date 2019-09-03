using System;
using Space.Datatypes;
using Space.Datatypes.View;
using Space.Logic;
using System.Threading;

namespace game
{
    class Player : ActorBase
    {
        private const int _height = 5;
        private const int _width = 5;

        public Player()
        {
            Name = "Test-chan";
            string pattern = "..#.." +
                             ".###." +
                             "#####" +
                             ".###." +
                             "#...#";

            Color = ConsoleColor.Yellow;
            Sprite = SpriteBase.FromPattern(pattern, 5, 5);
        }
    }

    /* ..#..    0,0 0,1 0,2 0,3 0,4
     * .###.    1,0 1,1 1,2 1,3 1,4
     * #####    2,0 2,1 2,2 2,3 2,4
     * .###.    3,0 3,1 3,2 3,3 3,4
     * #...#    4,0 4,1 4,2 4,3 4,4
     * */


    class Alien : ActorBase
    {
        private const int _height = 5;
        private const int _width  = 5;

        public Alien()
        {
            Name = "Alien";
        
            string pattern = "#...#"+
                             ".###."+
                             "#.#.#"+
                             ".###."+
                             "#...#";

            Color = ConsoleColor.Red;
            Sprite = SpriteBase.FromPattern(pattern, _height, _width);
        }


    }

    class Program
    {
        static Player player = new Player(){
            Hp    = 20,
            MaxHp = 20
        };
        static Alien alien = new Alien();
        static StatusWindow sw = new StatusWindow(10, 30);
        static StatusWindow mw = new StatusWindow(30, 30);
        static Map map = new Map(50, 100);

        static void Update()
        {
            Thread.Sleep(500);
            //Console.Clear();
            //map.Update(0, 0);
            map.RenderWithOffset(0, 0);
            sw.RenderWithOffset(50, 0);
            mw.RenderWithOffset(50, 9);
            player.RenderWithOffset(0, 0);
            alien.RenderWithOffset(0, 0);            
        }

        static void PrintMiniMap(string[] mapPattern)
        {
            mw.PrintText("Map", 0, 14, mw.Cells);
            int rowIndex = 4;
            foreach (var line in mapPattern)
            {
                mw.PrintText(line, rowIndex, 5, mw.Cells);
                rowIndex++;
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            sw.Text = $"Hp: {player.Hp} / {player.MaxHp}";
            player.X = 24;
            player.Y = 50;
            alien.X = alien.Y = 15;
            
            player.Color = ConsoleColor.Yellow;

            sw.PrintText(sw.Text, 3, 4, sw.Cells);
            sw.PrintText("qwerty", 5, 4, sw.Cells);
            sw.PrintText("yay", 1, 1, sw.Cells, true);
            string[] _map = {
                "####################",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "####################",
            };

            PrintMiniMap(_map);

            map.Update(0, 0);
            while (true)
            {
                Update();
                if (map.IsEmpty(player.X, player.Y - 1))
                    player.Move(0, -1);
                else 
                {
                    player.X = 24;
                    player.Y = 50;
                }
            }
        }
    }
}
