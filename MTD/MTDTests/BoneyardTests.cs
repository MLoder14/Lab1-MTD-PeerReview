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
    public class BoneyardTests
    {
        BoneYard boneyard;
        BoneYard boneyard2;
        BoneYard boneyard3;

        [SetUp]
        public void SetUpAllTesters()
        {
            boneyard = new BoneYard(4);
            boneyard2 = new BoneYard(6);
            boneyard3 = new BoneYard(12);
        }

        [Test]
        public void TestBoneYardConstructor()
        {
            Assert.IsInstanceOf<BoneYard>(boneyard);
        }

        [Test]
        public void TestBoneYArdIsEmpty()
        {
            bool shouldBe = false;
            bool actuallyIs = boneyard.IsEmpty();
            Assert.AreEqual(shouldBe, actuallyIs);
        }

        [Test]
        public void TestBoneYardDraw()
        {
            Domino domino = boneyard.Draw();
            Assert.IsInstanceOf<Domino>(domino);
        }

        [Test]
        public void TestBoneYardDominosRemaining()
        {
            int expected = 48;
            boneyard2.Draw();
            int actual = boneyard2.DominosRemaining;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestBoneYardThisGetter()
        {
            Domino domino = boneyard[0];
            Assert.IsInstanceOf<Domino>(domino);
        }

        [Test]
        public void TestBoneYardThisSetter()
        {
            int expected = 12;
            boneyard[1].Side1 = 12;
            int actual = boneyard[1].Side1;
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void TestBoneYardToString()
        {
            String boneYardStringList;
            boneYardStringList = boneyard.ToString();
            Assert.IsInstanceOf<String>(boneYardStringList);

        }

        [Test]
        public void TestBoneYardShuffle()
        {

        }
    }
}