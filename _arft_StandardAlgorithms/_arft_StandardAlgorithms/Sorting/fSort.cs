using System;
using System.Collections.Generic;
using System.Text;

namespace _arft_StandardAlgorithms.Sorting
{
    public static class fSort
    {
        #region MergeSort
        //base
        public static void MergeSort<T>
            (this T[] a)
            where T : IComparable
        {
            MergeSort<T>
            (
                a: a,
                low: 0,
                high: a.Length
            );
        }

        public static void MergeSort<T>
            (this T[] a, int low, int high)
            where T : IComparable
        {
            var n = high - low;
            if (n <= 1) return;

            var mid = low + n / 2;

            MergeSort<T>(a, low, mid);
            MergeSort<T>(a, mid, high);

            var buff = new T[n];
            int i = low, j = mid;
            for (int k = 0; k < n; ++k)
            {
                if (i == mid) buff[k] = a[j++];
                else if (j == high) buff[k] = a[i++];
                else if (a[j].CompareTo(a[i]) < 0) buff[k] = a[j++];
                else buff[k] = a[i++];
            }
            for (int k = 0; k < n; ++k)
                a[low + k] = buff[k];
        }
        #endregion

        #region InsertionSort
        //base
        public static void InsertionSort<T>
            (this T[] a)
            where T : IComparable
        {
            InsertionSort<T>
            (
                a: a,
                low: 0,
                high: a.Length                 
            );
        }
        
        public static void InsertionSort<T>
            (this T[] a, int low, int high)
            where T : IComparable
        {
            void swap<T> (ref T f, ref T s)
            {
                T temp;
                temp = f;
                f = s;
                s = temp;
            }

            for (var i = low + 1; i < high; ++i)
            {
                var j = i;
                while (j > low && a[j - 1].CompareTo(a[j]) > 0)
                {
                    swap(ref a[j], ref a[j - 1]);
                    --j;
                }
            }
        }
        #endregion

        #region QuickSort
        //base (Lomuto)
        public static void QuickSort<T>
            (this T[] a)
            where T : IComparable
        {
            QuickSort<T>
            (
                a: a,
                low: 0,
                high: a.Length - 1
            );
        }
        public static void QuickSort<T>
            (this T[] a, int low, int high)
            where T : IComparable
        {
            if (low < high)
            {
                var p = partition<T>(a, low, high);
                QuickSort(a, low, p - 1);
                QuickSort(a, p + 1, high);
            }
        }
        private static Int32 partition<T>
            (T[] a, int low, int high)
            where T : IComparable
        {
            void swap<T>(ref T f, ref T s)
            {
                T temp;
                temp = f;
                f = s;
                s = temp;
            }

            var pivot = a[high];
            var i = low;
            for(var j = low; j < high; ++j)            
                if(a[j].CompareTo(pivot) < 0)                
                    swap(ref a[i++], ref a[j]); 
            swap(ref a[i], ref a[high]);
            return i;
        }
        #endregion
    }
}
