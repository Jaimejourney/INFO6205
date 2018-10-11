import org.w3c.dom.NodeList;

public class Solution {
    public static class DListNode {
        int val;
        DListNode next;
        DListNode prev;
        DListNode(int x) {
            val = x;
            next = null;
            prev = null;
        }

        public static void addDListNode(DListNode node,DListNode tmp){
            while(node.next != null){
                if(node.val < tmp.val){
                    node = node.next;
                }
                else{
                    if(node.prev != null) {
                        node.prev.next = tmp;
                        node.prev = tmp;
                        tmp.next = node;
                        break;
                    }
                    else{
                        node.prev = tmp;
                        tmp.next = node;
                        break;
                    }
                }
            }
            if(node.next == null){
                node.next = tmp;
                tmp.prev = node;
            }
        }

        public static void main(String[] args) {
            DListNode node = new DListNode(2);
            DListNode node1 =  new DListNode(3);
            DListNode node2 = new DListNode(5);
            node.next = node1;
            node1.prev = node;
            node1.next = node2;
            node2.prev = node1;
            DListNode node3 = new DListNode(8);
            addDListNode(node,node3);
        }
    }
}
