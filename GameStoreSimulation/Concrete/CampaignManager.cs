using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class CampaignManager:IOperationsManager
    {
        List<Campaign> campaigns;
        Campaign _campaign;

        public CampaignManager()
        {
            campaigns = new List<Campaign> { };
        }
       public  void Add(Campaign campaign)
        {
            campaigns.Add(campaign);
        }

        public void Update(Campaign campaign)
        {
            foreach (Campaign c in campaigns)
            {
                if (c.Id == campaign.Id) _campaign = c;
 
            }

            _campaign.Id = campaign.Id;
            _campaign.Name = campaign.Name;
            _campaign.CampaignRate = campaign.CampaignRate;

            Console.WriteLine("\nKampanya bilgileri güncellendi. Yeni bilgiler:\nId=" + _campaign.Id + "\nName=" + _campaign.Name + "\nCampaign Rate=" + _campaign.CampaignRate+"\n"
            );
        }

        public void Delete(Campaign campaign)
        {

            foreach (Campaign c in campaigns)
            {
                if (c.Id == campaign.Id) _campaign = c;

            }

            campaigns.Remove(_campaign);
            Console.WriteLine(_campaign.Name+" isimli kampanya sistemden silindi.\n");
        }

        public void List()
        {
            int temp = 1;
            Console.WriteLine("------------ Campaign List------------");
            foreach (Campaign c in campaigns)
            {
                Console.WriteLine("Campaign "+temp+":\nId="+c.Id+"\nName="+c.Name+"\nCampaign Rate = %"+c.CampaignRate);
                temp++;
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }
    }
}
