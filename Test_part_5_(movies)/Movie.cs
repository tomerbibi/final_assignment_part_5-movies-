using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_part_5__movies_
{
    class Movie
    {
        public Movie()
        {
        }

        public long ID { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public long GenreID { get; set; }
        public override bool Equals(object obj)
        {
            return this.ID == ((Movie)obj).ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
        }
        public static bool operator ==(Movie movie1, Movie movie2)
        {
            return movie1.ID == movie2.ID;
        }
        public static bool operator !=(Movie movie1, Movie movie2)
        {
            return !(movie1 == movie2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

    }
}
