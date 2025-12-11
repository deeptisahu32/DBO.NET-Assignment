using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq_Assignment
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Actor { get; set; }
        public string Actress { get; set; }
        public int YOR { get; set; }
    }
    internal class Movies_List
    {
        List<Movies> li = new List<Movies>()
        {
         new Movies(){ MovieId=100, MovieName="Bahubali", Actor="Prabhas",Actress="Tamanna", YOR=2015 },
         new Movies(){ MovieId=200, MovieName="Bahubali2", Actor="Prabhas",Actress="Anushka", YOR=2017 },
         new Movies(){ MovieId=300, MovieName="Robot", Actor="Rajini",Actress="Aish", YOR=2010 },
         new Movies(){ MovieId=400, MovieName="3 idiots", Actor="Amir",Actress="kareena", YOR=2009 },
         new Movies(){ MovieId=500, MovieName="Saaho", Actor="Prabhas",Actress="shraddha", YOR=2019 },
        };

        public void question1()
        {
            //1. display list of movienames acted by prabhas 

            var moviename = from name in li where name.Actor == "Prabhas" select name;

            foreach(var names in moviename)
            {
                Console.WriteLine($"{names.MovieName},{names.Actor}");
            }
        }
        public void question2()
        {
            //2. display list of all movies released in year 2019 

            var movie=from name in li where name.YOR==2019 select name;
            foreach (var names in movie)
            {
                Console.WriteLine($"{names.MovieName}, {names.YOR}");
            }
        }
        public void question3()
        {
            //3. display the list of movies who acted together by prabhas and anushka 
            var moviename = from name in li where name.Actor == "Prabhas" && name.Actress== "Anushka" select name;

            foreach (var names in moviename)
            {
                Console.WriteLine($"{names.MovieName},{ names.Actor},{names.Actress}");
            }

        }
        public void question4()
        {
            //4. display the list of all actress who acted with prabhas 

            var names = from n in li where n.Actor == "Prabhas" select n;
            foreach(var i in names)
            {
                Console.WriteLine($"{i.Actress},{i.Actor}" );
            }
        }
        public void question5()
        {
            //5. display the list of all moves released from 2010 - 2018 

            var movies = from m in li where m.YOR > 2010 && m.YOR < 2018 select m;
            foreach(var i in movies)
            {
                Console.WriteLine($"{i.MovieName},{i.YOR}");
            }
        }
        public void question6()
        {
            //6. sort YOR in descending order and display all its records 

            var record = from r in li orderby r.YOR descending select r;
            foreach (var i in record)
            {
                Console.WriteLine($"{i.MovieId},{i.MovieName},{i.Actor},{i.Actress},{i.YOR}");
            }
        }
        public void question7()
        {
            //7. display max movies acted by each actor 
            var result = from m in li 
                         group m by m.Actor into a
                         orderby a.Count() descending
                         select new {Actor=a.Key,ActorCount=a.Count()};
            foreach (var i in result)
            {
                Console.WriteLine($"{i.Actor},{i.ActorCount}");

            }
        }
        public void question8()
        {
            //8.display the name of all movies which is 5 characters long
            var result = (from n in li where n.MovieName.Length == 5 select n);
            foreach(var i in result)
            {
                Console.WriteLine($"{i.MovieName}");
            }
                       
        }
        public void question9()
        {
            //9.display names of actor and actress where movie released in year 2017, 2009 and 2019

            var result = (from m in li where m.YOR == 2017 || m.YOR == 2009 || m.YOR == 2019 select m);
            foreach(var n in result)
            {
                Console.WriteLine($"{n.Actor},{n.Actress},{n.YOR}");
            }
        }
        public void question10()
        {
            //10.display the name of movies which start with 'b' and ends with 'i' 

            var result = from m in li where m.MovieName.StartsWith("B") && m.MovieName.EndsWith("i") select m;
            foreach(var n in result)
            {
                Console.WriteLine(n.MovieName);
            }

        }
        public void question11()
        {
           // 11.display name of actress who not acted with Rajini and print in descending order
           var result=from n in li where n.Actor!="Rajini" orderby n.Actress descending select n;
            foreach(var name in result)
            {
                Console.WriteLine($"{name.Actress},{name.Actor}");
            }
        }
        public void question12()
        {
            //12. display records in following format 
            /*
            eg:
                movie name     cast
                Bahubali     prabhas - tammanna
            */

            Console.WriteLine("movie name".PadRight(15) + "cast");

            var result = from n in li select new
            {
                moviename = n.MovieName,
                cast=$"{n.Actor} - {n.Actress}"
            };
            foreach(var r in result)
            {
                Console.WriteLine($"{r.moviename.PadRight(15)+r.cast}");
            }
        }
        static void Main(string[] args)
        {
            Movies_List movies_List = new Movies_List();
            //Question1
            Console.WriteLine("Movies name acted by Prabhas");
            movies_List.question1();

            //Question2
            Console.WriteLine("\nMovies realeased in 2019");
            movies_List.question2();

            //Question3
            Console.WriteLine("\nMovies name acted by Prabhas and Anuska");
            movies_List.question3();

            //Question4
            Console.WriteLine("\nActress name who acted with Prabhas");
            movies_List.question4();

            //Question5
            Console.WriteLine("\nMOvies list release between 2010 to 2018");
            movies_List.question5();

            //Question6
            Console.WriteLine("\nList of movies with YOR descending");
            movies_List.question6();

            //Question7
            Console.WriteLine("\nmax movies acted by each actor");
            movies_List.question7();

            //Question8
            Console.WriteLine("\nprint all movie name with length 5");
            movies_List.question8();

            //Question9
            Console.WriteLine("\nprint actor actress name based on years");
            movies_List.question9();

            Console.WriteLine("\nprint movie name startwith b and end with i");
            movies_List.question10();

            //Question11
            Console.WriteLine("\nprint actressname who is not acted with Rjani\n");
            movies_List.question11();

            //Question12
            Console.WriteLine("\nprint record in structure way");
            movies_List.question12();
            Console.ReadLine();

        }
    }
}
