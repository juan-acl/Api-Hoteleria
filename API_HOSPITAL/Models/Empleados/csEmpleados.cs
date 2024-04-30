using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace API_HOSPITAL.Models.Empleados
{
    public class csEmpleados
    {
        public csObjectEmpleados.responseEmpleado CreateEmpleado(string name, string lastname, string email, string password, string phone_number, string id_hotel)
        {
            csObjectEmpleados.responseEmpleado response = new csObjectEmpleados.responseEmpleado();
            string connectionString = "";
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "INSERT INTO employee (name, lastname, email, password, phone_number, id_hotel) VALUES (@name, @lastname, @email, @password, @phone_number, @id_hotel)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@lastname", lastname);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@phone_number", phone_number);
                command.Parameters.AddWithValue("@id_hotel", id_hotel);
                response.status = command.ExecuteNonQuery();
                response.message = "Empleado created successfully";
            }
            catch (Exception error)
            {
                response.status = 500;
                response.message = error.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }
        public csObjectEmpleados.responseEmpleado UpdateEmpleado(string name, string lastname, string email, string password, string phone_number, string id_hotel, int id_empleado)
        {
            csObjectEmpleados.responseEmpleado response = new csObjectEmpleados.responseEmpleado();
            string connectionString = "";
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "UPDATE employee SET name = @name, lastname = @lastname, email = @email, password = @password, phone_number = @phone_number, id_hotel = @id_hotel WHERE id_employee = @id_empleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@lastname", lastname);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@phone_number", phone_number);
                command.Parameters.AddWithValue("@id_hotel", id_hotel);
                command.Parameters.AddWithValue("@id_empleado", id_empleado);
                response.status = command.ExecuteNonQuery();
                response.message = "Empleado updated successfully";
            }
            catch (Exception error)
            {
                response.status = 500;
                response.message = error.Message;
            }
            finally
            {
            }
            return response;
        }
        public csObjectEmpleados.responseEmpleado DeleteEmpleado(int id_empleado)
        {
            csObjectEmpleados.responseEmpleado response = new csObjectEmpleados.responseEmpleado();
            string connectionString = "";
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "DELETE FROM employee WHERE id_employee = @id_empleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_empleado", id_empleado);
                response.status = command.ExecuteNonQuery();
                response.message = "Empleado deleted successfully";
            }
            catch (Exception error)
            {
                response.status = 500;
                response.message = error.Message;
            }
            finally
            {
            }
            return response;
        }
        public DataSet GetEmpleadoById(int id_empleado)
        {
            string connectionString = "";
            SqlConnection connection = null;
            DataSet dataSet = new DataSet();
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM employee WHERE id_employee = @id_empleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_empleado", id_empleado);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "employee";
            }
            catch (Exception error)
            {
                return null;
            }
            finally
            {
            }
            return dataSet;
        }
        public DataSet GetEmpleados()
        {
            csObjectEmpleados.responseEmpleado response = new csObjectEmpleados.responseEmpleado();
            string connectionString = "";
            SqlConnection connection = null;
            DataSet dataSet = new DataSet();
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM employee";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "employee";
            }
            catch (Exception error)
            {
                return null;
            }
            finally
            {
            }
            return dataSet;
        }
    }
}