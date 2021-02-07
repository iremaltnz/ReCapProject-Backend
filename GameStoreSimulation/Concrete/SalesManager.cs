using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class SalesManager: IOperationsManager
    {
        public void Sales(Game game, Gamer gamer)
        {
            Console.WriteLine(game.Name+"isimli oyun "+gamer.FirstName+" "+gamer.LastName+" tarafından "+game.Price+" TL fiyatina satin alinmıştir.");
            Console.WriteLine("\n");
        }

        public void Sales(Game game, Gamer gamer,Campaign campaign)
        {
            Console.WriteLine(game.Name + "isimli oyun " + gamer.FirstName + " " + gamer.LastName + " tarafindan "+ campaign.Name+" sebebiyle %"+campaign.CampaignRate+" indirimli fiyati olan" +
                  (game.Price)*(0.01*campaign.CampaignRate) + " TL fiyatına satın alınmıştır.");

            Console.WriteLine("\n");
        }
    }
}
