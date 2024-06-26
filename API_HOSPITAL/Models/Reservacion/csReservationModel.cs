﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI.WebControls;

namespace API_HOSPITAL.Models.ReservationModel
{
    public class csReservationModel
    {
        public csObjectsReservationModel.responseReservation CreateReservation(decimal total, DateTime emition_date, int id_client)
        {
            csObjectsReservationModel.responseReservation response = new csObjectsReservationModel.responseReservation();
            string connectionString = "";
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "INSERT INTO reservation (total, emition_date, id_client) VALUES (@total, @emition_date, @id_client)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@emition_date", emition_date);
                command.Parameters.AddWithValue("@id_client", id_client);
                response.status = command.ExecuteNonQuery();
                response.message = "Reservation created successfully";
            }catch(Exception error)
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
        public csObjectsReservationModel.responseReservation UpdateReservation(decimal Total, DateTime EmitionDate, int IdClient, int IdReservation)
        {
            csObjectsReservationModel.responseReservation response = new csObjectsReservationModel.responseReservation();
            string connectionString = "";
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "UPDATE reservation SET total = @total, emition_date = @emition_date, id_client = @id_client WHERE id_reservation = @id_reservation";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@total", Total);
                command.Parameters.AddWithValue("@emition_date", EmitionDate);
                command.Parameters.AddWithValue("@id_client", IdClient);
                command.Parameters.AddWithValue("@id_reservation", IdReservation);
                response.status = command.ExecuteNonQuery();
                response.message = "Reservation updated successfully";
            }catch(Exception error)
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
        public csObjectsReservationModel.responseReservation DeleteReservation(int IdReservation)
        {
            csObjectsReservationModel.responseReservation response = new csObjectsReservationModel.responseReservation();
            string connectionString = "";
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "DELETE FROM reservation WHERE id_reservation = @id_reservation";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_reservation", IdReservation);
                response.status = command.ExecuteNonQuery();
                response.message = "Reservation deleted successfully";
            }catch(Exception error)
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
        public DataSet GetReservationById(int IdReservation)
        {
            string connectionString = "";
            SqlConnection connection = null;
            DataSet dataSet = new DataSet();
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM reservation WHERE id_reservation = @id_reservation";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_reservation", IdReservation);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "reservation";
            }
            catch(Exception error)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return dataSet;
        }
        public DataSet GetAllReservations()
        {
            string connectionString = "";
            DataSet dataSet = new DataSet();
            SqlConnection connection = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM reservation";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "reservation";
            }
            catch(Exception error)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return dataSet;
        }
    }
}