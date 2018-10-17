using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDClasses
{
    /// <summary>
    /// Represents a generic Train for MTD
    /// </summary>
    public abstract class Train
    {
        private List<Domino> listofDominos;
        private int engineValue;

        public Train()//set engine value this.eng
        {
            //listofDominos = new List<Domino>();
        }

        public Train(int engValue) //make the default and do nothing
        {
            listofDominos = new List<Domino>();
            if (engValue <= 0)
            {
                throw new Exception("Engine value is less than 0");
            }
            else
            this.engineValue = engValue;
        }

        /// <summary>
        /// returns count of the train list
        /// </summary>
        public int Count
        {
            get
            {
                return listofDominos.Count;
            }
        }

        /// <summary>
        /// The first domino value that must be played on a train
        /// </summary>
        public int EngineValue
        {
            get
            {
                return engineValue;
            }
        }

        /// <summary>
        /// checks and returns true if the listofdominos is empty and false if its not.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (listofDominos.Count == 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Domino LastDomino // throw in an if statement and check for an empty list. return null
        {
            get
            {
                return listofDominos[Count - 1];
            }
            //return the last domino played
        }

        /// <summary>
        /// Side2 of the last domino in the train.  It's the value of the next domino that can be played.
        /// </summary>
        public int PlayableValue
        {
            
            get
            {                
               return LastDomino.Side2;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        public void Add(Domino d)
        {
            listofDominos.Add(d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Domino this[int index] // doesn't need to check for valid answers
        {
            get
            {
                /*
                if (index < 0 || index > listofDominos.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                */

                return listofDominos[index];
            }
            set { listofDominos[index] = value; }
        }

        /// <summary>
        /// Determines whether a hand can play a specific domino on this train and if the domino must be flipped.
        /// Because the rules for playing are different for Mexican and Player trains, this method is abstract.
        /// </summary>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        /// <summary>
        /// A helper method that determines whether a specific domino can be played on this train.
        /// It can be called in the Mexican and Player train class implementations of the abstract method
        /// </summary>
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (!IsEmpty)
            {
                //if our engine value = side1
                //mustflip = false;
                if (d.Side1 == PlayableValue)
                {
                    mustFlip = false;
                    return true;
                }
                //if our engine value = side2
                //mustflip = true;
                else if (d.Side2 == PlayableValue)
                {
                    mustFlip = true;
                    return true;
                }


            }
            else
            {
                mustFlip = false;
                return false;
            }

        }

        /// <summary>
        /// assumes the domino has already been removed from the hand
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip)
                    d.Flip();

                Add(d);
            }
            else
            {
                throw new Exception("domino" + ToString() + "This Domino has already been removed");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "Empty BoneYard";
            }
            string output = "";
            foreach (Domino d in listofDominos)
            {
                output += d.ToString() + "\n";
            }
            return output;
        }
        
    }
}