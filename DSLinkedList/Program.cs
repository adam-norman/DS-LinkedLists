using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertLast("200");
            linkedList.InsertLast("201");
            linkedList.InsertLast("202");
            linkedList.InsertLast("203");
            linkedList.InsertLast("204");
            linkedList.InsertLast("205");
            linkedList.PrintLinkedListData();
            Print("remove at index 3:" + Environment.NewLine);
            linkedList.RemoveAtIndex(3);
            linkedList.PrintLinkedListData();
            //int index = 3;
            //Print("Val at index "+index.ToString()+" :"+linkedList.GetDataValueAtIndex(index));
            Print("list is going to be cleared");
            linkedList.ClearAll();
                linkedList.PrintLinkedListData();
            Console.ReadLine();
        }
          static  void Print(string val)
        {
            Console.Write(val + Environment.NewLine);
        }
    }

    public class Node
    {
        public string data;
        public Node next;
        public Node(string data, Node next = null)
        {
            this.data = data;
            this.next = next;
        }
    }
    public class LinkedList
    {
        Node head;
        int size;
        public LinkedList()
        {
            this.head = null;
            this.size = 0;
        }
        public void InsertFirst(string data)
        {
            this.head = new Node(data, this.head);
            this.size++;
        }
        public void PrintLinkedListData()
        {
            Node current = this.head;
            while (current != null)
            {
                Console.Write(current.data + Environment.NewLine);
                current = current.next;
            }
        }
        public void InsertLast(string data)
        {
            if (this.size == 0) { this.InsertFirst(data); return; }
            Node current = this.head;
            while (true)
            {
                if (current.next == null)
                {
                    Node newNode = new Node(data);
                    current.next = newNode;
                    this.size++;
                    break;
                }
                else
                {
                    current = current.next;
                }
            }
        }
        public void InsertAt(string data, int index)
        {
            if (index == 0) { this.InsertFirst(data); return; }
            if (this.size <= index) { this.InsertLast(data); return; }
            Node newNode = new Node(data);
            Node current = this.head;
            int counter = 1;
            while (counter < index)
            {
                current = current.next;
                counter++;
            }
            newNode.next = current.next;
            current.next = newNode;
            this.size++;
        }
        public string GetDataValueAtIndex(int index)
        {
            string data = "";
            if (index < this.size)
            {
                Node current = this.head;
                int counter = 0;
                while (counter <= index)
                {
                    data = current.data;
                    current = current.next;
                    counter++;
                }
            }
            return data;
        }
        public void RemoveAtIndex(int index)
        {
            if (this.size == 0) { return;  }
            if (this.size == 1) { this.head = null; }
            if (this.size <index) { return; }
            Node current = this.head;
            int counter = 0;
            Node previous=this.head;
            while (counter < index)
            {
                counter++;
                previous = current;
                current = current.next;
            }
            previous.next = current.next;
            this.size--;
        }
        public void ClearAll()
        {
            this.head = null;
            this.size = 0;

        }
    }

}
