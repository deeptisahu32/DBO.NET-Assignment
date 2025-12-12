using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_ASSESSMENT
{
    internal class Disconnected
    {
        // for Students
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        //for Courses

        DataTable dt1 = new DataTable();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1;

        //for Enrollment

        DataTable dt2 = new DataTable();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2;

        SqlConnection con = new SqlConnection("Integrated security=true;database=Universitydbsystem;server=(localdb)\\MSSQLLocalDB");


        public void Question1()
        {
            Console.WriteLine("Students Table Data\n");
            da=new SqlDataAdapter("select * from Students",con);
            da.Fill(ds, "StudentTable");
            dt=ds.Tables["StudentTable"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);
                Console.WriteLine(dt.Rows[i][2]);
                Console.WriteLine(dt.Rows[i][3]);
                Console.WriteLine(dt.Rows[i][4]);
            }
            Console.WriteLine("\nCourses Tables Data :\n");
            da1 = new SqlDataAdapter("select * from Courses", con);
            da1.Fill(ds1, "CourseTable");
            dt1 = ds1.Tables["CourseTable"];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Console.WriteLine(dt1.Rows[i][0]);
                Console.WriteLine(dt1.Rows[i][1]);
                Console.WriteLine(dt1.Rows[i][2]);
                Console.WriteLine(dt1.Rows[i][3]);
            }
        }
        //Question 2
        public void Question2()
        {
            da1 = new SqlDataAdapter("select * from Courses", con);

            da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            da1.Fill(ds1, "CourseTable");
            dt1 = ds1.Tables["CourseTable"];


            Console.WriteLine("Enter CourseId:");
            int courseId = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter new Credits:");
            int newCredits = int.Parse(Console.ReadLine());

            DataRow row = dt1.Rows.Find(courseId);

            if(row != null)
            {
                row["Credits"] = newCredits;

                SqlCommandBuilder cb= new SqlCommandBuilder(da1);
                da1.Update(ds1, "CourseTable");
                Console.WriteLine("Credit Updated :");

            }
            else
            {
                Console.WriteLine("Course not found, try again");
            }
        }
        //Question 3
        public void Question3()
        {
            da1 = new SqlDataAdapter("select * from Courses", con);

            da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ds1 = new DataSet();
            da1.Fill(ds1, "CourseTable");
            dt1 = ds1.Tables["CourseTable"];

            Console.WriteLine("Enter Course Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Credits:");
            int credits = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Semester:");
            string semester = Console.ReadLine();


            DataRow newRow = dt1.NewRow();
            newRow["CourseName"] = name;
            newRow["Credits"] = credits;
            newRow["Semester"] = semester;


            dt1.Rows.Add(newRow);

            SqlCommandBuilder cb = new SqlCommandBuilder(da1);

            da1.Update(ds1, "CourseTable");

            Console.WriteLine("New course inserted.");
        }
        //Question 4
        public void Question4()
        {
            da = new SqlDataAdapter("select * from Students", con);

            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;


            da.Fill(ds, "StudentTable");
            dt = ds.Tables["StudentTable"];

            Console.WriteLine("Enter StudentId to delete:");
            int studentId = int.Parse(Console.ReadLine());


            DataRow row = dt.Rows.Find(studentId);
            if (row != null)
            {
                row.Delete();

                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "StudentTable");

                Console.WriteLine("Student deleted.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        //Question 5
        public void Question5()
        {

        }
        static void Main(string[] args)
        {
            Disconnected dc=new Disconnected();
            //Question 1
            Console.WriteLine("Showing Students and Courses Table :\n");
            dc.Question1();

            //Question 2
            Console.WriteLine("\nOutput of Question 2-------------");
            dc.Question2();

            //Question3
            Console.WriteLine("\nOutput of Question 3---------");
            dc.Question3();

            //Question4

            Console.WriteLine("\nOutput of Question4--------");
            dc.Question4();
        }
    }
}
