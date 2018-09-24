public class Assignment2 {
    public static int findFirstLargerthanK(int[] nums,int k){

        return helper(nums,k,0,nums.length-1);
    }

    public static int helper(int[] nums,int k,int low,int high){
        int mid;
        if(low < high){
            if(nums[low] >k){
                return nums[low];
            }
            if(nums[high] <=k){
                return -1;
            }
            if(low == high -1 && nums[high]>k){
                return nums[high];
            }
            mid = (low+high)/2;
            if(nums[mid]> k ){
                high = mid;
            }
            if(nums[mid] <= k){
                low = mid + 1;
            }
        }
        else{
            return nums[low];
        }
        return helper(nums,k,low,high);
    }


    public static void main(String[] args) {
        int[] nums = {1,3,5,7,10};
        int k =4;
        int res = findFirstLargerthanK(nums,k);
        System.out.println(res);
    }
}
