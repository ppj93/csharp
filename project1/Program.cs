using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace project1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var tests = new[] { new test() { name = "pravin" }, new test() { name = "sometjigelse" } };

            Array.Sort(tests, new testComparer());

            Console.Write(tests.Select(x => x.name).Aggregate((arg1, arg2) => arg1 + "--" + arg2));

            ObservableCollection<test> o = new ObservableCollection<test>();
            o.CollectionChanged += notifyCollectionChange;

            o.Add(new test());
            o.RemoveAt(0);
        }

        static T GetDefaultValue<T>(T arg) where T:class, new()//, test
        {
            return default(T);
        }

        static void notifyCollectionChange(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args) 
        {
            Console.WriteLine("start");
            Console.WriteLine(sender);
            Console.WriteLine(args.Action);
            Console.WriteLine(args.NewItems);
            Console.WriteLine(args.OldItems);
            Console.WriteLine("end");
        }

        class test {
            public string name { get; set; }
        }

        class testComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                var xtyped = x as test;
                var ytyped = y as test;

                if (x == y)
                    return 0;

                if (x == null)
                    return -1;

                if (y == null)
                    return 1;

                return String.Compare(xtyped.name, ytyped.name);
            }
        }

    }
}
		