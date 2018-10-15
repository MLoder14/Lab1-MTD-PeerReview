using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Represents a hand of dominos
    /// </summary>
    public class Hand
    {

        /// <summary>
        /// The list of dominos in the hand
        /// </summary>
        public List<Domino> handofDominos = new List<Domino>();

        /// <summary>
        /// Creates an empty hand
        /// </summary>
        public Hand()
        {
            handofDominos = new List<Domino>();
        }

        /// <summary>
        /// Creates a hand of dominos from the boneyard.
        /// The number of dominos is based on the number of players
        /// 2–4 players: 10 dominoes each
        /// 5–6 players: 9 dominoes each
        /// 7–8 players: 7 dominoes each
        /// </summary>
        /// <param name="by"></param>
        /// <param name="numPlayers"></param>
        /// 
        //switch or other loop would work here.
        public Hand(BoneYard by, int numPlayers)
        {
            if (numPlayers == 2 || numPlayers == 3 || numPlayers == 4)
            {
                for (int d = 0; d == 10; d++)
                {
                    handofDominos.Add(by.Draw());
                }
            }
            if (numPlayers == 5 || numPlayers == 6)
            {
                for (int d = 0; d == 9; d++)
                {
                    handofDominos.Add(by.Draw());
                }
            }
            if (numPlayers == 7 || numPlayers == 8)
            {
                for (int d = 0; d == 7; d++)
                {
                    handofDominos.Add(by.Draw());
                }
            }
        }

        public void Add(Domino d)
        {
            handofDominos.Add(d);
        }

        //number on dominos in the hand
        public int Count
        {
            get
            {
                return handofDominos.Count;
            }
        }

        //should be true when the hand is empty else false
        public bool IsEmpty
        {
            get
            {
                if (handofDominos.Count == 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Sum of the score of each domino in the hand
        /// 
        /// ADD IEnumerable!!!!!!
        /// 
        /// 
        /// </summary>
        public int Score
        {
            get
            {
                foreach (Domino d in handofDominos)
                {
                    // need to sum them
                    return d.Side1 + d.Side2;
                }
                return - 1;
            }
        }

        /// <summary>
        /// Does the hand contain a domino with value in side 1 or side 2?
        /// </summary>
        /// <param name="value">The number of dots on one side of the domino that you're looking for</param>
        public bool HasDomino(int value)
        {
            Domino d = handofDominos[value];
            if (d.Side1 == value || d.Side2 == value)
            {
                return true;
            }
            else
            return false;
        }

        /// <summary>
        ///  Does the hand contain a double of a certain value?
        /// </summary>
        /// <param name="value">The number of (double) dots that you're looking for</param>
        /// 
        // can use a for loop to run through the hand and check if its true
        public bool HasDoubleDomino(int value)
        {
            foreach (Domino d in handofDominos)
            {
                if (d.Side1 == value && d.Side2 == value)
                {
                    return true;
                }
                /*
                else //if (d.Side1 != value || d.Side2 != value)
                {
                    return false;
                }
                */
            }
            return false;
        }

        /// <summary>
        /// The index of a domino with a value in the hand
        /// </summary>
        /// <param name="value">The number of dots on one side of the domino that you're looking for</param>
        /// <returns>-1 if the domino doesn't exist in the hand</returns>
        public int IndexOfDomino(int value)
        {
            foreach (Domino d in handofDominos)
            {
                if ((d.Side1 == value) || (d.Side2 == value))
                {
                    return value;
                }
            }
            return -1;
        }

        /// <summary>
        /// The index of the do
        /// </summary>
        /// <param name="value">The number of (double) dots that you're looking for</param>
        /// <returns>-1 if the domino doesn't exist in the hand</returns>
        public int IndexOfDoubleDomino(int value)
        {
            foreach (Domino d in handofDominos)
            {
                if ((d.Side1 == value) && (d.Side2 == value))
                {
                    return value;
                }
            }
            return -1;
        }

        /// <summary>
        /// The index of the highest double domino in the hand
        /// </summary>
        /// <returns>-1 if there isn't a double in the hand</returns>
        /// 
        // use a loop to start up high and go down searching for a double.
        public int IndexOfHighDouble()
        {
            //foreach loop instead?
            foreach (Domino d in handofDominos)
            {                
                if (d.IsDouble())
                {
                    return d.Side1;
                } 
            }
            return -1;
        }

        public Domino this[int index]
        {
            get
            {
                if (index < 0 || index > handofDominos.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return handofDominos[index];
            }
            set { handofDominos[index] = value; }
        }

        // use the remove that is a part of the list class.
        public void RemoveAt(int index)
        {
            Domino d = handofDominos[index];
            handofDominos.Remove(d);
        }

        /// <summary>
        /// Finds a domino with a certain number of dots in the hand.
        /// If it can find the domino, it removes it from the hand and returns it.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Domino GetDomino(int value)
        {
            foreach (Domino d in handofDominos)
            {
                if (d.Side1 == value)
                {
                    handofDominos.Remove(d);
                    return d;
                }
                //return d;
                else if (d.Side2 == value)
                {
                    handofDominos.Remove(d);
                    return d;
                }

            }return null;
        }

        /// <summary>
        /// Finds a domino with a certain number of double dots in the hand.
        /// If it can find the domino, it removes it from the hand and returns it.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Domino GetDoubleDomino(int value)
        {
            foreach (Domino d in handofDominos)
            {
                if (d.Side1 == value && d.Side2 == value)
                {
                    handofDominos.Remove(d);
                    return d;
                }

            }return null;
        }

        /// <summary>
        /// Draws a domino from the boneyard and adds it to the hand
        /// </summary>
        /// <param name="by"></param>
        /// 
        // call the  draw method from the boneyard and then add that to the hand. boom done
        public void Draw(BoneYard by)
        {
            Domino d = new Domino();
            if (by.IsEmpty())
            {
                return; //should probably throw exception.
            }
            else
            handofDominos.Add(by.Draw());
        }

        /// <summary>
        /// Plays the domino at the index on the train.
        /// Flips the domino if necessary before playing.
        /// Removes the domino from the hand.
        /// Throws an exception if the domino at the index
        /// is not playable. kind of like the indexer
        /// </summary>
        /// <param name="index"></param>
        /// <param name="t"></param>
        private void Play(int index, Train t) // the UI will never call this method
        {
            //get the domino
            //if its playable, flip
            //should i call play on the train
            bool mustFlip = false;
            Domino d = handofDominos[index];
            if(t.IsPlayable(this, d, out mustFlip))
            {
                handofDominos.RemoveAt(index);
                if (mustFlip)
                    d.Flip()
                t.Play(this, d);
            }
            else
            {
                //excetioon
            }
        }

        /// <summary>
        /// Plays the domino from the hand on the train.
        /// Flips the domino if necessary before playing.
        /// Removes the domino from the hand.
        /// Throws an exception if the domino is not in the hand
        /// or is not playable.
        /// </summary>
        public void Play(Domino d, Train t)
        {
            int i = handofDominos.IndexOf(d);
            //if the domino is found in the hand then play it
            if (i != -1)
            {
                Play(i, t);
            }
        }

        /// <summary>
        /// Plays the first playable domino in the hand on the train
        /// Removes the domino from the hand.
        /// Returns the domino.
        /// Throws an exception if no dominos in the hand are playable.
        /// kind of like the indexer
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Domino Play(Train t) // this is what the UI uses
        {
            int playValue = t.PlayableValue;
            int i = IndexOfDomino(playValue);
            if (i != -1)
            {
                Domino playable = this[i];
                Play(i, t);
                return playValue;
                //remove the domino
            }

            //throw exception
        }

        //return the hand
        // call the tosring from the domino class with a for loop.
        public override string ToString()
        {

        }
    }
}
