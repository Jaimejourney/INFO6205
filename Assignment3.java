package Algorithm;

import java.lang.reflect.Array;
import java.util.*;

public class BinaryTree {
    public static class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;

        TreeNode(int x) {
            val = x;
        }
    }

    /**
     * 1. Print Bottom View of Binary Tree in order from Left to right
     */

    public static void bottomView(TreeNode root) {
        if (root == null) {
            System.out.println("The root is null");
            return;
        }
        HashMap<TreeNode, Integer> hashMap = new HashMap<>();
        bottomView(root, hashMap, 0);

        TreeMap<Integer, Integer> treeMap = new TreeMap<>();
        Queue<TreeNode> queue = new ArrayDeque<>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                TreeNode tmp = queue.poll();
                int pos = hashMap.get(tmp);
                treeMap.put(pos, tmp.val);

                if (tmp.left != null)
                    queue.offer(tmp.left);
                if (tmp.right != null)
                    queue.offer(tmp.right);
            }
        }

        for (Map.Entry<Integer, Integer> entry : treeMap.entrySet()) {
            System.out.print(entry.getValue() + ", ");
        }
        System.out.println();
    }

    public static void bottomView(TreeNode root, HashMap<TreeNode, Integer> hashMap, int pos) {
        if (root == null) return;
        hashMap.put(root, pos);
        bottomView(root.left, hashMap, pos - 1);
        bottomView(root.right, hashMap, pos + 1);
    }

    /**
     * 2. Get Max Width of a Tree
     */

    public static int maxWidth(TreeNode root) {
        if (root == null) return 0;
        Queue<TreeNode> queue = new ArrayDeque<>();
        queue.offer(root);
        int max = 1;
        while (!queue.isEmpty()) {
            int size = queue.size();
            max = Math.max(max, size);
            for (int i = 0; i < size; i++) {
                TreeNode tmp = queue.poll();
                if (tmp.left != null)
                    queue.offer(tmp.left);
                if (tmp.right != null)
                    queue.offer(tmp.right);
            }
        }
        return max;
    }

    /**
     * 3. Print Top View of tree with no repetition of the root
     */

    public static void topView(TreeNode root) {
        if (root == null) {
            System.out.println("The root is null");
            return;
        }
        TreeMap<Integer, Integer> treeMap = new TreeMap<>();
        topView(root, treeMap, 0, 0);
        for (Map.Entry<Integer, Integer> entry : treeMap.entrySet()) {
            System.out.print(entry.getValue() + ", ");
        }

        System.out.println();
    }

    public static void topView(TreeNode root, TreeMap<Integer, Integer> treeMap, int left, int right) {
        if (root == null) return;
        if (left == 0 && right == 0)
            treeMap.put(0, root.val);
        if (left == 0 && !treeMap.containsKey(right)) {
            treeMap.put(right, root.val);
        }
        if (right == 0 && !treeMap.containsKey(left)) {
            treeMap.put(left, root.val);
        }
        topView(root.left, treeMap, left - 1, right);
        topView(root.right, treeMap, left, right + 1);
    }

}
