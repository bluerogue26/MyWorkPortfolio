using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Methods
{
    public class LogicWarmups
    {
        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (isWeekend == true)
            {
                if (cigars >= 40)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (cigars >= 40 &&
                    cigars <= 60)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int actualResult;
            if (yourStyle <= 2 ||
                dateStyle <= 2)
            {
                actualResult = 0;
                return actualResult;
            }
            else if (yourStyle >= 8 ||
                     dateStyle >= 8)
            {
                actualResult = 2;
                return actualResult;
            }
            else
            {
                actualResult = 1;
                return actualResult;
            }

        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer == true)
            {
                if (temp >= 60 &&
                    temp <= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (temp >= 60 &&
                    temp <= 90)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int actualResult;
            if (isBirthday == true)
            {
                if (speed <= 65)
                {
                    return actualResult = 0;
                }
                else if (speed > 65 &&
                         speed <= 85)
                {
                    return 1;
                }
                else
                {
                    return actualResult = 2;
                }
            }
            else
            {
                if (speed <= 60)
                {
                    return actualResult = 0;
                }
                else if (speed > 60 &&
                         speed <= 80)
                {
                    return actualResult = 1;
                }
                else
                {
                    return actualResult = 2;
                }
            }
        }

        public int SkipSum(int a, int b)
        {
            int actualResult;
            int sum = a + b;

            if (sum >= 10 &&
                sum <= 19)
                return 20;

            actualResult = sum;
            return actualResult;
        }

        public string AlarmClock(int day, bool vacation)
        {
            if (vacation == true &&
                day == 0 || day == 6)
            {
                return "off";
            }
            else if (vacation == true &&
                     day > 0 && day < 6)
            {
                return "10:00";
            }
            else if (vacation == false &&
                     day == 0 || day == 6)
            {
                return "10:00";
            }
            else
            {
                return "7:00";
            }
        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 ||
                b == 6 ||
                a + b == 6 ||
                a - b == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode == true)
            {
                if (n <= 1 ||
                    n >= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (n >= 1 &&
                    n <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SpecialEleven(int n)
        {
            if (n%11 == 0 ||
                n%11 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Mod20(int n)
        {
            if (n%20 == 1 ||
                n%20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Mod35(int n)
        {
            if (n%3 == 0 &&
                n%5 == 0)
            {
                return false;
            }
            else if (n%3 == 0)
            {
                return true;
            }
            else if (n%5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep == true)
            {
                return false;
            }
            else if (isMorning == true)
            {
                if (isMom == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c)
            {
                return true;
            }
            else if (b + c == a)
            {
                return true;
            }
            else if (c + a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk == true)
            {
                if (c > b)
                {
                    return true;
                }
                else 
                    return false;
            }
            else
            {
                if (c > b &&
                    b > a)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk == true)
            {
                if (a <= b && b <= c)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (a < b && b < c)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool LastDigit(int a, int b, int c)
        {
            if (a%10==b%10)
                return true;
            else if (a%10==c%10)
                return true;
            else if (b%10==c%10)
                return true;
            else
            {
                return false;
            }
        }

        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (noDoubles == true)
            {

                if (die1 == die2)
                {
                    if (die1 == 6)
                    {
                        die1 = 1;
                    }
                    else
                    {
                        die1++;
                    }
                }
            }

            int sum = die1 + die2;
            int actualResult = sum;
            return actualResult;
        }
    }
}
