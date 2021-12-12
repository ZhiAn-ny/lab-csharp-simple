using System;

namespace Indexers
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Map2DTests
    {
        private readonly int[] _seven = new int[] { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70 };
        private IMap2D<int, int, int> _pythagoreanTable;

        // Called once before each test after the constructor
        [TestInitialize]
        public void TestInitialize()
        {
            this._pythagoreanTable = new Map2D<int, int, int>();
            this._pythagoreanTable.Fill(
                Enumerable.Range(1, 10),
                Enumerable.Range(1, 10),
                (i, j) => i * j);
        }

        [TestMethod]
        public void FillAndIndexerTest()
        {
            Console.WriteLine(_pythagoreanTable.ToString());

            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(i * i, this._pythagoreanTable[i, i]);
            }
        }

        [TestMethod]
        public void GetRowTest()
        {
            if (!this._pythagoreanTable.GetRow(7).Select(t => t.Item2).SequenceEqual(this._seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }

        [TestMethod]
        public void EqualsTest()
        {
            var newMap2D = new Map2D<int, int, int>();
            newMap2D.Fill(
                Enumerable.Range(1, 10),
                Enumerable.Range(1, 10),
                (i, j) => i * j);
            
            if (!this._pythagoreanTable.Equals(newMap2D))
            {
                Assert.Fail("Wrong implementation");
            }
        }
        
        [TestMethod]
        public void GetColumnTest()
        {
            if (!this._pythagoreanTable.GetColumn(7).Select(t => t.Item2).SequenceEqual(this._seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }
    }
}
