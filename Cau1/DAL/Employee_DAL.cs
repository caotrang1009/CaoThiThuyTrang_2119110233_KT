using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    public class Employee_DAL:DbConnection
    {
        public List<Employee_BEL> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SelectAllEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee_BEL> lstEmps = new List<Employee_BEL>();
            Department_DAL dep = new Department_DAL();

            while (reader.Read())
            {
                Employee_BEL emp = new Employee_BEL();
                emp.Id = reader["IdEmployee"].ToString();
                emp.Name = reader["Name"].ToString();
                emp.Date = DateTime.Parse(reader["DataBirth"].ToString());
                if (int.Parse(reader["Gender"].ToString()) == 0)
                    emp.Gender = true;
                emp.Place = reader["PlaceBirth"].ToString();
                emp.Department = dep.ReadDepartment(reader["IdDepartment"].ToString());
                lstEmps.Add(emp);
            }
            conn.Close();
            return lstEmps;
        }

        public void DeleteEmployee(Employee_BEL emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.Id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Xoa nhan vien thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }

            finally
            {
                conn.Close();
            }
        }

        public void NewEmployee(Employee_BEL emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.Id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DataBirth", SqlDbType.Date).Value = emp.Date.ToShortDateString();
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.Place;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.NVarChar).Value = emp.Department.Id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Them nhan vien thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }

            finally
            {
                conn.Close();
            }
        }

        public void EditEmployee(Employee_BEL emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.Id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DataBirth", SqlDbType.Date).Value = emp.Date;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.Place;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.NVarChar).Value = emp.Department.Id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Sua nhan vien thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }

            finally
            {
                conn.Close();
            }
        }


    }
}
