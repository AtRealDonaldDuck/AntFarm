using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntFarm {
    internal class Entity : IMapEntity {
        public char Icon { get; private set; }

        public Entity(char icon) {
            Icon = icon;
        }
    }
}
