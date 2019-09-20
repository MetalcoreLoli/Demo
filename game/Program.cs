using System;
using System.Collections.Generic;
using Space.Datatypes;
using Space.View;
using Space.Logic;
using System.Threading;

namespace game
{
    interface IHitable
    {
        float Hp { get; set; }
        float MaxHp { get; set; }
    }

    class GameMap : Map
    {

        public List<ActorBase> Actors { get; set; }

        public GameMap(int width, int height)
            : base(width, height)
        {
            Actors = new List<ActorBase>();    
        }
        
        public void Update() 
        {
            foreach(var elem in Actors)
            {
                for(int i = 0; i < Cells.Length; i++)
                {
                    for (int j = 0; j < elem.Sprite.Get().Length - 1; j++)
                    {
                        if (Cells[i].Position == elem.Sprite.Get()[j].Position)
                        {
                            Cells[i].Symbol = elem.Sprite.Get()[j].Symbol; 
                        }
                    }
                }
            }
            this.RenderWithOffset(0, 0);
        }

    }

    class Player : ActorBase, IHitable
    {

        public float Hp { get; set; }
        public float MaxHp { get; set; }


        private const int _height = 5;
        private const int _width = 5;

        public Player()
        {
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
        private const int _width = 5;

        public Alien()
        {
            string pattern = "#...#" +
                             ".###." +
                             "#.#.#" +
                             ".###." +
                             "#...#";

            Color = ConsoleColor.Red;
            Sprite = SpriteBase.FromPattern(pattern, _height, _width);
        }


    }

    class Program
    {
        static Player player = new Player()
        {
            Hp = 20,
            MaxHp = 20
        };
        static Alien alien = new Alien();
        static Window sw = new Window(10, 30);
        static Window mw = new Window(30, 30);
        static GameMap map = new GameMap(50, 50);

        static void Update()
        {
            Thread.Sleep(500);
            map.Update();
            map.RenderWithOffset(0, 0);
            sw.RenderWithOffset(50, 0);
            mw.RenderWithOffset(50, 9);
            sw.PrintText($"Players Hp: {player.Hp} / {player.MaxHp}", 5, 4);
            player.IsInFov(alien);
            //player.RenderWithOffset(0, 0);
            alien.RenderWithOffset(0, 0);
        }

        static void PrintMiniMap(string[] mapPattern)
        {
            mw.PrintText("Map", 0, 14);
            int rowIndex = 4;
            foreach (var line in mapPattern)
            {
                mw.PrintText(line, rowIndex, 5);
                rowIndex++;
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            player.Position = new Vector2i(15, 25);
            alien.Position = new Vector2i(15, 15);

            player.Color = ConsoleColor.Yellow;

            sw.PrintText("yay", 1, 1, true);
            map.Actors.Add(player);
            map.Update(0, 0);
            while (true)
            {
                Update();
                if (map.IsEmpty(player.Position.X, player.Position.Y - 1))
                    player.Move(new Vector2i(0, -1));
                else
                    player.Position = new Vector2i(15, 25);

                if (alien.Position == player.Position)
                {
                    player.Hp--;
                    player.Move(new Vector2i(0, 1));
                    mw.PrintText("Player was hit", 5, 2);
                }

            }
        }
    }
}
