using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using String.Methods;

namespace StringTests
{
    [TestFixture]
    public class StringTest
    {
        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHiTest(string name, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.SayHi(name);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo", "Alice", "YoAliceAliceYo")]
        [TestCase("What", "Up", "WhatUpUpWhat")]
        public void AbbaTest(string a, string b, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.Abba(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTagsTest(string tag, string content, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.MakeTags(tag, content);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "word", "[[word]]")]
        public void InsertWordTest(string container, string word, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.InsertWord(container, word);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]
        public void MultipleEndingsTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.MultipleEndings(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]
        public void FirstHalfTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.FirstHalf(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]
        public void TrimOneTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.TrimOne(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]
        public void LongInMiddleTest(string a, string b, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.LongInMiddle(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateLeft2Test(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.RotateLeft2(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateRight2Test(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.RotateRight2(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TakeOneTest(string str, bool fromFront, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.TakeOne(str, fromFront);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]
        public void MiddleTwoTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.MiddleTwo(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void EndsWithLyTest(string str, bool expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            bool actualResult = strings.EndsWithLy(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void FrontAndBackTest(string str, int n, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.FrontAndBack(str, n);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwoFromPositionTest(string str, int n, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.TakeTwoFromPosition(str, n);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        public void HasBadTest(string str, bool expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            bool actualResult = strings.HasBad(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        public void AtFirstTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.AtFirst(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        public void LastCharsTest(string a, string b, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.LastChars(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", "", "abc")]
        public void ConCatTest(string a, string b, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.ConCat(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("coding", "codign")]
        [TestCase("cat", "cta")]
        [TestCase("ab", "ba")]
        public void SwapLastTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.SwapLast(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("edited", true)]
        [TestCase("edit", false)]
        [TestCase("ed", true)]
        public void FrontAgainTest(string str, bool expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            bool actualResult = strings.FrontAgain(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "Hi", "loHi")]
        [TestCase("Hello", "java", "ellojava")]
        [TestCase("java", "Hello", "javaello")]
        public void MinCatTest(string a, string b, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.MinCat(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "llo")]
        [TestCase("away", "aay")]
        [TestCase("abed", "abed")]
        public void TweakFrontTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.TweakFront(str);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("xHix", "Hi")]
        [TestCase("xHi", "Hi")]
        [TestCase("Hxix", "Hxi")]
        public void StripXTest(string str, string expectedResult)
        {
            StringWarmups strings = new StringWarmups();
            string actualResult = strings.StripX(str);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
