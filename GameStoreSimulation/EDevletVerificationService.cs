using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class EDevletVerificationManager : IVerificationService
    {
        public bool Dogrulama(Gamer gamer)
        {
            Console.WriteLine("Müsteri bilgisi Edevlet sisteminde doğrulanmıştır");
            return true;
        }
    }
}
