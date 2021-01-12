using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_part_5__movies_
{
    class Genre
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            return this.ID == ((Genre)obj).ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
        }
        public static bool operator ==(Genre genre1, Genre genre2)
        {
            return genre1.ID == genre2.ID;
        }
        public static bool operator !=(Genre genre1, Genre genre2)
        {
            return !(genre1 == genre2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
