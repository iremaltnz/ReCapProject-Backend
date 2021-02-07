using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class GamerManager: IOperationsManager
    {
        List<Gamer> gamers;
        Gamer _gamer = new Gamer();
        
        public GamerManager()
        {
            gamers =new List<Gamer> { } ;
        }

        public void Add(Gamer gamer)
        {
            gamers.Add(gamer);
            Console.WriteLine(gamer.FirstName+" "+gamer.LastName+" isimli oyuncu sisteme eklendi.");
            IVerificationService verificationService = new EDevletVerificationManager();
            if (verificationService.Dogrulama(gamer))
            {
                Console.WriteLine(gamer.FirstName+" isimli oyuncu dogrulandi");
            }
            else
            {
                throw new Exception("Not a valid person");
            }
          
            Console.WriteLine("\n");

        }

        public void Update(Gamer gamer)
        {
            foreach  (Gamer g in gamers)
            {
                if (g.Id == gamer.Id) _gamer = g; 
            }

 
            _gamer.TcNum = gamer.TcNum;
            _gamer.FirstName = gamer.FirstName;
            _gamer.LastName = gamer.LastName;
            _gamer.BirtYear = gamer.BirtYear;

            Console.WriteLine("\nOyuncu bilgileri güncellendi. Yeni bilgiler:\nId=" +_gamer.Id + "\nTcNum=" + _gamer.TcNum + "\nFirsName=" + _gamer.FirstName + "\nLastName=" + _gamer.LastName + "\nBirth Year=" + _gamer.BirtYear+"\n"
            );
        }

        public void Delete(Gamer gamer)
        {
            foreach (Gamer g in gamers)
            {
                if (g.Id == gamer.Id) _gamer = g;
            }

            gamers.Remove(_gamer);
            Console.WriteLine(_gamer.FirstName+" "+_gamer.LastName+" isimli oyuncu sistemden silindi.\n");
        }

        public void List( )
        {
            int temp = 1;
            Console.WriteLine("------------Gamer List------------");
            foreach (Gamer g in gamers)
            {
                Console.WriteLine("Gamer "+temp+":\nId="+g.Id+"\nTcNum="+g.TcNum+ "\nFirsName="+g.FirstName+"\nLastName="+g.LastName+"\nBirth Year="+ g.BirtYear);
                temp++;
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }
    }
}
