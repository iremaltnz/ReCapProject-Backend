using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class Gamer:IEntity
    {
        public int Id { get; set; }
        public string TcNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirtYear { get; set; }
       
    }
}
