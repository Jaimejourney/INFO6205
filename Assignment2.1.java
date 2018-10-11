public class Solution {
    public static class ListNode {
      int val;
      ListNode next;
      ListNode(int x) {
          val = x;
          next = null;
     }


    }
    public static boolean getIntersectionNode(ListNode headA,ListNode headB){
        ListNode curA = headA;
        ListNode curB = headB;
        if(curA == null || curB == null){
            return false;
        }
        while(curA != null && curB != null){
            if(curA == curB && curA!= null){
                return true;
            }
            if(curA == curB && curA == null){
                return false;
            }
            curA = curA.next;
            curB = curB.next;
            if(curA == curB && curA!= null){
                return true;
            }
            if(curA == curB && curA == null){
                return false;
            }
            if(curA == null){
                curA = headB;
            }
            if(curB == null){
                curB = headA;
            }
        }
        return false;
    }

    public static void main(String[] args) {
        ListNode headA = new ListNode(1);
        ListNode headB = new ListNode(2);
        System.out.println(getIntersectionNode(headA,headB));
    }

}
