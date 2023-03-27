using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class CollectionsClass
    {
        public static void collections()
        {
            //list
            var myList = new List<int>();
            myList.Add(8);
            myList.Add(2);
            myList.Add(3);
            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------------");
            myList.Sort();
            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }
            //hashset
            var myHashSet = new HashSet<int>() { 1, 4, 3, 2, 1, 2, 4 };
            foreach (int i in myHashSet)
            {
                Console.WriteLine(i);
            }
            //sortedSet
            var mySortedSet = new SortedSet<int>() { 1, 4, 3, 2, 1, 2, 4 };
            foreach (int i in mySortedSet)
            {
                Console.WriteLine(i);
            }
            //stack
            var myStack = new Stack<string>();
            myStack.Push("madhu");
            myStack.Push("shan");
            myStack.Push("kavi");
            myStack.Push("kiru");
            myStack.Push("sai");
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            myStack.Pop();
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            Console.WriteLine(myStack.Peek());

            //Queue
            var myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            myQueue.Dequeue();
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }

            //linked list
            var myLinkedList = new LinkedList<int>();
            var myLinkedList1 = new LinkedList<int>();
            myLinkedList.AddLast(1);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);
            myLinkedList.AddLast(4);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(5);
            myLinkedList.AddLast(6);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);
            myLinkedList.AddLast(4);


            //LinkedListNode<int> node1 = myLinkedList.Find(2);
            //myLinkedList.AddBefore(node, 10);
            //myLinkedList.AddBefore(node1, 10);


            foreach (var i in myLinkedList)
            {
                if (i == 2)
                {
                    myLinkedList1.AddLast(10);

                }
                myLinkedList1.AddLast(i);
            }

            foreach (int i in myLinkedList1)
            {
                Console.WriteLine(i);
            }
            

            //Dictionary
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(1, "vignesh");
            d.Add(2, "adam");
            d.Add(3, "madhu");
            d.Add(4, "prabu");
            d.Add(5, "rahul");
            d.Add(6, "rahul");
            d.Add(7, "");

            foreach (KeyValuePair<int, string> kvp in d)

            {
                if (kvp.Value.Equals("adam"))
                {
                    d[kvp.Key] = "ADAM";

                }
            }
            foreach (KeyValuePair<int, string> kvp in d)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }

        }
    }
}
