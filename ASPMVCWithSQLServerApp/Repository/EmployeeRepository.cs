using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ASPMVCWithSQLServerApp.Models;

namespace ASPMVCWithSQLServerApp.Repository
{
    public class EmployeeRepository
    {
        private SqlConnection con;

        //To hanlde connection related activities
        private void Connection()
        {
            string constrg = ConfigurationManager.ConnectionStrings["MyDbConnection"].ToString();
            con = new SqlConnection(constrg);
        }

        //To add employee details
        public bool addNewEmployee(EmployeeModel employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("INERTEMPLOYEE", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NAME", employee.Name);
            command.Parameters.AddWithValue("@CITY", employee.City);
            command.Parameters.AddWithValue("@ADDRESS", employee.Address);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            else return false;
        }

        //To update employee details
        public bool updateEmployee(EmployeeModel employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("UPDATEEMPLOYEE", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", employee.EmpID);
            command.Parameters.AddWithValue("@NAME", employee.Name);
            command.Parameters.AddWithValue("@CITY", employee.City);
            command.Parameters.AddWithValue("@ADDRESS", employee.Address);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            else return false;
        }

        //To Get all employees details
        public List<EmployeeModel> getEmployees()
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            Connection();
            SqlCommand command = new SqlCommand("GETALLEMPLOYEES", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                employeeModels.Add(
                    new EmployeeModel
                    {
                        EmpID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"]),
                    }
                    );
            }
            return employeeModels;
        }

        //To Get single employees details
        public List<EmployeeModel> getSingleEmployees(int id)
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            Connection();
            SqlCommand command = new SqlCommand("GETSINGLEEMPLOYEE", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                employeeModels.Add(
                    new EmployeeModel
                    {
                        EmpID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"]),
                    }
                    );
            }
            return employeeModels;
        }

        //To Delete employee details
        public bool deleteEmployee(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DELETEEMPLOYEE", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            else return false;
        }
    }
}