using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Loop.Tests.BLL;
using NUnit.Framework.Constraints;

namespace Loops.Tests
{
    [TestFixture]
    public class LoopTests
    {
        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]
        public void StringTimesTest(string str, int n, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.StringTimes(str, n);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("Chocolate", 3, "ChoChoCho")]
        [TestCase("Abc", 3, "AbcAbcAbc")]
        public void StringFrontTest(string str, int n, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.FrontTimes(str, n);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("abcxx", 1)]
        [TestCase("xxx", 2)]
        [TestCase("xxxx", 3)]
        public void CountXXTest(string str, int expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            int actualResult = loops.CountXX(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxxx", true)]
        public void DoubleXTest(string str, bool expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            bool actualResult = loops.DoubleX(str);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestCase("Hello", "Hlo")]
        [TestCase("Hi", "H")]
        [TestCase("Heeololeo", "Hello")]
        public void EveryOtherTest(string str, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.EveryOther(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Code", "CCoCodCode")]
        [TestCase("abc", "aababc")]
        [TestCase("ab", "aab")]
        public void StringSplosion(string str, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.StringSplosion(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("hixxhi", 1)]
        [TestCase("xaxxaxaxx", 1)]
        [TestCase("axxxaaxx", 2)]
        public void CountLast2Test(string str, int expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            int actualResult = loops.CountLast2(str);

            Assert.AreEqual(expectedResult, actualResult);
        }
        //Check with Eric later
        [TestCase(new[] {1, 2, 9}, 1)]
        [TestCase(new[] {1, 9, 9}, 2)]
        [TestCase(new[] {1, 9, 9, 3, 9}, 3)]
        public void Count9Test(int[] numbers, int expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            int actualResult = loops.Count9(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 9, 3, 4}, true)]
        [TestCase(new[] {1, 2, 3, 4, 9}, false)]
        [TestCase(new[] {1, 2, 3, 4, 5}, false)]
        public void ArrayFront9Test(int[] numbers, bool expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            bool actualResult = loops.ArrayFront9(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 1, 2, 3, 1}, true)]
        [TestCase(new[] {1, 1, 2, 4, 1}, false)]
        [TestCase(new[] {1, 1, 2, 1, 2, 3}, true)]
        public void Array123Test(int[] numbers, bool expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            bool actualResult = loops.Array123(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("xxcaazz", "xxbaaz", 3)]
        [TestCase("abc", "abc", 2)]
        [TestCase("acb", "axc", 0)]
        public void SubStringMatchTest(string a, string b, int expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            int actualResult = loops.SubStringMatch(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("xxHxix", "xHix")]
        [TestCase("abxxxcd", "abcd")]
        [TestCase("xabxxxcdx", "xabcdx")]
        public void StringXTest(string str, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.StringX(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("kitten", "kien")]
        [TestCase("Chocolate", "Chole")]
        [TestCase("CodingHorror", "Congrr")]
        public void AltPairsTest(string str, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.AltPairs(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("yakpak", "pak")]
        [TestCase("pakyak", "pak")]
        [TestCase("yak123ya", "123ya")]
        public void DoNotYakTest(string str, string expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            string actualResult = loops.DoNotYak(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new []{6, 6, 2},1)]
        [TestCase(new []{6, 6, 2, 7},1)]
        [TestCase(new []{6, 7, 2, 6},1)]
        public void Array667Test(int[]numbers, int expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            int actualResult = loops.Array667(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 1, 2, 2, 1}, true)]
        [TestCase(new[] {1, 1, 2, 2, 2, 1}, false)]
        [TestCase(new[] {1, 1, 1, 2, 2, 2, 2, 1}, false)]
        public void NoTriplesTest(int[] numbers, bool expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            bool actualResult = loops.NoTriples(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 7, 1}, true)]
        [TestCase(new[] {1, 2, 8, 1}, false)]
        [TestCase(new[] {2, 7, 1}, true)]
        public void Pattern51Test(int[] numbers, bool expectedResult)
        {
            LoopWarmups loops = new LoopWarmups();
            bool actualResult = loops.Pattern51(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }

}
