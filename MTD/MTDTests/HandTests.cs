using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDTests
{
    [TestFixture]
    public class HandTests
    {
        Hand handConst;
        Hand h1;
        Hand h2;
        Hand h3;
        BoneYard testby1;
        BoneYard testby2;
        Domino d1;
        Domino d2;
        Domino d3;

        [SetUp]
        public void SetUpAllTests()
        {
            testby1 = new BoneYard(9);
            testby2 = new BoneYard(6);
            handConst = new Hand();
            h1 = new Hand(testby1, 2);
            h2 = new Hand(testby1, 6);
            h3 = new Hand(testby2, 2);
            d1 = new Domino(1,1);
            d2 = new Domino(0,0);
            d3 = new Domino(2,2);
            h1.Add(d1);
            h2.Add(d2);
            h2.Add(d3);
        }

        [Test]
        public void TestAdding()
        {
            //Hand stuff = new Hand();
            Assert.That(handConst.IsEmpty);
            Assert.IsNotEmpty(h2.ToString());
        }

        
        [Test]
        public void TestOverloadedConst()
        {

        }


        [Test]
        public void TestGetters()
        {

        }

        [Test]
        public void TestSetters()
        {

        }

        [Test]
        public void TestNoGoodSetters()
        {

        }

        [Test]
        public void TestScore()
        {
            int answerd1 = 2;
            int answerd3 = 4;

            Assert.AreEqual(answerd1, d1.Score);
            Assert.AreEqual(answerd3, d3.Score);
        }

        [Test]
        public void TestCount()
        {
            int count = 2;
            Assert.AreEqual(count, h2.Count);
        }

        [Test]
        public void TestHasDomino()
        {
            //Assert.True(h1.HasDomino(1));
            //Assert.False(h1.HasDomino(6));
        }

        [Test]
        public void TestHasDoubleDomino()
        {
            Assert.True(h1.HasDoubleDomino(2));
            Assert.False(h1.HasDoubleDomino(4));
        }

        [Test]
        public void TestIndexOf()
        {
            Assert.AreEqual(h1.IndexOfDomino(2), 2);
        }

        [Test]
        public void TestIndexOfDouble()
        {
           int domIndex = h1.IndexOfDomino(1);
            Assert.AreEqual(1, domIndex);
        }

        [Test]
        public void TestIndexOfHighDouble()
        {

        }

        [Test]
        public void TestIndexer()
        {

        }

        [Test]
        public void TestRemove()
        {

        }

        [Test]
        public void TestGetDomnio()
        {

        }

        [Test]
        public void TestGetDoubleDomino()
        {

        }

        [Test]
        public void TestDraw()
        {

        }

        [Test]
        public void TestPlayIndexAndTrain()
        {

        }

        [Test]
        public void TestPlayDominoAndTrain()
        {

        }

        [Test]
        public void TestPlayTrain()
        {

        }

        [Test]
        public void TestToString()
        {

        }
        
    }
}
