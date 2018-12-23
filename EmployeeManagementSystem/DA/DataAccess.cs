using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.DA
{
    public class DataAccess
    {
        public static SqlConnection GetConnection()
        {
            //string connectionString = @"Data Source=WIN2012BASE;Initial Catalog = SimpleEmployeeDB;
            //        Integrated Security = True";
            string connectionString = "enter a connection string";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            return connection;
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection sqlConn = GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            string sp = "SP_GetAllEmployees";
            sqlCmd.CommandText = sp;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Connection = sqlConn;

            SqlDataReader sqlDREmployee = sqlCmd.ExecuteReader();


            using (sqlConn)
            {
                using (sqlDREmployee)
                {
                    while (sqlDREmployee.Read())
                    {

                        Employee employee = new Employee();
                        if (!sqlDREmployee.IsDBNull(0))
                        {
                            employee.EmpId = Int32.Parse(sqlDREmployee["EmpId"].ToString());
                        }

                        if (!sqlDREmployee.IsDBNull(1))
                        {
                            employee.EmpName = Convert.ToString(sqlDREmployee["EmpName"]);
                        }

                        if (!sqlDREmployee.IsDBNull(2))
                        {
                            employee.EmpSalary = float.Parse(sqlDREmployee["EmpSalary"].ToString());
                        }

                        if (!sqlDREmployee.IsDBNull(3))
                        {
                            employee.EmpPosition = Convert.ToString(sqlDREmployee["EmpPosition"]);
                        }

                        if (!sqlDREmployee.IsDBNull(4))
                        {
                            employee.EmpDepartment = Convert.ToString(sqlDREmployee["EmpDepartment"]);
                        }

                        if (!sqlDREmployee.IsDBNull(5))
                        {
                            employee.EmpJoinDate = Convert.ToDateTime(sqlDREmployee["EmpJoinDate"]);
                        }

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public static int AddNewEmployee(Employee employee)
        {
            SqlConnection sqlConn = GetConnection();
            int rowsAdded = 0;
            using (sqlConn)
            {
                SqlCommand sqlCmd = new SqlCommand();

                string sp = "SP_CreateEmployee";
                sqlCmd.CommandText = sp;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter NameParmeter = new SqlParameter("@empName", employee.EmpName);
                sqlCmd.Parameters.Add(NameParmeter);
                if (employee.EmpSalary != null)
                {
                
                    SqlParameter salaryParmeter = new SqlParameter("@empSalary", employee.EmpSalary);
                    sqlCmd.Parameters.Add(salaryParmeter);
                }
                else
                {
                    SqlParameter salaryParmeter = new SqlParameter("@empSalary", DBNull.Value);
                    sqlCmd.Parameters.Add(salaryParmeter);
                }
                if (employee.EmpPosition != null)
                {
                    SqlParameter positionParmeter = new SqlParameter("@empPosition", employee.EmpPosition);
                    sqlCmd.Parameters.Add(positionParmeter);
                }
                else
                {
                    SqlParameter positionParmeter = new SqlParameter("@empPosition", DBNull.Value);
                    sqlCmd.Parameters.Add(positionParmeter);
                }
                if (employee.EmpDepartment != null)
                {
                    SqlParameter departmentParameter = new SqlParameter("@empDepartment", employee.EmpDepartment);
                    sqlCmd.Parameters.Add(departmentParameter);
                }
                else
                {
                    SqlParameter departmentParameter = new SqlParameter("@empDepartment", DBNull.Value);
                    sqlCmd.Parameters.Add(departmentParameter);
                }
                SqlParameter joinParameter = new SqlParameter("@empJoinDate", employee.EmpJoinDate);
                sqlCmd.Parameters.Add(joinParameter);
                
                sqlCmd.Connection = sqlConn;


                //rowsAdded = Convert.ToInt32(sqlCmd.ExecuteScalar());
                rowsAdded = sqlCmd.ExecuteNonQuery();
                
            }
            return rowsAdded;

        }

        public static int EditEmployee(Employee employee)
        {
            SqlConnection sqlConn = GetConnection();
            int rowsUpdated = 0;
            using (sqlConn)
            {
                SqlCommand sqlCmd = new SqlCommand();

                string sp = "SP_UpdateEmployee";
                sqlCmd.CommandText = sp;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@empID", employee.EmpId);
                sqlCmd.Parameters.Add(idParameter);
                SqlParameter NameParmeter = new SqlParameter("@empName", employee.EmpName);
                sqlCmd.Parameters.Add(NameParmeter);
                if (employee.EmpSalary != null)
                {

                    SqlParameter salaryParmeter = new SqlParameter("@empSalary", employee.EmpSalary);
                    sqlCmd.Parameters.Add(salaryParmeter);
                }
                else
                {
                    SqlParameter salaryParmeter = new SqlParameter("@empSalary", DBNull.Value);
                    sqlCmd.Parameters.Add(salaryParmeter);
                }
                if (employee.EmpPosition != null)
                {
                    SqlParameter positionParmeter = new SqlParameter("@empPosition", employee.EmpPosition);
                    sqlCmd.Parameters.Add(positionParmeter);
                }
                else
                {
                    SqlParameter positionParmeter = new SqlParameter("@empPosition", DBNull.Value);
                    sqlCmd.Parameters.Add(positionParmeter);
                }
                if (employee.EmpDepartment != null)
                {
                    SqlParameter departmentParameter = new SqlParameter("@empDepartment", employee.EmpDepartment);
                    sqlCmd.Parameters.Add(departmentParameter);
                }
                else
                {
                    SqlParameter departmentParameter = new SqlParameter("@empDepartment", DBNull.Value);
                    sqlCmd.Parameters.Add(departmentParameter);
                }
                SqlParameter joinParameter = new SqlParameter("@empJoinDate", employee.EmpJoinDate);
                sqlCmd.Parameters.Add(joinParameter);

                sqlCmd.Connection = sqlConn;


                //rowsAdded = Convert.ToInt32(sqlCmd.ExecuteScalar());
                rowsUpdated = sqlCmd.ExecuteNonQuery();

            }
            return rowsUpdated;

        }

        public static Employee GetEmployee(int id)
        {
            Employee foundEmployee = new Employee();            
            SqlConnection sqlConn = GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            string sp = "SP_GetEmployeeDetails";
            sqlCmd.CommandText = sp;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter IdParameter = new SqlParameter("@empId", id);
            sqlCmd.Connection = sqlConn;
            sqlCmd.Parameters.Add(IdParameter);
            SqlDataReader sqlDREmployee = sqlCmd.ExecuteReader();

            using (sqlConn)
            {
                using (sqlDREmployee)
                {
                    while (sqlDREmployee.Read())
                    {

                        if (!sqlDREmployee.IsDBNull(0))
                        {
                            foundEmployee.EmpId = Int32.Parse(sqlDREmployee["EmpId"].ToString());
                        }

                        if (!sqlDREmployee.IsDBNull(1))
                        {
                            foundEmployee.EmpName = Convert.ToString(sqlDREmployee["EmpName"]);
                        }

                        if (!sqlDREmployee.IsDBNull(2))
                        {
                            foundEmployee.EmpSalary = float.Parse(sqlDREmployee["EmpSalary"].ToString());
                        }

                        if (!sqlDREmployee.IsDBNull(3))
                        {
                            foundEmployee.EmpPosition = Convert.ToString(sqlDREmployee["EmpPosition"]);
                        }

                        if (!sqlDREmployee.IsDBNull(4))
                        {
                            foundEmployee.EmpDepartment = Convert.ToString(sqlDREmployee["EmpDepartment"]);
                        }

                        if (!sqlDREmployee.IsDBNull(5))
                        {
                            foundEmployee.EmpJoinDate = Convert.ToDateTime(sqlDREmployee["EmpJoinDate"]);
                        }
                        
                    }
                }
            }

            return foundEmployee;
        }

        public static int DeleteEmployee(int id)
        {
            SqlConnection sqlConn = GetConnection();
            int rowsAffected = 0;
            using (sqlConn)
            {
                SqlCommand sqlCmd = new SqlCommand();

                string sp = "SP_DeleteEmployee";
                sqlCmd.CommandText = sp;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter IDParmeter = new SqlParameter("@EmpId", id);
                sqlCmd.Parameters.Add(IDParmeter);
                sqlCmd.Connection = sqlConn;

                rowsAffected = sqlCmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }

    }
}