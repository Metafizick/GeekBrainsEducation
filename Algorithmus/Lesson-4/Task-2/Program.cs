using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Node headNode = new Node { Data = 0, Left = null, Right = null, Parent = null };
            BinaryTree newTree = new BinaryTree(headNode);
            int[] data = new int[10]; 
            for (int i = 0; i < 10; i++)
            {
                data[i] = new Random().Next(20);
            }
            for (int i = 0; i < 10; i++)
            {
                newTree.Insert(newTree.head, data[i]);
            
            }
            newTree.PreOrderTravers(newTree.head);
            int search = new Random().Next(20);
            var searchNode = newTree.GetNodeByValue(newTree.head, search);
            if (searchNode != null)
            {
                Console.WriteLine(searchNode.Data);
                newTree.DeleteByValue(newTree.head, search);
            } else
            {
                Console.WriteLine("Searchable item not found");
            }
            var minNode = newTree.GetMinNode(newTree.head);
            Console.WriteLine(minNode.Data);
            var maxNode = newTree.GetMaxNode(newTree.head);
            Console.WriteLine(maxNode.Data);
            newTree.PreOrderTravers(newTree.head);
        }

    }
}
