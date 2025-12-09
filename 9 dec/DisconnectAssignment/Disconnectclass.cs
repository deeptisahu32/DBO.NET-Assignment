using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisconnectAssignment
{
    internal class Disconnectclass
    {
        /*
         * Develop a code to print all record from Employee and Department 
         */
        DataTable dt=new DataTable();
        DataSet ds =new DataSet();
        SqlDataAdapter da;

       
        public void showemployee()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");

            da = new SqlDataAdapter("select * from employee", con);
            da.Fill(ds, "emp");

            dt = ds.Tables["emp"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);
                Console.WriteLine(dt.Rows[i][2]);
                Console.WriteLine(dt.Rows[i][3]);
                Console.WriteLine(dt.Rows[i][4]);
            }
        }
        DataTable dt1 = new DataTable();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1;

        public void showDepartment()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");
            da1 = new SqlDataAdapter("select * from department", con);
            da1.Fill(ds1, "deptTable");

            dt1 = ds1.Tables["deptTable"];

            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                Console.WriteLine(dt1.Rows[i][0]);
                Console.WriteLine(dt1.Rows[i][1]);
            }
        }

        /*
         * From a Employee Table 
            • Create DataView having following conditions: 
             o Salary  > 47000 
             o Department = 10 
              o EmployeeName Starts with 'M' 
            • Apply sorting. 
         */

        public void filteremploye()
        {
            DataView dv = new DataView(dt);

            dv.RowFilter = "salary>47000 and Deptid=10 and EmpName like 'M%'";
            dv.Sort = "salary";

            foreach(DataRowView item in dv)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);
                Console.WriteLine(item[4]);

            }

        }


        //Write a code to print to show total no of tables present in dataset 

        public void showtotalno()
        {
            DataSet ds = new DataSet();

            da.Fill(ds, "emp");
            da1.Fill(ds, "DeptTable");

            Console.WriteLine("Total Tables in Dataset: " + ds.Tables.Count);
        }

        /*
         *          Develop a code to copy data of SqlDataReader object To DataTable object and 
                   print all data using DataTable Object (use Department Table) Hint : use 
                   dt.Load() 
         */

        public void copydata()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbo_db;server=(localdb)\\MSSQLLocalDB");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", con);

            SqlDataReader dr = cmd.ExecuteReader();

            dt1 = new DataTable();

            dt1.Load(dr);
            con.Close();

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Console.WriteLine(dt1.Rows[i][0]);
                Console.WriteLine(dt1.Rows[i][1]);
            }
        }

        /*
         * Develop a code to display records from customers and orders .   
           a. Create ds1 object which stores customers details  
           b. Create ds2 object which stores orders details  
           c. Merge ds1 with ds2 using merge method and display records from both the 
           table using ds1 
         */

        DataTable dt2= new DataTable();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2;

        DataTable dt3 = new DataTable();
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3;
        public void customer_Orders_details()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=Custdb;server=(localdb)\\MSSQLLocalDB");

            da2 = new SqlDataAdapter("select * from customers", con);
            ds2 = new DataSet();
            da2.Fill(ds2, "cust");
            dt2 = ds2.Tables["cust"];


            da3 = new SqlDataAdapter("select * from Orders", con);
            ds3 = new DataSet();
            da3.Fill(ds3, "orderTb");
            dt3 = ds3.Tables["orderTb"];


            ds2.Merge(ds3);

            Console.WriteLine("\nCustomers table record...........\n");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Console.WriteLine(dt2.Rows[i][0]);
                Console.WriteLine(dt2.Rows[i][1]);
                Console.WriteLine(dt2.Rows[i][2]);
                Console.WriteLine(dt2.Rows[i][3]);
                Console.WriteLine(dt2.Rows[i][4]);
            }

            Console.WriteLine("\nOrders table record...........\n");

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Console.WriteLine(dt3.Rows[i][0]);
                Console.WriteLine(dt3.Rows[i][1]);
                Console.WriteLine(dt3.Rows[i][2]);
                Console.WriteLine(dt3.Rows[i][3]);
                Console.WriteLine(dt3.Rows[i][4]);
                Console.WriteLine(dt3.Rows[i][5]);

            }
        }

        /*
         * Develop a code to Read Data of Xml File (use ds.Read() Method) and print the 
            same in console application 
        */

        public void storeinXML()
        {
            ds= new DataSet();
            da.Fill(ds);
            ds.WriteXml("C:\\Users\\deeptisa\\OneDrive - Infinite Computer Solutions (India) Limited\\Desktop\\employee1.xml");
            Console.WriteLine("XML file created successfully\n");
            Console.WriteLine(ds.GetXml());
            
        }
        
        static void Main(string[] args)
        {
            Disconnectclass disconnectclass = new Disconnectclass();
            Console.WriteLine("Below Record of Employee table\n");
            disconnectclass.showemployee();

            Console.WriteLine("\nBelow all record of Department table\n");
            disconnectclass.showDepartment();

            Console.WriteLine("\nFilter records of employee............\n");
            disconnectclass.filteremploye();

            Console.WriteLine("\nOuput of 3rd question...........\n");
            disconnectclass.showtotalno();

            Console.WriteLine("\nOutput of 4th Question...............\n");
            disconnectclass.copydata();

            Console.WriteLine("\nOutput of 5th Question................\n");
            Console.WriteLine("customer  table record\n");
            disconnectclass.customer_Orders_details();

            Console.WriteLine("\nsame it printing in console also\n");
            disconnectclass.storeinXML();

        }
    }
}
