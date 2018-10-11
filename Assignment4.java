import java.util.*;
import java.util.logging.Level;

public class Solution {
    public static class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;

        TreeNode(int x) {
            val = x;
        }
    }
    /**
     * 1. Print all Full Nodes in a binary tree
     */
    public static List<TreeNode> printAllFullNodes(TreeNode root){
        List<TreeNode> res = new ArrayList<>();
        Queue<TreeNode> queue = new LinkedList<>();
        queue.offer(root);
        while(!queue.isEmpty()){
            int levelnum = queue.size();
            for (int i = 0; i < levelnum; i++) {
                TreeNode node = queue.poll();
                if(node.left!= null && node.right!= null){
                    res.add(node);
                }
                if(node.left!=null) queue.offer(node.left);
                if(node.right!=null) queue.offer(node.right);
            }
        }
        return res;
    }

    /**
     * 2. Print Middle level for  a perfect tree
     */

    public static List<TreeNode> printMiddleLevel(TreeNode root){
        List<TreeNode> res= new ArrayList<>();
        TreeNode fast = root;
        int count = 1;
        while(fast.left!=null && fast.left.left!=null){
            fast = fast.left.left;
            count ++;
        }
        List<List<TreeNode>> tmp = levelOrder(root);
        return tmp.get(count-1);
    }

    public static List<List<TreeNode>> levelOrder(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        List<List<TreeNode>> res = new ArrayList<List<TreeNode>>();
        if(root == null){
            return res;
        }
        queue.offer(root);
        while(!queue.isEmpty()){
            int levelNum =queue.size();
            List<TreeNode> Sublist = new ArrayList<>();
            for (int i = 0; i <levelNum ; i++) {
                TreeNode node = queue.poll();
                Sublist.add(node);
                if(node.left != null){
                    queue.offer(node.left);
                }
                if(node.right != null){
                    queue.offer(node.right);
                }
            }
            res.add(Sublist);
        }
        return res;
    }

    /**
     * 2. Check if all Leaves are at same level
     */

    public static boolean checkAllLeaves(TreeNode root){
        Queue<TreeNode> queue = new LinkedList<>();
        Set<Integer> set = new HashSet<>();
        queue.offer(root);
        int level = 0;
        while(!queue.isEmpty()){
            level++;
            int levelNum = queue.size();
            for (int i = 0; i < levelNum; i++) {
                TreeNode node = queue.poll();
                if(node.left == null && node.right == null){
                    set.add(level);
                }
                if(node.left!=null) queue.offer(node.left);
                if(node.right!=null) queue.offer(node.right);
            }
        }
        return set.size() == 1;
    }


    public static void main(String[] args) {
        TreeNode node = new TreeNode(1);
        node.left = new TreeNode(2);
        node.right = new TreeNode(3);
        node.left.left = new TreeNode(4);
        node.left.right = new TreeNode(5);
        node.right.left = new TreeNode(6);
        node.right.right = new TreeNode(7);
        System.out.println(printAllFullNodes(node));
        System.out.println(printMiddleLevel(node));
        System.out.println(checkAllLeaves(node));
    }
}
