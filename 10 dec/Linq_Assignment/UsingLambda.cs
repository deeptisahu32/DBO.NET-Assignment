using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Assignment
{
   
    internal class UsingLambda
    {
        List<Products> li = new List<Products>()
        {
               new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                  new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
        };
        public void question1()
        {
            //1. find second highest price 

            var res = li.OrderByDescending(p => p.price).Skip(1).Take(1);
            foreach(var pr in res)
            {
                Console.WriteLine($"{pr.pid},{pr.price},{pr.pname}");
            }
        }
        public void question2()
        {
            //2. display top 3 highest price 

            var res = li.OrderByDescending(p => p.price).Take(3);
            foreach(var pr in res)
            {
                Console.WriteLine($"{pr.pid},{pr.price},{pr.pname}");

            }
        }
        public void question3()
        {
            //3. find the sum of price where product names contains letter 'O'  

            var res = li.Where(n=>n.pname.Contains("o")).Sum(p => p.price);
            Console.WriteLine($"Sum of price : {res}");
        }
        public void question4()
        {
            //4.  find the product name ends with e and display only pid and pname (filter by  column name)
            var res = li.Where(p => p.pname.EndsWith("e"));
            foreach (var pr in res)
            {
                Console.WriteLine($"{pr.pid},{pr.pname}");
            }
        }
        public void question5()
        {
            //5. group all records by qty find max of price 

            var res = li
                .GroupBy(p => p.qty)
                .Select(g => new
                {
                    qty=g.Key,price=g.Max(x=> x.price)
                });
            foreach(var pr in res)
            {
                Console.WriteLine($"{pr.qty} , {pr.price}");
            }
        }
        static void Main(string[] args)
        {
            UsingLambda usingLambda = new UsingLambda();

            //Question1
            Console.WriteLine("output of question 1");
            usingLambda.question1();

            //Question2
            Console.WriteLine("\noutput of question 2");
            usingLambda.question2();

            //Question3
            Console.WriteLine("\noutput of question 3");
            usingLambda.question3();

            //Question4
            Console.WriteLine("\noutput of question 4");
            usingLambda.question4();

            //Question5
            Console.WriteLine("\noutput of question 5");
            usingLambda.question5();
            Console.ReadLine();

            
        }
    }
}
