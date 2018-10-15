using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        private List<Domino> dominos = new List<Domino>();

        public static Random rng = new Random();

        /// <summary>
        /// Constructor fills our list full of dominos up to maxDots as the highest double.
        /// </summary>
        /// <param name="maxDots"></param>
        public BoneYard(int maxDots)
        {
            for (int i = 0; i <= maxDots; i++)
            {
                for (int k = 0; k <= maxDots; k++)
                {
                    Domino domino = new Domino(i, k);
                    dominos.Add(domino);
                }
            }
        }

        /// <summary>
        /// Fisher Yates Shuffle
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int temp = rng.Next(n + 1);
                T value = list[temp];
                list[temp] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// is our boneyard empty?
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (dominos.Count < 0)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// count of boneyard remaining
        /// </summary>
        public int DominosRemaining
        {
            get
            {
                return dominos.Count;
            }
        }

        /// <summary>
        /// this draws a domino from the boneyard.
        /// </summary>
        /// <returns></returns>
        public Domino Draw()
        {
            // draw random domino
            // if you can play it, play it, else if not keep in hand
            Random rand = new Random();
            int index = rand.Next(DominosRemaining);

            Domino domino;
            domino = this[index];
            dominos.Remove(domino);
            return domino;
        }
       
        /// <summary>
        /// this is our domino indexer!
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Domino this[int i]
        {
            get
            {
                if (i < 0 || i > dominos.Count)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                return dominos[i];
            }
            set { dominos[i] = value; }
        }

        /// <summary>
        /// returns a string of what is left in the boneyard.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(this.IsEmpty())
            {
                return ("Empty Boneyard");
            }
            string output = "";
            foreach (Domino d in dominos)
            {
                output += d.ToString() + "\n";
            }
            return output;
        }
        
    }
}
