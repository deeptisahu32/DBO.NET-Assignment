using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_ASSESSMENT
{
    internal class Connected
    {
        SqlConnection con = new SqlConnection("Integrated security=true;database=Universitydbsystem;server=(localdb)\\MSSQLLocalDB");

        //Question 1
        public void Question1()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Courses",con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}");
            }

            con.Close();
        }

        //Question 2

        public void Question2()
        {
            con.Open();

            Console.Write("FullName: ");
            var fullName = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Department: ");
            var department = Console.ReadLine();
            Console.Write("YearOfStudy: "); 
            var year = int.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("InsertStudent ", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter p1 = new SqlParameter("@FullName", fullName);
            SqlParameter p2 = new SqlParameter("@Email", email);
            SqlParameter p3 = new SqlParameter("@Department", department);
            SqlParameter p4 = new SqlParameter("@YearOfStudy", year);


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);


            object result = cmd.ExecuteScalar();
            int newId = Convert.ToInt32(result);
            Console.WriteLine("Inserted StudentId: " + newId);

            con.Close();
        }

        //Question 3
       

        public void Question3()
        {
            con.Open();

            Console.WriteLine("Enter Department:");
            string department = Console.ReadLine();

            string query = "select * from Students where Department = @Department";


            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("@Department", department);
            cmd.Parameters.Add(p1);


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}  {dr[4]}");
            }


            con.Close();

        }

        //Question 4
        public void Question4()
        {
            con.Open();

            Console.WriteLine("Enter Studentid :");
            int id=int.Parse(Console.ReadLine());


            string query = @"SELECT c.CourseName, c.Credits, e.EnrollDate, e.Grade
                         FROM Enrollments e
                         INNER JOIN Courses c ON e.CourseId = c.CourseId
                         WHERE e.StudentId = @StudentId";


            SqlCommand cmd = new SqlCommand(query, con);

            SqlParameter p1 = new SqlParameter("@StudentId", id);
            cmd.Parameters.Add(p1);


            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("Course Name | Credits | Enroll Date | Grade");

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} | {dr[1]} | {dr[2]} | {dr[3]}");
            }

            con.Close();
        }
        //Question 5
        public void Question5()
        {
            con.Open();

            Console.WriteLine("Enter EnrollmentId:");
            int enrollmentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Grade (A/B/C/D/F):");
            string grade = Console.ReadLine();

            string query = "update Enrollments set Grade=@Grade where EnrollmentId=@EnrollmentId";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("@Grade", grade);
            SqlParameter p2 = new SqlParameter("@EnrollmentId", enrollmentId);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"Rows Affected : {rows}");

            con.Close();
        }
        static void Main(string[] args)
        {
            Connected cn = new Connected();
            //Question 1
            Console.WriteLine("Displaying Cources table : ");
            cn.Question1();

            ////Question2
            Console.WriteLine("\nAdding new Students : ");
            cn.Question2();

            //Question3
            Console.WriteLine("\nDisplaying student search by department");
            cn.Question3();

            //Question 4
            Console.WriteLine("\nDisplaying enrolled course for student");
            cn.Question4();

            //Question5
            Console.WriteLine("Output of Question no 5 :");
            cn.Question5();

            Console.ReadLine();
        }


    }
}
