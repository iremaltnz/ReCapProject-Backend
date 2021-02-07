using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class Game:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string SystemRequirements { get; set; }
    }
}
