using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected_Assignment
{
    internal class Connected_Arch_Assignment
    {


        public void GetTransaction()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();  //create new connection

            Console.WriteLine("Enter start date :");
            DateTime doj1 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Last date :");
            DateTime doj2 = Convert.ToDateTime(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("pr_getemployee", con);
            SqlParameter p1 = new SqlParameter("@d1", doj1);
            SqlParameter p2 = new SqlParameter("@d2", doj2);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}");
            }
            con.Close();
        }

        public void GetCommonRecord()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();  //create new connection

            Console.WriteLine("Enter department id :");
            int dId = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("pr_Getrecord", con);
            SqlParameter p1 = new SqlParameter("@id", dId);
            cmd.Parameters.Add(p1);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]} {dr[4]} {dr[5]}");
            }


            con.Close();
        }
        public void InsertRecordsusingtrans()
        {
            // logic to insert records to employee and department using transaction 

            SqlTransaction tr = null;
            try
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
                con.Open();
                tr = con.BeginTransaction();

                Console.WriteLine("Enter Dept id :");
                int Did = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Deptname :");
                string dname = Console.ReadLine();
                SqlCommand cmd1 = new SqlCommand($"INSERT INTO Department (DeptID, DeptName) VALUES ({Did}, '{dname}')", con, tr);                //cmd1.Parameters.AddWithValue("@deptid", Did);
                int rowaffected = cmd1.ExecuteNonQuery();
                cmd1.Transaction = tr;


                Console.WriteLine("Enter Employee Name :");
                string empname = Console.ReadLine();
                Console.WriteLine("Enter Salary ");
                int sal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the dateofjoin");
                string doj = Console.ReadLine();
                SqlCommand cmd2 = new SqlCommand($"INSERT INTO Employee (EmpName, Salary, DateOfJoin, DeptID) VALUES ('{empname}', {sal}, '{doj}', {Did})", con, tr);             //cmd2.Parameters.AddWithValue("@name", empname);

                cmd2.Transaction = tr;

                int rowaffected2 = cmd2.ExecuteNonQuery();

                Console.WriteLine("Total record inserted " + rowaffected);
                Console.WriteLine("Total record inserted " + rowaffected2);

                tr.Commit();
                con.Close();

            }
            catch (Exception ex)
            {
                tr.Rollback();
                Console.WriteLine("Values not right , insert again .............");
            }
        }

        public void fetchid()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();

            Console.WriteLine("Enter Employee Name :");
            string empname = Console.ReadLine();
            Console.WriteLine("Enter Salary ");
            int sal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the dateofjoin");
            string doj = Console.ReadLine();
            Console.WriteLine("Enter dpetid:");
            int deptId = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("pr_insertemployee", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Empname", empname);
            cmd.Parameters.AddWithValue("@Sal", sal);
            cmd.Parameters.AddWithValue("@doj", doj);
            cmd.Parameters.AddWithValue("@did", deptId);


            int newempid = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine($"new employee id : {newempid}");



            SqlCommand cmd1 = new SqlCommand($"select * from employee where EmpID={newempid}", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}");
            }

            con.Close();
        }

        public void multireader()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();
            string joinresult = "select * from employee as e join department as d on e.deptid=d.deptid; select d.deptid,d.deptname from department as d;";


            SqlCommand cmd = new SqlCommand(joinresult, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} , {dr[1]} , {dr[2]} , {dr[3]}  , {dr[4]}");
            }

            if (dr.NextResult())
            {
                Console.WriteLine("\nDepartments:");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}  {dr[1]}");
                }
            }

            con.Close();
        }

        public void Checkconnect()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();

            Console.WriteLine("Enter Employee id :");
            int empid = Convert.ToInt32(Console.ReadLine());

            if (con.State != ConnectionState.Open)
            {
                Console.WriteLine("Connection is not open");
            }

            SqlCommand cmd = new SqlCommand("pr_insertemployee", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Empid", empid);



            cmd.Parameters.Add("@DateofJoin", SqlDbType.Date).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;


            int res = cmd.ExecuteNonQuery();

            con.Close();
        }
        static void Main(string[] args)
        {

            // Tast 1

            Connected_Arch_Assignment Ca = new Connected_Arch_Assignment();
            //Ca.GetTransaction();

            //Test 2

            //Ca.GetCommonRecord();

            //Test 3

            //Ca.InsertRecordsusingtrans();

            //Test 4

            //Ca.fetchid();

            //Test 5

            Ca.multireader();
            Console.ReadLine();


        }
    }
}
