public class Assignment1 {
    public static int FindFloor(int[] nums,int n){
        int low = 0;
        int high = nums.length-1;
        int mid;
        while(low < high) {
            if (n < nums[low]) {
                return -1;
            }
            if (n > nums[high]) {
                return nums[high];
            }
            if(low == high - 1 && nums[low] < n){
                return nums[low];
            }
            mid = (low + high)/2;
            if(n <= nums[mid]){
                high = mid-1;
            }
            if(n > nums[mid]){
                low = mid;
            }

        }

        return nums[low];


    }

    public static void main(String[] args) {
        int[] nums ={1,3,5,7,8};
        int res = FindFloor(nums,6);
        System.out.println(res);
    }
}
