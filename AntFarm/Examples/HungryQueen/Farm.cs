using AntFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntFarm.Examples.HungryQueen {
    internal class Farm {
        //maps initially populated with dirt, food placed randomly on initialization
        //random location chosen to place queens chamber and spawn queen there

        //Actors all have energy that gets replenished by eating food
        //if actor cant afford any actions they die 

        //QUEEN
        //
        //[ACTIONS]
        //  idle
        //      do nothing
        //      consume very little energy
        //  birth
        //      can only be done onece every 30 ticks
        //      create new ant in a random adjacent empty tile
        //      consumes considerable energy
        //
        //[AI BEHAVIOUR]
        //  to be written

        //ANT
        //
        //[ACTIONS]
        //  idle
        //      do nothing
        //      consume very little energy
        //  move
        //      move to adjacent tile
        //      consume very little energy
        //  dig
        //      destroy adjacent dirt tile
        //      consume very little energy
        //  Grab
        //      Grab object from adjacent tile
        //      cant grab if currently carrying something
        //  Drop
        //      Place carried object in adjacent tile
        //      can only be done if an object is currently grabbed
        //[AI BEHAVIOUR]
        // to be written


        public string GetWorldString() {
            throw new NotImplementedException();
        }

        public void Update() {
            throw new NotImplementedException();
        }
    }
}
