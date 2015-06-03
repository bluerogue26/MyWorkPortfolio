using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace String.Methods
{
    public class StringWarmups
    {
        public string SayHi(string name)
        {
            string actualResult = "Hello ";

            actualResult += name.Substring(0, name.Length);

            actualResult += '!';

            return actualResult;
        }

        public string Abba(string a, string b)
        {
            string actualResult = "";

            actualResult += a.Substring(0, a.Length);

            actualResult += b.Substring(0, b.Length);

            actualResult += b.Substring(0, b.Length);

            actualResult += a.Substring(0, a.Length);

            return actualResult;

        }

        public string MakeTags(string tag, string content)
        {
            string actualResult = "";
            string firstTag = "<";
            string lastTag = "</";

            for (int i = 0; i < tag.Length; i++)
            {
                firstTag += tag.Substring(i, 1);
                lastTag += tag.Substring(i, 1);
            }
            firstTag += '>';
            lastTag += '>';

            actualResult += firstTag.Substring(0, firstTag.Length);

            actualResult += content.Substring(0, content.Length);

            actualResult += lastTag.Substring(0, lastTag.Length);

            return actualResult;
        }

        public string InsertWord(string container, string word)
        {
            string actualResult = "";

            for (int i = 0; i < container.Length; i++)
            {
                if (i == container.Length/2)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        actualResult += word.Substring(j, 1);
                    }
                }
                actualResult += container.Substring(i, 1);
            }
            return actualResult;
        }

        public string MultipleEndings(string str)
        {
            string actualResult = "";

            string ending = str.Substring(str.Length - 2, 2); ;

            actualResult += ending.Substring(0, ending.Length);
            actualResult += ending.Substring(0, ending.Length);
            actualResult += ending.Substring(0, ending.Length);

            return actualResult;
        }

        public string FirstHalf(string str)
        {
            string actualResult = "";

            for (int i = 0; i < str.Length/2; i++)
                actualResult += str.Substring(i, 1);

            return actualResult;
        }

        public string TrimOne(string str)
        {
            string actualResult = "";

            for (int i = 1; i < str.Length - 1; i++)
                actualResult += str.Substring(i, 1);

            return actualResult;
        }

        public string LongInMiddle(string a, string b)
        {
            string actualResult = "";

            if (a.Length > b.Length)
            {
                actualResult += b.Substring(0, b.Length);
                actualResult += a.Substring(0, a.Length);
                actualResult += b.Substring(0, b.Length);
            }
            else
            {
                actualResult += a.Substring(0, a.Length);
                actualResult += b.Substring(0, b.Length);
                actualResult += a.Substring(0, a.Length);
            }
            return actualResult;
        }

        public string RotateLeft2(string str)
        {
            string actualResult = "";
            string holder = str.Substring(0, 2);

            for (int i = 2; i < str.Length; i++)
            {
                actualResult += str.Substring(i, 1);
            }
            actualResult += holder;

            return actualResult;
        }

        public string RotateRight2(string str)
        {
            string actualResult = "";
            string holder = str.Substring(str.Length - 2, 2);
            actualResult += holder;

            for (int i = 0; i < str.Length - 2; i++)
            {
                actualResult += str.Substring(i, 1);
            }
            return actualResult;
        }

        public string TakeOne(string str, bool fromFront)
        {
            string actualResult = "";
            if (fromFront == true)
            {
                actualResult += str.Substring(0, 1);
            }
            else
            {
                actualResult += str.Substring(str.Length - 1, 1);
            }
            return actualResult;
        }

        public string MiddleTwo(string str)
        {
            string actualResult = str.Substring(str.Length/2 - 1, 2);

            return actualResult;
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length < 2)
                return false;

            if (str[str.Length - 2] == 'l' &&
                str[str.Length - 1] == 'y')
            {
                return true;
            }
            return false;
        }

        public string FrontAndBack(string str, int n)
        {
            string actualResult = "";

            actualResult += str.Substring(0, n);

            actualResult += str.Substring(str.Length - n, n);

            return actualResult;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            string actualResult;
            if (n > str.Length - 2)
            {
                actualResult = str.Substring(0, 2);
                return actualResult;
            }
            actualResult = str.Substring(n, 2);
            return actualResult;
        }

        public bool HasBad(string str)
        {
            if (str[0] == 'b' &&
                str[1] == 'a' &&
                str[2] == 'd')
            {
                return true;
            }
            if (str[1] == 'b' &&
                str[2] == 'a' &&
                str[3] == 'd')
            {
                return true;
            }
            return false;
        }

        public string AtFirst(string str)
        {
            string actualResult = "";
            string ands = "@@";

            for (int i = 0; i < 2; i++)
            {
                if (str.Length == i)
                {
                    actualResult += ands.Substring(i, 1);
                }
                else
                {
                    actualResult += str.Substring(i, 1);
                }
            }
            return actualResult;
        }

        public string LastChars(string a, string b)
        {
            string actualResult = "";
            string ands = "@@";

            if (a.Length == 0)
                actualResult += ands.Substring(0, 1);
            else
            {
                actualResult += a.Substring(0, 1);
            }

            if (b.Length == 0)
                actualResult += ands.Substring(1, 1);
            else
            {
                actualResult += b.Substring(b.Length - 1, 1);
            }
            return actualResult;
        }

        public string ConCat(string a, string b)
        {
            string actualResult = a.Substring(0, a.Length);

            if (b.Length==0)
                return actualResult;

            if (a[a.Length - 1] == b[0])
                actualResult += b.Substring(1, b.Length - 1);
            else
            {
                actualResult += b.Substring(0, b.Length);
            }

            return actualResult;
        }

        public string SwapLast(string str)
        {
            string actualResult = "";
            string holder = str.Substring(str.Length-1, 1);
            holder += str.Substring(str.Length - 2, 1);

            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 2)
                {
                    actualResult += holder.Substring(0, 2);
                    return actualResult;
                }
                actualResult += str.Substring(i, 1);
            }
            return actualResult;
        }

        public bool FrontAgain(string str)
        {
            if (str[0] == str[str.Length - 2] &&
                str[1] == str[str.Length - 1])
                return true;

            return false;
        }

        public string MinCat(string a, string b)
        {
            string actualResult = "";
            string smaller;
            if (a.Length > b.Length)
            {
                smaller = a.Substring(a.Length - b.Length, a.Length-(a.Length-b.Length));
                actualResult += smaller;
                actualResult += b;
            }
            else if (b.Length > a.Length)
            {
                smaller = b.Substring(b.Length - a.Length, b.Length - (b.Length - a.Length));
                actualResult += a;
                actualResult += smaller;
            }
            else
            {
                actualResult += a.Substring(0, a.Length);
                actualResult += b.Substring(0, b.Length);
            }
            return actualResult;
        }

        public string TweakFront(string str)
        {
            string actualResult = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    if (str[0] == 'a')
                    {
                        actualResult += str.Substring(0, 1);
                    }
                }
                else if (i == 1)
                {
                    if (str[1] == 'b')
                    {
                        actualResult += str.Substring(1, 1);
                    }
                }
                else
                {
                    actualResult += str.Substring(i, 1);
                }
            }
            return actualResult;
        }

        public string StripX(string str)
        {
            string actualResult = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 ||
                    i == str.Length - 1)
                {
                    if (str[i] != 'x')
                    {
                        actualResult += str.Substring(i, 1);
                    }
                }
                else
                    actualResult += str.Substring(i, 1);
            }
            return actualResult;
        }
    }
}
