using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;


public class Program
{

    public static string str = "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Encrypt=False";
    public static SqlConnection con = new SqlConnection(str);
    public static DataSet ds = new DataSet();
    public static DataTable tb = new DataTable();

    public static void ListStudents(){
        String query = "Select * from students";
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(query,con);
        da.Fill(tb);

        if(tb.Rows.Count <= 0){
            Console.WriteLine("Table has no content to show.");
            return;
        }

        Console.WriteLine($"Id\tName\tAge");
        Console.WriteLine(".........................");
        foreach(DataRow r in tb.Rows){
            Console.WriteLine($"{r[0]}\t{r[1]}\t{r[2]}");
        }
        con.Close();
        tb.Clear();
    }

    public static void AddStudent(){
        int id = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string query = "select * from students";
        
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(query,con);
        da.Fill(tb);

        SqlCommandBuilder cb = new SqlCommandBuilder(da);

        DataRow r = tb.NewRow();
        r[0] = id;
        r[1] = name;
        r[2] = age;

        tb.Rows.Add(r);
        da.Update(tb);
        Console.WriteLine("Data inserted successfully.");
        con.Close();
        tb.Clear();

    }

    public static void UpdateStudentById(){
        int nid = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string query = "select * from students where StdId = @nid";


        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(query,con);
        da.SelectCommand.Parameters.AddWithValue("@nid",nid);
        da.Fill(tb);

        

        foreach(DataRow r in tb.Rows){
            r[1] = name;
            r[2] = age;
        }
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Update(tb);
        con.Close();
        Console.WriteLine("Data Updated Successfully");
        tb.Clear();
        ListStudents();
    }

    public static void DeleteStudentById(){
        int idd = int.Parse(Console.ReadLine());
        string query = "select * from students where StdId = @idd";

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(query,con);
        da.SelectCommand.Parameters.AddWithValue("@idd",idd);

        da.Fill(tb);

        DataRow r = tb.Rows[0];
        r.Delete();

        SqlCommandBuilder cb = new SqlCommandBuilder(da);

        da.Update(tb);
        
        con.Close();
        tb.Clear();
        Console.WriteLine("Data Deleted Successfully");

        ListStudents();

    }
    public static void Main(string[] args)
    {
        // ListStudents();
        // AddStudent();
        // UpdateStudentById();
        DeleteStudentById();
    }
}
