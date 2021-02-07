using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer1 = new Gamer {Id=1, TcNum="111111111",FirstName ="İrem",LastName="Altnz",BirtYear=2001 };
            Gamer gamer2 = new Gamer { Id=2,TcNum="222222222",FirstName="Nusret",LastName="Altnz",BirtYear=1965};

            GamerManager gamerManager = new GamerManager ();
            gamerManager.Add(gamer1);
            gamerManager.Add(gamer2);
            gamerManager.List();

            Game game1 = new Game {Id=1, Name= "LEAGUE OF LEGENDS",Price=100, SystemRequirements= "Onerilen Sistem Gereksinimleri : Core 2 Duo E6850 3.0GHz işlemci , 4 GB RAM " };
            Game game2 = new Game { Id=2,Name="PUBG",Price=50,SystemRequirements= "Onerilen Sistem Gereksinimleri : Core i5-6400 2.7GHz işlemci , 8 GB RAM" };

            GameManager gameManager = new GameManager();
            gameManager.Add(game1);
            gameManager.Add(game2);
            gameManager.List();

            Campaign campaign1 = new Campaign { Id=1,Name="Yeni Yil Kampanyası",CampaignRate=50};
            Campaign campaign2 = new Campaign { Id = 2, Name = "Black Friday Kampanyasi", CampaignRate = 60 };

            CampaignManager campaignManager = new CampaignManager();
            campaignManager.Add(campaign1);
            campaignManager.Add(campaign2);
            campaignManager.List();

            SalesManager salesManager = new SalesManager();
            salesManager.Sales(game1, gamer1);
            salesManager.Sales(game2,gamer1,campaign1);
            salesManager.Sales(game1, gamer2, campaign2);

            gamer2.FirstName = "Ayca";
            gamerManager.Update(gamer2);
            gamerManager.Delete(gamer1);

            game2.Price = 200;
            gameManager.Update(game2);
            gameManager.Delete(game1);

            campaign1.CampaignRate = 70;
            campaignManager.Update(campaign1);
            campaignManager.Delete(campaign2);

        }
    }
}
