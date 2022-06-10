using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_33_Employee_Payroll_System
{
    public class EmployeeRepo
    {
        //path for Database Connection
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_33;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        //method to establish connection
        public SqlConnection getConnection()
        {
            //Represents a connection to MS Sql Server Database
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("\n=> Connection Established successfully...");
            return connection;
        }

        EmployeeModel employeeModel = new EmployeeModel();
        public void GetSqlData()
        {   
            var sqlConnection=getConnection();
            //Opens Connection
            sqlConnection.Open();
            string query = @"select * from employee_payroll";
            //Pass query to TSql
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Check if sqlDataReader has Rows
            if (sqlDataReader.HasRows)
            {
                Console.WriteLine("\n>> Records Retrieved From DataBase : ");
                //Read each row
                while (sqlDataReader.Read())
                {
                    //Read data from Employee_payroll_33 DataBase using SqlDataReader and Display them 
                    employeeModel.EmployeeID = sqlDataReader.GetInt32(0);
                    employeeModel.EmployeeName = Convert.ToString(sqlDataReader["Name"]);                    
                    employeeModel.EmployeePhoneNumber = Convert.ToInt64(sqlDataReader["Phone"]);
                    employeeModel.Address = sqlDataReader["Address"].ToString();
                    employeeModel.EmployeeDepartment = sqlDataReader["Department"].ToString();
                    employeeModel.Gender = Convert.ToChar(sqlDataReader["Gender"]);
                    employeeModel.BasicPay = Convert.ToDouble(sqlDataReader["Basic_pay"] == DBNull.Value ? default : sqlDataReader["Basic_pay"]); //we can write like this also            
                    employeeModel.Deduction = Convert.ToDouble(sqlDataReader["Deduction"] == DBNull.Value ? default : sqlDataReader["Deduction"]);
                    employeeModel.TaxablePay = Convert.ToDouble(sqlDataReader["Taxable_Pay"] == DBNull.Value ? default : sqlDataReader["Taxable_Pay"]);
                    employeeModel.IncomeTax = Convert.ToDouble(sqlDataReader["Tax"] == DBNull.Value ? default : sqlDataReader["Tax"]);
                    employeeModel.NetPay = Convert.ToDouble(sqlDataReader["NetPay"] == DBNull.Value ? default : sqlDataReader["NetPay"]);
                    employeeModel.StartDate = Convert.ToDateTime(sqlDataReader["StartDate"]);

                    //Display Data
                    Console.WriteLine("\nEmployee ID: {0} \nEmployee Name: {1} \nBasic Pay: {2} \n Deduction: {3} \nIncome Tax: {4} \nTaxable Pay: {5} \nNetPay: {6} \nGender: {7} \nPhoneNumber: {8} \nDepartment: {9} \nAddress: {10}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.BasicPay, employeeModel.Deduction, employeeModel.IncomeTax,
                        employeeModel.TaxablePay, employeeModel.NetPay, employeeModel.Gender, employeeModel.EmployeePhoneNumber, employeeModel.EmployeeDepartment, employeeModel.Address);
                }
                //Close sqlDataReader Connection
                sqlDataReader.Close();
            }
            //Close Connection
            sqlConnection.Close();
        }
    }
}
