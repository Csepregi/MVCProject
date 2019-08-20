using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["practice"].ConnectionString;

                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.id = Convert.ToInt32(rdr["id"]);
                        employee.name = rdr["name"].ToString();
                        employee.gender = rdr["gender"].ToString();
                        employee.city = rdr["city"].ToString();
                        if(!(rdr["dateofbirth"] is DBNull))
                        {
                            employee.birth = rdr["dateofbirth"].ToString();
                        }
                       

                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }
        public void AddEmmployee(Employee employee)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["practice"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.city;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.birth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveEmmployee(Employee employee)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["practice"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = employee.id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@name";
                paramName.Value = employee.name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@gender";
                paramGender.Value = employee.gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@city";
                paramCity.Value = employee.city;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@dateofbirth";
                paramDateOfBirth.Value = employee.birth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["practice"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}