using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Array.Methods
{
    public class ArrayWarmups
    {
        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 ||
                numbers[numbers.Length - 1] == 6)
                return true;

            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length > 1)
            {
                if (numbers[0] == numbers[numbers.Length - 1])
                    return true;
            }
            return false;
        }

        public int[] MakePi(int n)
        {
            int[] actualResult = new int[n];
            for (int i = 0; i < n; i++)
            {
                double piDigit = Math.PI*Math.Pow(10, i);
                double piDigit2 = Math.PI*Math.Pow(10, i - 1);

                piDigit2 = (int) piDigit2 * 10;
                actualResult[i] = (int) piDigit - (int) piDigit2;
            }
            return actualResult;
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] ||
                a[a.Length - 1] == b[b.Length - 1])
                return true;

            return false;

        }

        public int Sum(int[] numbers)
        {
            int actualResult = 0;
            foreach (int num in numbers)
                actualResult += num;

            return actualResult;
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] actualResult= new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                    actualResult[numbers.Length - 1] = numbers[0];
                else
                    actualResult[i - 1] = numbers[i];
            }
            return actualResult;
        }

        public int[] Reverse(int[] numbers)
        {
            int[] actualResult = new int[numbers.Length];
            int i = 0;
            foreach (int num in numbers)
            {
                actualResult[numbers.Length - i - 1] = numbers[i];
                i++;
            }
            return actualResult;
        }

        public int[] HigherWins(int[] numbers)
        {
            int[] actualResult = new int[numbers.Length];
            int higherNum;

            if (numbers[0] > numbers[numbers.Length - 1])
                higherNum = numbers[0];
            else
                higherNum = numbers[numbers.Length - 1];

            for (int i = 0; i < numbers.Length; i++)
                actualResult[i] = higherNum;

            return actualResult;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] actualResult = new int[2];
            int num1 = a[1];
            int num2 = b[1];

            actualResult[0] = num1;
            actualResult[1] = num2;

            return actualResult;
        }

        public bool HasEven(int[] numbers)
        {
            int num1 = numbers[0]%2;
            int num2 = numbers[1]%2;

            if (num1 == 0 ||
                num2 == 0)
                return true;

            return false;
        }

        public int[] KeepLast(int[] numbers)
        {
            int num = numbers[numbers.Length - 1];
            int[]actualResult= new int[numbers.Length*2];
            actualResult[actualResult.Length - 1] = num;
            return actualResult;
        }

        public bool Double23(int[] numbers)
        {
            int count2 = 0;
            int count3 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                    count2++;
                if (numbers[i] == 3)
                    count3++;
            }
            if (count2 == 2 ||
                count3 == 2)
                return true;

            return false;
        }

        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                    numbers[i + 1] = 0;

            }
            int[] actualResult = new int[numbers.Length];
            actualResult = numbers;
            return actualResult;
        }

        public bool Unlucky1(int[] numbers)
        {
            if (numbers[0] == 1 && numbers[1] == 3)
                return true;
            else if (numbers[1] == 1 && numbers[2] == 3)
                return true;
            else if (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3)
                return true;

            return false;
        }

        public int[] Make2(int[] a, int[] b)
        {
            int[] actualResult = new int[2];
            int i = 0;
            if (i == a.Length)
            {
                actualResult[i] = b[i];
                i++;
                actualResult[i] = b[i];
                return actualResult;
            }
            else
            {
                actualResult[i] = a[i];
                i++;
            }
            if (i == a.Length)
            {
                actualResult[i] = b[i-1];
                return actualResult;
            }
            else
                actualResult[i] = a[i];

            return actualResult;
        }
    }
}
