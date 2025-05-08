using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntFarm {
    internal class Tile : IMapObject {
        public char Icon { get; private set; }

        public Tile(char icon) {
            Icon = icon;
        }

        public static Tile Empty => new(' ');
    }
}
