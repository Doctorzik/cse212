public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1


        if (value < Data)
        {

            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
              if (value == Left.Data)
            {
                return;
            }
            else
            {
                Left.Insert(value);

            }
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
         if (value == Right.Data)
            {
                return;
            }
            else
            {
                Right.Insert(value);

            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
            return true;

        // If the value is less than the current node's data, search in the left subtree
        else if (value < Data && Left != null)
            return Left.Contains(value);

        // If the value is greater than the current node's data, search in the right subtree
        else if (value > Data && Right != null)
            return Right.Contains(value);

        // If the value is not found and no more nodes are left to check
        return false;

    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Base case: If the node has no children, return 1
        if (Left == null && Right == null)
            return 1;

        int leftHeight = 0;
        int rightHeight = 0;

        if (Left != null)
            leftHeight = Left.GetHeight();

        // Recursive case to calculate the height of the right subtree if it exists 
        if (Right != null)
            rightHeight = Right.GetHeight();

        // The height of the current node is 1 plus the maximum height of its subtrees
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}