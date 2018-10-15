using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Domino
    {
        private int side1;
        private int side2;

        public Domino()
        {
        }

        public Domino(int p1, int p2) //should check for ranges
        {
            this.side1 = p1;
            this.side2 = p2;
        }

        // don't use an auto implemented property because of the validation in the setter - p 390
        public int Side1
        {
            get
            {
                return side1;
            }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentException("The setter should throw an exception for negative values.");
                }
                side1 = value;
            }
            // cant be less than zero cant be greater than 12
            //get returns side1
            //set checks range. throw argumentexception
            //zero should be "blanks"
        }


        public int Side2
        {
            get
            {
                return side2;
            }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentException("The setter should throw an exception for negative values.");
                }
                side2 = value;
            }
        }

        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        /// This is how I would have done this in 233N
        public int Score // get just returns side one and side two
        {
            get
            {
                return side1 + side2;
            }
        }
        // alternatively could use this one below.
        // because it's a read only property, I can use the "expression bodied syntax" or a lamdba expression - p 393
        //public int Score => side1 + side2;

        //ditto for the first version of this method and the next one
        public bool IsDouble()
        {
            if (side1 == side2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public bool IsDouble() => (side1 == side2) ? true : false;

        // could you do this one using a lambda expression?
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }

        

        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        // could you overload the == and != operators?
        public override bool Equals(object obj) // should just compare the sides
        {
            if (obj == null)
            {
                return false;
            }

            Domino d = (Domino)obj;

            if (d.side1 == side1 && d.side2 == side2)
            {
                return true;
            }
            else
            {
                return false;
            }
            //if obj == null return false
            //create obj domino domino d = domino(obj)
            //if sides are equal true
            //else false
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
