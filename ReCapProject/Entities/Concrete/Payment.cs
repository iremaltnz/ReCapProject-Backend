using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardNumber { get; set; }
        public int YearOfExpiration { get; set; }
        public int MonthOfExpiration { get; set; }
        public int CVV { get; set; }
    }
}
