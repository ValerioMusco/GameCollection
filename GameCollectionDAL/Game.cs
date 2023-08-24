using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionDAL {
    public class Game {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Categories { get; set; }

        public override string ToString() {

            StringBuilder sb = new();

            sb.Append( Id + " - " );
            sb.Append( Title + " - " );
            sb.Append( ReleaseDate + " - " );
            sb.Append( Description + " - " );
            foreach( var category in Categories ) {
                sb.Append( category.ToString() + ", " );
            }

            return sb.ToString();
        }
    }
}
