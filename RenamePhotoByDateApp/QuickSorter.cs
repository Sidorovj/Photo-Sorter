using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamePhotoByDateApp
{
    class QuickSorter<T>
        where T : IComparable<T>
    {
        Random rnd = new Random();
        int _ascendingSort;

        public QuickSorter(bool ascendingSort)
        {
            _ascendingSort = ascendingSort ? 1 : -1;
        }

        public T[] Sort(T[] arr)
        {
            StartSort(arr, 0, arr.Length);
            return arr;
        }
        public List<T> Sort(List<T> lst)
        {
            T[] arr = lst.ToArray();
            StartSort(arr, 0, arr.Length-1);
            return arr.ToList();
        }

        private void StartSort(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int randomIndex = rnd.Next(left, right);
                int newIndex = Execute(arr, left, right, randomIndex);

                StartSort(arr, left, newIndex - 1);
                StartSort(arr, newIndex + 1, right);
            }
        }

        private int Execute(T[] arr, int left, int right, int randomIndex)
        {
            T tValue = arr[randomIndex];
            int newIndex = left;
            Swap(arr, right, randomIndex);

            for (var i = left; i < right; i++)
            {
                if (arr[i].CompareTo(tValue) * _ascendingSort < 0)
                {
                    Swap(arr, i, newIndex);
                    newIndex++;
                }
            }
            Swap(arr, newIndex, right);
            return newIndex;

        }

        private void Swap(T[] arr, int ind1, int ind2)
        {
            T tmp = arr[ind1];
            arr[ind1] = arr[ind2];
            arr[ind2] = tmp;
        }
    }
}
