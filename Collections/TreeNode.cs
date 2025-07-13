namespace Implementations.Trees;

class TreeNode
{
    public TreeNode Left;
    public TreeNode Right;
    public int Value;

    public TreeNode(int val)
    {
        Value = val;
        Left = null;
        Right = null;
    }
}

