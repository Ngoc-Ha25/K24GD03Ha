using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack mystack = new Stack();
            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);
            var a = mystack.Pop();
            var b = mystack.Peek();
            bool has2 = mystack.Contains(2);
            bool hasz = mystack.Contains("z");
            Console.WriteLine("Size of stack:" + mystack.Count);
            //mystack.Clear();

            Queue myqueue01 = new Queue();
            myqueue01.Enqueue(1);
            myqueue01.Enqueue(2);
            myqueue01.Enqueue(3);
            myqueue01.Enqueue(4);
            myqueue01.Enqueue(5);
            myqueue01.Enqueue(5);
            myqueue01.Enqueue(5);
            myqueue01.Enqueue("Bob");
            myqueue01.Enqueue("Tom");
            myqueue01.Enqueue("Jerry");
            var item01 = myqueue01.Dequeue();
            Console.WriteLine("Contain 5 in queue: " + myqueue01.Contains(5));
            Console.WriteLine("Contain 10 in queue: " + myqueue01.Contains(10));
            Console.WriteLine("Size of queue:" + myqueue01.Count);
            myqueue01.Clear();
            Console.WriteLine("Size of queue:" + myqueue01.Count);

            Console.ReadLine();

























            //Hashtable ht01 = new Hashtable();
            //ht01.Add("a", 1);
            //ht01.Add("b", 1);
            //ht01.Add("c", 1);
            //ht01.Add("d", 1);
            //ht01.Add("e", 1);
            //ht01.Add(1, "c");
            //ht01.Remove(1);
            //if(ht01.ContainsKey("c"))
            //    ht01.Remove("c");
            //if (ht01.ContainsKey("f"))
            //    ht01.Remove("f");
            //bool hasValue = ht01.ContainsValue(3);
            //hasValue = ht01.ContainsValue(6);

            //foreach (DictionaryEntry item in ht01)
            //{
            //    Console.WriteLine(item.Key + ": " + item.Value);
            //    Console.WriteLine();
            //};
            //Console.WriteLine("==================KEYS===============");
            //foreach(var key in ht01.Keys)
            //{
            //    Console.WriteLine(key);
            //};
            //Console.WriteLine("=====================VALUES==============");
            //foreach(var value in ht01.Values)
            //{
            //    Console.WriteLine(value);
            //};

            //Hashtable ht02 = (Hashtable)ht01.Clone();
            //Console.ReadLine();
















            //for (int i = 0; i < list01.Count; i++)
            //{
            //    Console.WriteLine($"Item {i}: {list01[i]}");
            //}
            //list01.RemoveAt(3);
            //list01.Insert(4,10);
            //Console.WriteLine($"List01 Count: {list01.Count}");
            //ArrayList list02 = new ArrayList();
            //list02.Add("A1");
            //list02.Add("B1");
            //list02.Add("C1");
            //list02.Add("D1");
            //list02[2] = "C2";
            //list02.Add(100);
            //list02.Add(3.14f);
            //list01.InsertRange(4, list02);
            //list02.Remove("C1");
            //list02.Remove("C2");
            //list02.Clear();
            //list01.RemoveRange(6, 2);
            //Console.WriteLine($"List01 Count: {list01.Count}");
            //Console.ReadLine();
        }
    }
}
