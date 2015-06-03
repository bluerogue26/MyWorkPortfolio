using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Array.Methods;
using NUnit.Framework;

namespace Arrays.Tests.BLL
{
    [TestFixture]
    public class ArrayTests
    {
        [TestCase(new[] {1, 2, 6}, true)]
        [TestCase(new[] {6, 1, 2, 3}, true)]
        [TestCase(new[] {13, 6, 1, 2, 3}, false)]
        public void FirstLast6Test(int[] numbers, bool expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            bool actualResult = array.FirstLast6(numbers);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase(new[] {1, 2, 3}, false)]
        [TestCase(new[] {1, 2, 3, 1}, true)]
        [TestCase(new[] {1, 2, 1}, true)]
        public void SameFirstLastTest(int[] numbers, bool expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            bool actualResult = array.SameFirstLast(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(3, new[] {3, 1, 4})]
        public void MakePiTest(int n, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.MakePi(n);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 3}, new[] {7, 3}, true)]
        [TestCase(new[] {1, 2, 3}, new[] {7, 3, 2}, false)]
        [TestCase(new[] {1, 2, 3}, new[] {1, 3}, true)]
        public void CommonEndTest(int[] a, int[] b, bool expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            bool actualResult = array.CommonEnd(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 3}, 6)]
        [TestCase(new[] {5, 11, 2}, 18)]
        [TestCase(new[] {7, 0, 0}, 7)]
        public void SumTest(int[] numbers, int expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int actualResult = array.Sum(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 3}, new[] {2, 3, 1})]
        [TestCase(new[] {5, 11, 9}, new[] {11, 9, 5})]
        [TestCase(new[] {7, 0, 0}, new[] {0, 0, 7})]
        public void RotateLeftTest(int[] numbers, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.RotateLeft(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new []{1, 2, 3}, new[]{3, 2, 1})]
        [TestCase(new []{10, 9, 8}, new[]{8, 9, 10})]
        [TestCase(new []{1, 4, 9, 8}, new[]{8, 9, 4, 1})]
        public void ReverseTest(int[]numbers, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.Reverse(numbers);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase(new[] {1, 2, 3}, new[] {3, 3, 3})]
        [TestCase(new[] {11, 5, 9}, new[] {11, 11, 11})]
        [TestCase(new[] {2, 11, 3}, new[] {3, 3, 3})]
        public void HigherWinsTest(int[] numbers, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.HigherWins(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {2, 5})]
        [TestCase(new[] {7, 7, 7}, new[] {3, 8, 0}, new[] {7, 8})]
        [TestCase(new[] {5, 2, 9}, new[] {1, 4, 5}, new[] {2, 4})]
        public void GetMiddleTest(int[] a, int[] b, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.GetMiddle(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {2, 5}, true)]
        [TestCase(new[] {4, 3}, true)]
        [TestCase(new[] {7, 5}, false)]
        public void HasEvenTest(int[] numbers, bool expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            bool actualResult = array.HasEven(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {4, 5, 6}, new[] {0, 0, 0, 0, 0, 6})]
        [TestCase(new[] {1, 2}, new[] {0, 0, 0, 2})]
        [TestCase(new[] {3}, new[] {0, 3})]
        public void KeepLastTest(int[] numbers, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.KeepLast(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {2, 2, 3}, true)]
        [TestCase(new[] {3, 4, 5, 3}, true)]
        [TestCase(new[] {2, 2, 3, 2}, false)]
        public void Double23Test(int[] numbers, bool expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            bool actualResult = array.Double23(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2, 0})]
        [TestCase(new[] {2, 3, 5}, new[] {2, 0, 5})]
        [TestCase(new[] {1, 2, 1}, new[] {1, 2, 1})]
        public void Fix23Test(int[] numbers, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.Fix23(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {1, 3, 4, 5}, true)]
        [TestCase(new[] {2, 1, 3, 4, 5}, true)]
        [TestCase(new[] {1, 1, 1}, false)]
        public void Unlucky1Test(int[] numbers, bool expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            bool actualResult = array.Unlucky1(numbers);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {4, 5})]
        [TestCase(new[] {4}, new[] {1, 2, 3}, new[] {4, 1})]
        [TestCase(new int[]{ }, new[] {1, 2}, new[] {1, 2})]
        public void Make2Test(int[] a, int[] b, int[] expectedResult)
        {
            ArrayWarmups array = new ArrayWarmups();
            int[] actualResult = array.Make2(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }
        
    }
}
