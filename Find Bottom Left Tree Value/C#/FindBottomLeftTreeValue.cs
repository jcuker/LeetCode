// https://leetcode.com/problems/find-bottom-left-tree-value/description/

/*
    Solution:
        Do a breadth-first-search that processes the right side of the tree first.
*/

// BEGIN CODE
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution 
{    
    public int BFS(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int intLastSeenLeftValue = root.val;
        
        while(q.Count > 0)
        {
            TreeNode current = q.Dequeue();
            
            if(current != null)
            {
                q.Enqueue(current.right);
                q.Enqueue(current.left);
                
                if(current.left == null && current.right != null)
                {
                   intLastSeenLeftValue = current.right.val;
                }
                
                if(current.left != null)
                {
                    intLastSeenLeftValue = current.left.val;
                }
            }
        }
        return intLastSeenLeftValue;
    }
    
    public int FindBottomLeftValue(TreeNode root)
    {
        int intBottomLeftValue = BFS(root);
        
        return intBottomLeftValue;
    }
}