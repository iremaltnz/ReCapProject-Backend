using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class GameManager: IOperationsManager
    {
        List<Game> games;
        Game _game;
        public GameManager()
        {
            games = new List<Game> { };
        }

        public void Add(Game game)
        {
            games.Add(game);
        }

        public void Update(Game game)
        {
            foreach (Game g in games)
            {
                if (g.Id == game.Id) _game = g;
            }

            _game.Id = game.Id;
            _game.Name = game.Name;
            _game.Price = game.Price;
            _game.SystemRequirements = game.SystemRequirements;

            Console.WriteLine("\nOyun bilgileri güncellendi. Yeni bilgiler:\nId=" + _game.Id + "\nName=" + _game.Name + "\nPrice=" + _game.Price+ "\nSystem Requirements=" + _game.SystemRequirements+"\n"
           );
        }

        public void Delete(Game game)
        {
            foreach (Game g in games)
            {
                if (g.Id == game.Id) _game = g;
            }

            games.Remove(_game);
            Console.WriteLine(_game.Name+" isimli oyun sistemden silindi.\n");
        }

        public void List()
        {
            int temp = 1;
            Console.WriteLine("---------Game List--------------");

            foreach (Game g in games)
            {
               Console.WriteLine("Game "+temp+":\nId="+g.Id + "\nName=" + g.Name + "\nPrice=" + g.Price+ "\nSystem Requirements" + g.SystemRequirements);
               temp++;
               Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }
    }
}
