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
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("Alice", 25);
            ages.Add("Bob", 30);
            if (ages.ContainsKey("Alice"))
                Console.WriteLine("Alice is " + ages["Alice"] + "years old");
            ages["Alice"] = 26;
            ages.Remove("Bob");
            foreach (var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.ReadLine();

            

            //List<string> fruits = new List<string>();
            //fruits.Add("Apple");
            //fruits.Add("Banana");
            //fruits.Add("Cherry");
            //fruits.Insert(1, "Blueberry");
            //Console.WriteLine("Containt Banana?" + fruits.Contains("Banana"));
            //fruits[0] = "Avocado";
            //fruits.Remove("Banana");
            //fruits.RemoveAt(0);

            //foreach (var fruit in fruits)
            //    Console.WriteLine(fruits);
            //Console.ReadKey(); 



            //List<Student> student  = new List<Student>();
            //student.Add(new Student(1021,"Nguyen Van A"));
            //student.Add(new Student(1022, "Nguyen Van B"));
            //student.Add(new Student(1023, "Nguyen Thi C"));
            //student.Add(new Student(4, "David"));

            //student.Insert(1, new Student(5, "Eva"));
            //student.RemoveAt(3);
            //student[2] = new Student(6,"Frank");
            //PrintCollection(student);
            //Console.WriteLine($"Count: {student.Count}");
            //Console.WriteLine($"Exists student with Id = 2? {student.Exists(s => s.Id == 2)})");
            //Console.ReadLine();



            //SortedList mySL = new SortedList();
            //mySL.Add("Third", "!");
            //mySL.Add("Second", "World");
            //mySL.Add("First", "Hello");
            //Console.WriteLine("mySL");
            //Console.WriteLine("Count: {0}", mySL.Count);
            //Console.WriteLine("Capacity: {0}", mySL.Capacity);
            //Console.WriteLine("Keys and values: ");
            //Console.WriteLine("\t-KEY-\t-VALUE-");
            //for (int i = 0; i < mySL.Count; i++)
            //{
            //    Console.WriteLine("\t{0}:\t{1}", mySL.GetKey(i), mySL.GetByIndex(i));
            //}

            //Console.ReadLine();


            //Stack mystack = new Stack();
            //mystack.Push(1);
            //mystack.Push(2);
            //mystack.Push(3);
            //mystack.Push(4);
            //var a = mystack.Pop();
            //var b = mystack.Peek();
            //bool has2 = mystack.Contains(2);
            //bool hasz = mystack.Contains("z");
            //Console.WriteLine("Size of stack:" + mystack.Count);
            ////mystack.Clear();

            //Queue myqueue01 = new Queue();
            //myqueue01.Enqueue(1);
            //myqueue01.Enqueue(2);
            //myqueue01.Enqueue(3);
            //myqueue01.Enqueue(4);
            //myqueue01.Enqueue(5);
            //myqueue01.Enqueue(5);
            //myqueue01.Enqueue(5);
            //myqueue01.Enqueue("Bob");
            //myqueue01.Enqueue("Tom");
            //myqueue01.Enqueue("Jerry");
            //var item01 = myqueue01.Dequeue();
            //Console.WriteLine("Contain 5 in queue: " + myqueue01.Contains(5));
            //Console.WriteLine("Contain 10 in queue: " + myqueue01.Contains(10));
            //Console.WriteLine("Size of queue:" + myqueue01.Count);
            //myqueue01.Clear();
            //Console.WriteLine("Size of queue:" + myqueue01.Count);

            //Console.ReadLine();



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

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Student(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public override string ToString()
            {
                return $"Student(Id={Id}, Name={Name})";
            }
        }

        static void QueueExample()
        {
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Download file");
            tasks.Enqueue("Scan file");
            Console.WriteLine("Next tasks: " + tasks.Peek());
            Console.WriteLine("Processing: " + tasks.Dequeue());

            foreach (var task in tasks)
                Console.WriteLine(task);
        }

        static void StackExample()
        {
            Stack<string> history = new Stack<string>();
            history.Push("Page 1");
            history.Push("Page 2");
            Console.WriteLine("Current page: " + history.Peek());
            Console.WriteLine("Go back: " + history.Pop());

            foreach (var page in history)
                Console.WriteLine(page);
        }

        static void SortedListExample()
        {
            SortedList<int, string> students = new SortedList<int, string>();
            students.Add(102, "Lan");
            students.Add(101, "Nam");
            students.Add(105, "Hoa");
            students[102] = "Linh";

            if (students.ContainsKey(105))
                Console.WriteLine("Student 105: " + students[105]);

            students.Remove(101);

            foreach (var s in students)
                Console.WriteLine($"{s.Key}: {s.Value}");
        }
    }
}
