using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Methods
{
    public class ConditionWarmups
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
                return true;

            return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if(isWeekday==false||
                isVacation==true)
                return true;

            return false;
        }

        public int SumDouble(int a, int b)
        {
            int actualResult = 0;
            if (a == b)
                actualResult = (a + b)*2;
            else
                actualResult = a + b;
            return actualResult;
        }

        public int Diff21(int n)
        {
            int actualResult = 0;
            if (n > 21)
            {
                actualResult = Math.Abs(n - 21);
                actualResult = actualResult*2;
            }
            else
            {
                actualResult = Math.Abs(n - 21);
            }
            return actualResult;
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == false)
                return false;

            if (hour < 7 ||
                hour > 20)
                return true;

            return false;
        }

        public bool Makes10(int a, int b)
        {
            int sum = a + b;
            if (a == 10 ||
                b == 10 ||
                sum == 10)
                return true;

            return false;
        }

        public bool NearHundred(int n)
        {
            int near100 = Math.Abs(n - 100);
            int near200 = Math.Abs(n - 200);

            if (near100 <= 10 ||
                near200 <= 10)
                return true;

            return false;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative == true)
            {
                if (a < 0 && b < 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (a < 0 || b < 0)
                    return true;
                else
                    return false;
            }

        }

        public string NotString(string s)
        {
            string actualResult = "";
            if (s[0] == 'n' &&
                s[1] == 'o' &&
                s[2] == 't')
            {
                actualResult = s;
                return actualResult;
            }

            actualResult = "not ";
            string sub = s.Substring(0, s.Length);
            actualResult = actualResult + sub;

            return actualResult;
        }

        public string MissingChar(string str, int n)
        {
            string actualResult = "";
            actualResult = str.Remove(n, 1);
            return actualResult;
        }

        public string FrontBack(string str)
        {
            string actualResult = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    actualResult += str.Substring(str.Length - 1, 1);
                }
                else if (i == str.Length-1)
                {
                    actualResult += str.Substring(0, 1);
                }
                else
                {
                    actualResult += str.Substring(i, 1);
                }
            }
            return actualResult;
        }

        public string Front3(string str)
        {
            string actualResult = "";
            if (str.Length < 3)
            {
                actualResult += str;
                actualResult += str;
                actualResult += str;
                return actualResult;
            }
            actualResult += str.Substring(0, 3);
            actualResult += actualResult;
            actualResult += str.Substring(0, 3);

            return actualResult;
        }

        public string BackAround(string str)
        {
            string actualResult = "";
            string holder = str.Substring(str.Length - 1, 1);
            actualResult += holder;
            actualResult += str;
            actualResult += holder;
            return actualResult;
        }

        public bool Multiple3Or5(int number)
        {
            if (number%3 == 0 ||
                number%5 == 0)
            {
                return true;
            }
            return false;
        }

        public bool StartHi(string str)
        {
            if (str.Length < 3)
            {
                if (str[0] == 'h' &&
                    str[1] == 'i')
                    return true;
            }
            else if (str[0] == 'h' &&
                str[1] == 'i'&&
                str[2]== ' ')
                return true;

            return false;
        }

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 > 100 &&
                temp2 < 0)
            {
                return true;
            }
            else if (temp1 < 0 &&
                     temp2 > 100)
            {
                return true;
            }
            return false;
        }

        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20 ||
                b >= 10 && b <= 20)
                return true;

            return false;
        }

        public bool HasTeen(int a, int b, int c)
        {
            if (a >= 13 &&
                a <= 19)
                return true;

            if (b >= 13 &&
                b <= 19)
                return true;

            if (c >= 13 &&
                c <= 19)
                return true;

            return false;
        }

        public bool SoAlone(int a, int b)
        {
            if (a >= 13 &&
                a <= 19)
            {
                if (b >= 13 &&
                    b <= 19)
                    return false;
                else
                {
                    return true;
                }
            }

            if (b >= 13 &&
                b <= 19)
                return true;

            return false;
        }

        public string RemoveDel(string str)
        {
            string actualResult = "";
            if (str[1] == 'd' &&
                str[2] == 'e' &&
                str[3] == 'l')
            {
                str = str.Remove(1, 3);
            }
            actualResult = str;
            return actualResult;
        }

        public bool IxStart(string str)
        {
            if (str[1] == 'i' &&
                str[2] == 'x')
                return true;

            return false;
        }

        public string StartOz(string str)
        {
            string actualResult = "";
            if (str[0] == 'o')
            {
                actualResult += str.Substring(0, 1);
            }

            if (str[1] == 'z')
            {
                actualResult += str.Substring(1, 1);
            }

            return actualResult;
        }

        public int Max(int a, int b, int c)
        {
            int actualResult;
            if (a > b && a > c)
            {
                actualResult = a;
            }
            else if (b > a && b > c)
            {
                actualResult = b;
            }
            else if (c > a && c > b)
            {
                actualResult = c;
            }
            else
            {
                actualResult = a;
            }

            return actualResult;
        }

        public int Closer(int a, int b)
        {
            int actualResult;
            int closeA = 0;
            int closeB = 0;

            closeA = Math.Abs(a - 10);
            closeB = Math.Abs(b - 10);

            if (closeA < closeB)
            {
                actualResult = a;
            }
            else if (closeB < closeA)
            {
                actualResult = b;
            }
            else
            {
                actualResult = 0;
            }

            return actualResult;
        }

        public bool GotE(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                {
                    count++;
                }
            }
            if (count > 0 &&
                count < 4)
            {
                return true;
            }
            return false;
        }

        public string EndUp(string str)
        {
            string actualResult = "";
            string holder = str.ToUpper();
            if (str.Length < 3)
            {
                actualResult = str.ToUpper();
                return actualResult;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (i >= str.Length - 3)
                {
                    actualResult += holder.Substring(i, 1);
                }
                else 
                    actualResult += str.Substring(i, 1);

            }

            return actualResult;
        }

        public string EveryNth(string str, int n)
        {
            string actualResult = "";

            for (int i = 0; i < str.Length; i += n)
            {
                actualResult += str.Substring(i, 1);
            }

            return actualResult;
        }
    }
}
