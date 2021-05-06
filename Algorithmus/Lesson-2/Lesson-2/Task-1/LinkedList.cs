using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class LinkedList: ILinkedList
    {
       private Node _startnode = new Node();
       private Node _lastnode = new Node();

        public LinkedList(Node startnode, Node lastnode)
        {
            _startnode = startnode;
            _lastnode = lastnode;
        }
        public void AddNode(int value)
        {
            var newNode = new Node { Value = value };
            newNode.PrevNode = _lastnode;
            _lastnode.NextNode = newNode;
            _lastnode = newNode;
            
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            newNode.NextNode = node.NextNode;
            newNode.PrevNode = node;
            node.NextNode = newNode;
        }

        public Node FindNode(int searchValue)
        {
            var currentNode = _startnode;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            var currentNode = _startnode;
            int count = 0;
            do
            {
                count++;
                currentNode = currentNode.NextNode;
            } while (currentNode != null);
            return count;
        }


        public void RemoveNode(int index)
        {
            var currentNode = _startnode;
            var currentindex = 0;
            do
            {
                if (currentindex == index)
                    RemoveNode(currentNode);
                currentNode = currentNode.NextNode;
                currentindex++;
            } while (currentNode != null);
        }

        public void RemoveNode(Node node)
        {
            var nextNode = node.NextNode;
            var prevNode = node.PrevNode;
            nextNode.PrevNode = prevNode;
            prevNode.NextNode = nextNode;
        }
        public void ShowList()
        {
            var currentNode = _startnode;
            do
            {
                Console.Write($"{currentNode.Value}\t");
                currentNode = currentNode.NextNode;
            } while (currentNode != null);
            Console.WriteLine();
        }
    }
}
