using System;
namespace Implementations.Trees.AVL;

class AVL
{
    private TreeNode _root;

    public AVL()
    {
        _root = null;
    }

    private int GetHeight(TreeNode node)
    {
        if (node == null) return 0;
        int left = GetHeight(node.Left);
        int right = GetHeight(node.Right);

        return Math.Max(left, right) + 1;
    }

    private int GetBalanceFactor(TreeNode node)
    {
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    private TreeNode RotateLeft(TreeNode node)
    {
        TreeNode y = node.Right;
        TreeNode t2 = y.Left;
        y.Left = node;
        node.Right = t2;

        return y;
    }

    private TreeNode RotateRight(TreeNode node)
    {
        TreeNode y = node.Left;
        TreeNode t2 = y.Right;
        y.Right = node;
        node.Left = t2;

        return y;
    }

    public void Insert(int val)
    {
        _root = Insert(_root, val);
    }

    // Helper Method for insertion
    private TreeNode Insert(TreeNode node, int val)
    {
        if (node == null) return new TreeNode(val);

        if (val < node.Value)
            node.Left = Insert(node.Left, val);
         
        else if (val > node.Value)
            node.Right = Insert(node.Right, val);
        else
        {
            Console.WriteLine("Dublicates are not allowed");
            return node;
        }
            int BalanceFactor = GetBalanceFactor(node);

        if (BalanceFactor > 1 && node.Left.Value > val) // Left Left case
        {
            return RotateRight(node);
        }
        if (BalanceFactor > 1 && node.Left.Value < val) // Left Right case
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }
        
        if (BalanceFactor < -1 && node.Right.Value < val) // Right Right case
        {
            return RotateLeft(node);
        }
        if (BalanceFactor < -1 && node.Right.Value > val) // Rigth Left case
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;

    }

    public void Delete(int val)
    {
        _root = Delete(_root, val);
    }
    
    private TreeNode Delete(TreeNode node, int val)
    {
        if (node == null) return null;
        if (val < node.Value)
            node.Left = Delete(node.Left, val);
        else if (val > node.Value)
            node.Right = Delete(node.Right, val);
        else
        {
            if (node.Left == null)
                return node.Right;
            if (node.Right == null)
                return node.Left;

            TreeNode tmp = GetMin(node.Right);
            (tmp.Value, node.Value) = (node.Value, tmp.Value);
            node.Right = Delete(node.Right, val);
        }

        int bf = GetBalanceFactor(node);
        if (bf < -1 && GetBalanceFactor(node.Right) <= 0)
            return RotateLeft(node);
        
        if (bf < -1 && GetBalanceFactor(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        if (bf > 1  && GetBalanceFactor(node.Left) >= 0)
            return RotateRight(node);

        if (bf > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        return node;
    }

    private TreeNode GetMin(TreeNode node)
    {
        while (node.Left != null)
            node = node.Left;

        return node;
    }

    private TreeNode GetMax(TreeNode node)
    {
        while (node.Right != null)
            node = node.Right;

        return node;
    }

    public void PreOrderTraversal()
    {
        TreeNode node = _root;
        PreOrderTraversal(node);
    }

    private void PreOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        Console.Write(node.Value + " ");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    public void InOrderTraversal()
    {
        TreeNode node = _root;
        InOrderTraversal(node);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        InOrderTraversal(node.Left);
        Console.Write(node.Value + " ");
        InOrderTraversal(node.Right);
    }

    public void PostOrderTraversal()
    {
        TreeNode node = _root;
        PostOrderTraversal(node);
    }

    private void PostOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.Write(node.Value + " ");
    }

    public bool Search(int val)
    {
        return Search(_root, val);
    }

    private bool Search(TreeNode node, int val)
    {
        if (node == null) return false;
        if (val == node.Value) return true;
        if (val > node.Value) return Search(node.Right, val);
        if (val < node.Value) return Search(node.Left, val);

        return false;
    }
}
