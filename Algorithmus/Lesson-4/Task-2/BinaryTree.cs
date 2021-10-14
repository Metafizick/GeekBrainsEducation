using System;

public class BinaryTree
{
	public Node head { get; set; }
    
	public BinaryTree()
		{
		head = null;
		}
	public BinaryTree(Node Head)
    {
		head = Head;
    }
	public Node GetFreeNode (int value, Node parent)
    {
		Node tmp = new Node();
		tmp.Data = value;
		tmp.Left = null;
		tmp.Right = null;
		tmp.Parent = parent;
		return tmp;
    }
    public  Node Insert(Node head, int value)
    {
        Node tmp = null;
        if (head == null)
        {
            head = GetFreeNode(value, null);
            return head;
        }

        tmp = head;
        while (tmp != null)
        {
            if (value >= tmp.Data)
            {
                if (tmp.Right != null)
                {
                    tmp = tmp.Right;
                    continue;
                }
                else
                {
                    tmp.Right = GetFreeNode(value, tmp);
                    return head;
                }
            }
            else if (value < tmp.Data)
            {
                if (tmp.Left != null)
                {
                    tmp = tmp.Left;
                    continue;
                }
                else
                {
                    tmp.Left = GetFreeNode(value, tmp);
                    return head;
                }
            }
            /*else
            {
                throw new Exception("Wrong tree state");                  // Дерево построено неправильно
            }*/
        }
        return head;
    }
    public Node GetNodeByValue(Node head, int value)
    {
        while (head != null)
        {
            if (value > head.Data)
            {
                head = head.Right;
                continue;           
            }else if (value < head.Data)
            {
                head = head.Left;
                continue;
            } else
            {
                return head;
            }
        } return null;
    }
    public Node GetMinNode(Node head)
    {
        while (head.Left != null)
        {
            head = head.Left;
        }
        return head;
    }
    public Node GetMaxNode(Node head)
    {
        while (head.Right != null)
        {
            head = head.Right;
        }
        return head;
    }
    public void RemoveNodeByPtr(Node target)
    {
        if ((target.Left != null)&&(target.Right != null))
        {
            Node localMax = GetMaxNode(target.Left);
            target.Data = localMax.Data;
            RemoveNodeByPtr(localMax);
            return;
        }
        else if (target.Left!=null)
        {
            if (target == target.Parent.Left)
            {
                target.Parent.Left = target.Left;
            }
            else
            {
                target.Parent.Right = target.Left;
            }
        }
        else if (target.Right!=null)
        {
            if (target == target.Parent.Right)
            {
                target.Parent.Right = target.Right;
            }
            else
            {
                target.Parent.Left = target.Right;
            }
        }
        else
        {
            if (target == target.Parent.Left)
            {
                target.Parent.Left = null;
            }
            else
            {
                target.Parent.Right = null;
            }
        }
    }
    public void DeleteByValue(Node head, int value)
    {
        Node target = GetNodeByValue(head, value);
        RemoveNodeByPtr(target);
    }
    public void PreOrderTravers(Node root, string s = "")
    {
        if (root != null)
        {
            Console.Write(root.Data); 
            if (root.Left != null || root.Right != null)
            {
                Console.Write("(");
                if (root.Left != null) PreOrderTravers(root.Left);
                else Console.Write("NIL");
                Console.Write(",");
                if (root.Right != null) PreOrderTravers(root.Right);
                else Console.Write("NIL");
                Console.Write(")");
            }
        }
    }
}

