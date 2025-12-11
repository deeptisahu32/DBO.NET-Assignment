using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Assignment
{
    class Products
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
        public int qty { get; set; } 
   } 
 
    internal class ArrayClass
    {
        List<int> listA = new List<int> { 10, 20, 30, 40, 50, 20, 30 };
        List<int> listB = new List<int> { 30, 40, 50, 60, 70, 40 };

        List<string> names1 = new List<string> { "Akshay", "Aasritha", "Deepa", "Kiran","Kiran" };
        List<string> names2 = new List<string> { "Kiran", "Manikanta", "Deepa", "Naveen"};

        List<Products> li = new List<Products>()
            {
               new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                  new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
             };
        public void fetchunique()
        {
            //Q1. Write a LINQ query to fetch unique values from listA. 
            //Expected Output: 10, 20, 30, 40, 50 

            var uniquevalues = (from i in listA
                                select i).Distinct();

            foreach(var num in uniquevalues)
            {
                Console.WriteLine(num);
            }                     
        }

        public void Combination()
        {
            //Q2. Combine values from listA and listB without duplicates.

            var combination = (from i in listA select i).Concat(from j in listB select j).Distinct();

            foreach(var num in combination)
            {
                Console.WriteLine(num);
            }

        }

        public void common()
        {
            //Q3. Find items common in listA and listB. 

            var common = from i in listA
                         join j in listB
                         on i equals j
                         select i;
            foreach(var num in common)
            {
                Console.WriteLine(num);
            }
        }
        public void notavailbale()
        {
            //Q4. Find names present in names1 but not in names2. 

            var names = from i in names1
                       where !names2.Contains(i)
                       select i;
            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }
        public void sumprice()
        {
            //Q5. Find sum of price of all products. 

            var total = (from i in li select i.price).Sum();

            Console.WriteLine($"Total price : {total}");
        }
        public void countproduct()
        {
            //Q6. Find count of products where price > 5000. 

            var countproduct = (from i in li where i.price > 5000 select i).Count();
            Console.WriteLine($"Count products : {countproduct}");
        }
        public void highestvalues()
        {
            //Q7. Find the highest value in listA. 

            var value = (from i in listA select i).Max();
            Console.WriteLine($"Highest value : {value}");
        }
        public void divisible()
        {
            //Q8. Write a LINQ query to find numbers divisible by 3 

            int[] numbers = { 1, 4, 9, 16, 25, 36 };

            var value = from i in numbers where i % 3 == 0 select i;
            foreach (var num in value)
            {
                Console.WriteLine(num);
            }

        }
        public void sorting()
        {
            // Q9. Write a Linq to query to sort based on string Length 
            string[] st = { "India", "Srilanka", "canada", "Singapore" };

            var str = from s in st orderby s.Length select s;
            foreach( var s in str)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(string[] args)
        {
            ArrayClass arrayClass = new ArrayClass();

            // question 1
            Console.WriteLine("Below all Uniques values\n");
            arrayClass.fetchunique();

            // question 2

            Console.WriteLine("\nbelow combination of two list with distinct values\n");
            arrayClass.Combination();

            //question 3
            Console.WriteLine("\nbellow common values in both list\n");
            arrayClass.common();

            //question 4
            Console.WriteLine("\nbelow name which availbale only in names 1 not in name2\n");
            arrayClass.notavailbale();

            //question 5
            Console.WriteLine("\nbelow sum of price");
            arrayClass.sumprice();

            //question 6
            Console.WriteLine("\nbelow count of products");
            arrayClass.countproduct();

            //question 7
            Console.WriteLine("\nHighest values is bwelow");
            arrayClass.highestvalues();

            //question 8
            Console.WriteLine("\ndivisible by 3 values");
            arrayClass.divisible();

            //question 9
            Console.WriteLine("\nsort by strings length");
            arrayClass.sorting();
        }
    }
}
