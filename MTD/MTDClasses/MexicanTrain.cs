using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace MTDClasses
{
    class MexicanTrain : Train
    {
        //Default const
        public MexicanTrain() : base() { }

        //overloaded const
        public MexicanTrain(int engineValue) : base(engineValue) { }

        //override the abstract is playable method.
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return IsPlayable(h, d, out mustFlip);
        }
    }
}
