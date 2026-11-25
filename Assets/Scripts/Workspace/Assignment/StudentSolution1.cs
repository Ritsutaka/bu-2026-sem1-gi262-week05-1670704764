using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            int[] arr = (int[])numbers.Clone();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            return arr;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            int[] arr = (int[])numbers.Clone();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) break; 
            }

            return arr;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            int[] arr = (int[])numbers.Clone();

            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }

            return arr;
        }

        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            int[] arr = (int[])numbers.Clone();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[maxIndex])
                        maxIndex = j;
                }

                int temp = arr[i];
                arr[i] = arr[maxIndex];
                arr[maxIndex] = temp;
            }

            return arr;
        }

        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            int[] arr = (int[])numbers.Clone();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }

            return arr;
        }

        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            int[] arr = (int[])numbers.Clone();

            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }

            return arr;
        }

        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            bool hasLargest = false;
            bool hasSecond = false;
            int largest = 0;
            int second = 0;

            foreach (int n in numbers)
            {
                if (!hasLargest || n > largest)
                {
                    if (hasLargest)
                    {
                        second = largest;
                        hasSecond = true;
                    }
                    largest = n;
                    hasLargest = true;
                }
                else if (n < largest && (!hasSecond || n > second))
                {
                    second = n;
                    hasSecond = true;
                }
            }

            return hasSecond ? second : 0;
        }

        #endregion

        #region Extra

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return 0;

            int[] sorted = LCT01_SelectionSortAscending(numbers);

            int longest = 1;
            int current = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] == sorted[i - 1])
                    continue;

                if (sorted[i] == sorted[i - 1] + 1)
                    current++;
                else
                    current = 1;

                if (current > longest)
                    longest = current;
            }

            return longest;
        }

        #endregion
    }
}
