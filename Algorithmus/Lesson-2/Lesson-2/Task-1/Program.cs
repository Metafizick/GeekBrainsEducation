using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }        
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class Program
    {
        static void Main(string[] args)
        {
            var startnode = new Node { Value = 1, PrevNode = null };
            var lastnode = new Node { Value = 2, NextNode = null, PrevNode = startnode };
            startnode.NextNode = lastnode;
            LinkedList linkedList = new LinkedList(startnode, lastnode);
            linkedList.AddNode(3);
            linkedList.AddNode(4);
            linkedList.AddNode(5);
            linkedList.AddNode(6);
            linkedList.AddNode(7);
            linkedList.AddNode(9);
            linkedList.AddNodeAfter(startnode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode, 8);
            var searchNode = linkedList.FindNode(6);
            Console.WriteLine($"Searching value = {searchNode.Value}");
            Console.WriteLine("List before Remove");
            Console.WriteLine($"List count = {linkedList.GetCount()}");
            linkedList.ShowList();
            linkedList.RemoveNode(searchNode);
            linkedList.RemoveNode(5);
            Console.WriteLine("List after Remove");
            Console.WriteLine($"List count = {linkedList.GetCount()}");
            linkedList.ShowList();           
            Console.ReadKey();
        }
    }
}
