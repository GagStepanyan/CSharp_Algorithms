using System.Reflection.Metadata.Ecma335;

namespace Implementations.BSTImplement;

class BST
{
    private TreeNode _root;

    public BST()
    {
        _root = null;
    }

    public void Insert(int val)
    {
        if (Search(val))
        {
            Console.WriteLine("Cannot Insert, the value already exists");
            return;
        }
        _root = Insert(_root, val);
    }

    private TreeNode Insert(TreeNode node, int val)
    {
        if (node == null) return new TreeNode(val);

        if (val < node.Value) 
            node.Left = Insert(node.Left, val);
        else if (val > node.Value)
            node.Right = Insert(node.Right, val);

        return node;
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

        // Optional
        return false;
    }


    public void Delete(int val)
    {
        if (!Search(val))
        {
            Console.WriteLine("The Value doesn't exist");
            return;
        }
        _root = Delete(_root, val);
    }

    private TreeNode Delete(TreeNode node, int val)
    {
        if (node == null) return null;
        if (val < node.Value)
            node.Left = Delete(node.Left, val);
        else if (val > node.Value)
            node.Right = Delete(node.Right,val);

        else
        {
            if (node.Left == null)
                return node.Right;
            if (node.Right == null)
                return node.Left;
            else
            {
                TreeNode tmp = GetMin(node.Right);

                (tmp.Value, node.Value) = (node.Value, tmp.Value);
                
                node.Right = Delete(node.Right, tmp.Value);
            }

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
        Console.WriteLine(node.Value);
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
        Console.WriteLine(node.Value);
        InOrderTraversal(node.Right);
    }

    public void PostOrderTraversal()
    {
        TreeNode tmp = _root;
        PostOrderTraversal(tmp);
    }

    private void PostOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.WriteLine(node.Value);
    }

    public TreeNode GetSuccessor(int val)
    {
        if (!Search(val))
        {
            Console.WriteLine("The value doesnt exist... null returned");
            return null;
        }

        TreeNode current = _root;
        TreeNode successor = null;

        while (current != null)
        {
            if (val < current.Value)
            {
                successor = current;
                current = current.Left;
            }
            else if (val > current.Value)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
         }

        if (current == null)
        {
            Console.WriteLine("The successor was not found");
            return null;
        }

        if (current.Right != null)
        {
            successor = GetMin(current.Right);
        }

        return successor;
    }

    public TreeNode GetPredecessor(int val)
    {
        if (!Search(val))
        {
            Console.WriteLine("The value doesnt exist... null returned");
            return null;
        }

        TreeNode current = _root;
        TreeNode predecessor = null;

        while (current != null)
        {
            if (val > current.Value)
            {
                predecessor = current;
                current = current.Right;
            }
            else if (val < current.Value)
            {
                current = current.Left;
            }
            else
            {
                break;
            }
        }
            if (current == null)
            {
                Console.WriteLine("Predecessor was not found... Null returned");
                return null;
            }

            if (current.Left != null)
            {
                predecessor = GetMax(current.Left);
            }

            return predecessor;
    }

    public void PrintTree()
    {
        PrintTree(_root, "", true);
    }

    private void PrintTree(TreeNode node, string indent, bool isRight)
    {
        if (node == null)
            return;

        PrintTree(node.Right, indent + (isRight ? "        " : " |      "), true);

        Console.WriteLine(indent + (isRight ? " /----- " : " \\----- ") + node.Value);

        PrintTree(node.Left, indent + (isRight ? " |      " : "        "), false);

    }

    private int GetDepth(TreeNode node)
    {
        if (node == null) return 0;

        int left = GetDepth(node.Left) + 1;
        int right = GetDepth(node.Right) + 1;

        return Math.Max(left, right);
    }

    public int GetDepth()
    {
        return GetDepth(_root);
    }
}