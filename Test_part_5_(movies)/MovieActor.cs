using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_part_5__movies_
{
    class MovieActor
    {
        public MovieActor()
        {
        }

        public MovieActor(long iD, long movieID, long actorID)
        {
            ID = iD;
            MovieID = movieID;
            ActorID = actorID;
        }

        public long ID { get; set; }
        public long MovieID { get; set; }
        public long ActorID { get; set; }
        public override bool Equals(object obj)
        {
            return this.ID == ((MovieActor)obj).ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
        }
        public static bool operator ==(MovieActor car1, MovieActor car2)
        {
            return car1.ID == car2.ID;
        }
        public static bool operator !=(MovieActor car1, MovieActor car2)
        {
            return !(car1 == car2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
