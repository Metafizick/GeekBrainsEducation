using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Node headNode = new Node { Data = 10, Left = null, Right = null, Parent = null };
            BinaryTree newTree = new BinaryTree(headNode);
            int[] data = new int[8];
            /*for (int i = 0; i < 20; i++)
            {
                data[i] = new Random().Next(20);
            }*/
            data[0] = 6;
            data[1] = 8;
            data[2] = 3;
            data[3] = 5;
            data[4] = 2;
            data[5] = 9;
            data[6] = 1;
            data[7] = 4;
            for (int i = 0; i < 8; i++)
            {
                newTree.Insert(newTree.head, data[i]);
            
            }
            newTree.PreOrderTravers(newTree.head);
            Console.WriteLine();
            //int search = new Random().Next(20);
            int search = 4;
            var searchNodeByBfs = newTree.GetNodeByBfs(newTree.head, search);
            if (searchNodeByBfs != null)
                Console.WriteLine($"SearchItem = {searchNodeByBfs.Data}");
            var searchNodeDyBfs = newTree.GetNodeByDfs(newTree.head, search);
            if (searchNodeDyBfs != null)
                Console.WriteLine($"SearchItem = {searchNodeDyBfs.Data}");
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
