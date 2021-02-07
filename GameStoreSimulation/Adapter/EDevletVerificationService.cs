using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Text;
using static ServiceReference1.KPSPublicSoapClient;

namespace GameProject
{
    class EDevletVerificationManager : IVerificationService
    {
        public bool Dogrulama(Gamer gamer)
        {
            
            ServiceReference1.KPSPublicSoapClient client = new ServiceReference1.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            var result = client.TCKimlikNoDogrulaAsync(Convert.ToInt64(gamer.TcNum),
                  gamer.FirstName,
                  gamer.LastName,
                  gamer.BirtYear).Result;
            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
