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
    }
}
