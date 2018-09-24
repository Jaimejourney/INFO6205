using System;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3,8,4,2,6,5,7,9};
            SortWaveFormLinear(arr);

            int index  = FindPeakElement(arr);
            //int minIndex = MinRotated(arr);
            bool exists = BinSearchRecursive(arr, 43);
            PancakeSort(arr);
            Console.WriteLine("Hello World!");
        }

        static void PancakeSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                int mi = FindMaxIndex(arr, arr.Length - i - 1);
                if (mi != arr.Length - i - 1)
                {

                    Flip(arr, mi);
                    Flip(arr, arr.Length - i - 1);
                }

            }
        }
        static void Flip(int[] arr, int i)
        {

            int temp, start = 0;

            while (start < i)
            {

                temp = arr[start];
                arr[start] = arr[i];
                arr[i] = temp;
                start++;
                i--;
            }
        }

        static int FindMaxIndex(int[] arr, int end)
        {
            int max_index = 0;
            for (int i = 0; i < end; i++)
            {

                if (arr[max_index] < arr[i])
                    max_index = i;
            }

            return max_index;
        }

        static void Reverse(int[] arr, int start, int end)
        {

            int temp;

            while (end > start)
            {

                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        static void Rotate(int[] arr, int n)
        {

            Reverse(arr, 0, arr.Length - 1);
            Reverse(arr, 0, n - 1);
            Reverse(arr, n, arr.Length - 1);
        }


        static bool BinarySearch(int[] arr, int x)
        {

            if (arr.Length == 0)
                return false;

            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == x)
                {
                    return true;
                }
                else if (arr[mid] > x)
                {
                    high = mid - 1;
                }
                else
                {

                    low = mid + 1;
                }
            }
            return false;
        }


        static bool BinSearchRecursive(int[] arr, int x)
        {
            return BinSearchRecursive(arr, 0, arr.Length -1, x);
        }

        static bool BinSearchRecursive(int[] arr, int low, int high, int x){

            if(low > high)
                return false;
            int mid = (low + high)/2;
            if(arr[mid] == x){
                return true;
            }
            else if(arr[mid] > x){
                return BinSearchRecursive(arr, low, mid-1, x);
            } 
            else{
                return BinSearchRecursive(arr, mid+1, high, x);
            } 
            
        }

        static int MinRotated(int[] arr){

            int low = 0; 
            int high = arr.Length -1;
            while(arr[low] > arr[high]){

                int mid = (low + high)/2;

                if(arr[mid] > arr[high]){
                    // the array is not properly sorted from mid to high
                    low = mid +1;
                }else{

                    high = mid;
                }
            }

            return low;
        }

        static bool SearchInRotatedArray(int[] arr, int x){

            int minIndex = MinRotated(arr);
            if( x > arr[minIndex -1] )
                return false;
            if(x < arr[arr.Length -1]){
                return BinSearchRecursive(arr, minIndex, arr.Length -1, x);
            }
            else
                return BinSearchRecursive(arr, 0, minIndex -1, x);

        }

        static int SearchInRotatedArr(int[] arr, int low, int high, int x){

            if(low > high)
                return -1;
            int mid = (low + high)/2;
            if(arr[mid] == x)
                return mid;
            
            if(arr[low] <= arr[mid]){
                // First part is properly sorted
                if(x >= arr[low] && x <= arr[mid]){
                    // value to be searched is inside low and mid
                    return SearchInRotatedArr(arr, low, mid-1, x);
                }
                return SearchInRotatedArr(arr, mid+1, high, x);

            }

            if(x >= arr[mid] && x <= arr[high])
                return SearchInRotatedArr(arr, mid +1, high, x);
            
            return SearchInRotatedArr(arr, low, mid-1, x);
        }


        static int FindFirstIndex(int[] arr, int x){

            return FindFirstIndex(arr, 0, arr.Length -1, x);
        }

        static int FindFirstIndex(int[] arr,int low, int high, int x){
            if( low > high)
                return -1;
            if(arr[low] > x)
                return -1;
            if(arr[high] < x)
                return -1;
            if(arr[low] == x)
                return low;
            int mid = (low + high)/2;

            if(arr[mid] == x){
                return FindFirstIndex(arr, low, mid, x);
            }
            else if(arr[mid] < x){
                return FindFirstIndex(arr, mid +1, high, x);

            }else{
                return FindFirstIndex(arr, low, mid-1, x);

            }
        }

        static int GetTotalOccurances(int[] arr, int x){
            return GetTotalOccurances(arr, 0, arr.Length -1, x);

        }

        static int GetTotalOccurances(int[] arr, int low, int high, int x){
            if(low > high)
                return 0;
            
            if(arr[low] > x)
                return 0;
            if(arr[high] <x)
                return 0;
            if(arr[low] == x && arr[high] == x)
                return high -low +1;
            int mid = (high + low)/2;
            if(arr[mid] == x){
                return 1 + GetTotalOccurances(arr, low, mid-1, x) 
                         + GetTotalOccurances(arr, mid +1, high, x) ;
            }else if(arr[mid]  < x){
               return GetTotalOccurances(arr, mid+1, high, x);
            }
            else{
                return GetTotalOccurances(arr, low, mid-1, x);
            }

        }


        static int FindFirstLargerThanK(int[] arr, int k){
            int result = -1;
            int start = 0; int end = arr.Length -1; 

            while(start <= end){
                int mid = (start + end)/2;

                if(arr[mid] > k){
                    result = mid;
                    end = mid-1;
                }else{

                    start = mid +1;
                }
            }
            return result;


        }

        static int FindPeakElement(int[] arr){

            return FindPeakElement(arr, 0, arr.Length -1);
        }
        static int FindPeakElement(int[] arr, int low, int high){

            int mid = (low + high)/2;
            if(arr[mid] > arr[mid-1] &&  arr[mid] > arr[mid+1])
                return mid;
            
            if(arr[mid] > 0 && arr[mid-1] > arr[mid])
                return FindPeakElement(arr,low, mid-1 );
            else
                return FindPeakElement(arr,mid+1, high );
        }

        static void SortWaveForm(int[] arr){
            Array.Sort(arr);
            int temp;
            for(int i = 0; i < arr.Length -1; i = i +2){
                temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;

            }

        }

        static void SortWaveFormLinear(int[] arr){

            int temp;

            for(int i = 0 ; i < arr.Length; i = i+2){

                if(i > 0 && arr[i-1] > arr[i]){
                    temp = arr[i-1];
                    arr[i-1] = arr[i];
                    arr[i] = temp;

                }

                if( i < arr.Length -1 && arr[i+1] > arr[i]){
                    temp = arr[i+1];
                    arr[i+1] = arr[i];
                    arr[i] = temp;

                }
            }
        }


        


    }
}
