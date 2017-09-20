using System;
using System.Data;
using System.Data.SqlClient;

namespace IB_DataDB
{
    public class TickRepository
    {
        public int Save(Tick tick)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Tick_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("TickerId", tick.TickerId);
                    cmd.Parameters.AddWithValue("TickTime", tick.TickTime);
                    cmd.Parameters.AddWithValue("Field", tick.Field);
                    cmd.Parameters.AddWithValue("Price", tick.Price);
                    cmd.Parameters.AddWithValue("CanAutoExecute", tick.Attribs.CanAutoExecute);
                    cmd.Parameters.AddWithValue("PastLimit", tick.Attribs.PastLimit);
                    cmd.Parameters.AddWithValue("PreOpen", tick.Attribs.PreOpen);

                    connection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    if (result == 0) throw new Exception("Could not insert TickPrice:" + tick.ToString() + " " + tick.TickerId + " " + tick.TickTime);

                    return result;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return -1;
                //throw e;
            }
        }

        public int Save(TickSize tickSize)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Tick_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("TickerId", tickSize.TickerId);
                    cmd.Parameters.AddWithValue("TickTime", tickSize.TickTime);
                    cmd.Parameters.AddWithValue("Field", tickSize.Field);
                    cmd.Parameters.AddWithValue("Size", tickSize.Size);

                    connection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    if (result == 0) throw new Exception("Could not insert TickSize: " + tickSize.ToString() + " " + tickSize.TickerId + " " + tickSize.TickTime);

                    return result;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return -1;
                //throw e;
            }
        }

        public int Save(TickString tickString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Tick_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("TickerId", tickString.TickerId);
                    cmd.Parameters.AddWithValue("TickTime", tickString.TickTime);
                    cmd.Parameters.AddWithValue("TickType", tickString.TickType);
                    cmd.Parameters.AddWithValue("Value", tickString.Value);

                    connection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    if (result == 0) throw new Exception("Could not insert TickString: " + tickString.ToString() + " " + tickString.TickerId + " " + tickString.TickTime);

                    return result;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return -1;
                //throw e;
            }
        }

        public int Save(TickGeneric tickGeneric)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Tick_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("TickerId", tickGeneric.TickerId);
                    cmd.Parameters.AddWithValue("TickTime", tickGeneric.TickTime);
                    cmd.Parameters.AddWithValue("Field", tickGeneric.Field);
                    cmd.Parameters.AddWithValue("Value", tickGeneric.Value);

                    connection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    if (result == 0) throw new Exception("Could not insert TickGeneric: " + tickGeneric.ToString() + " " + tickGeneric.TickerId + " " + tickGeneric.TickTime);

                    return result;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return -1;
                //throw e;
            }
        }

        public int Save(TickReqParams tickReqParams)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Tick_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("TickerId", tickReqParams.TickerId);
                    cmd.Parameters.AddWithValue("TickTime", tickReqParams.TickTime);
                    cmd.Parameters.AddWithValue("MinTick", tickReqParams.MinTick);
                    cmd.Parameters.AddWithValue("BBOExchange", tickReqParams.BBOExchange);
                    cmd.Parameters.AddWithValue("SnapshotPermissions", tickReqParams.SnapshotPermissions);

                    connection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    if (result == 0) throw new Exception("Could not insert TickReqParams: " + tickReqParams.ToString() + " " + tickReqParams.TickerId + " " + tickReqParams.TickTime);

                    return result;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return -1;
                //throw e;
            }
        }
    }
}
