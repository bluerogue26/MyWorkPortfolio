using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop.Tests.BLL
{
    public class LoopWarmups
    {
        public string StringTimes(string str, int n)
        {
            string actualResult = "";

            for (int i = 0; i < n; i++)
            {
                actualResult += str;
            }
            return actualResult;
        }

        public string FrontTimes(string str, int n)
        {
            int i = 3;
            string actualResult = "";
            if (str.Length < 3)
                i = str.Length;

            string sub = str.Substring(0, i);

            for (int j = 0; j < n; j++)
            {
                actualResult += sub;
            }
            return actualResult;
        }

        public int CountXX(string str)
        {
            int actualResult = 0;
            for (int i = 0; i < str.Length-1; i++)
            {
                if(str[i] == 'x' && str[i+1] == 'x')
                    actualResult++;
            }
            return actualResult;
        }

        public bool DoubleX(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x') 
                    return true;
            
                else if(str[i]=='x' && str[i+1]!='x')
                    return false;
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string actualResult = "";
            for (int i = 0; i < str.Length; i += 2)
                actualResult += str[i];

            return actualResult;
        }

        public string StringSplosion(string str)
        {
            string actualResult = "";
            for (int i = 1; i < str.Length + 1; i++)
            {
                actualResult += str.Substring(0, i);
            }
            return actualResult;
        }

        public int CountLast2(string str)
        {
            int actualResult = 0;
            string sub = str.Substring(str.Length-2, 2);
            for (int i = 0; i < str.Length -2; i++)
            {
                if (str[i] == sub[0] && str[i + 1] == sub[1])
                    actualResult++;

            }
            return actualResult;

        }

        public int Count9(int[] numbers)
        {
            int actualResult = 0;
            foreach (int num in numbers)
            {
                if (num == 9)
                    actualResult++;

            }
            return actualResult;
        }

        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                    return true;
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                    return true;
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int actualResult=0;
            int dif;
            if (a.Length > b.Length)
                dif = b.Length;
            else
                dif = a.Length;

            for (int i = 0; i < dif-1; i++)
            {
                if (a[i] == b[i] && a[i + 1] == b[i + 1])
                    actualResult++;
            }
            return actualResult;
        }

        public string StringX(string str)
        {
            for (int i = str.Length-2; i > 0; i--)
            {
                if (str[i] == 'x')
                    str = str.Remove(i,1);
                
            }
            string actualResult = str;
            return actualResult;
        }

        public string AltPairs(string str)
        {
            string actualResult = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 ||
                    i == 1 ||
                    i == 4 ||
                    i == 5 ||
                    i == 8 ||
                    i == 9)
                     actualResult += str.Substring(i, 1);
            }
            return actualResult;
        }

        public string DoNotYak(string str)
        {
            for (int i = str.Length-1; i > 1; i--)
            {
                if (str[i] == 'k' &&
                    str[i - 2] == 'y')
                {
                    str = str.Remove(i - 2, 3);
                    i -= 2;
                }
            }
            string actualResult = str;
            return actualResult;
        }

        public int Array667(int[] numbers)
        {
            int actualResult = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i + 1] == 6 || numbers[i + 1] == 7)
                {
                    if (numbers[i] == 6)
                        actualResult++;
                }
            }
            return actualResult;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                    return false;
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] + 5) == numbers[i + 1] &&
                    (numbers[i] - 1 == numbers[i + 2]))
                    return true;
            }
            return false;
        }

    }
}
