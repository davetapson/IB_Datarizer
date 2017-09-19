using System;
using System.Data;
using System.Data.SqlClient;

namespace IB_DataDB
{
    public class Tick_Repository
    {
        public int Save(TickPrice tickPrice)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("TickPrice_Insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TickerId", tickPrice.TickerId);
                cmd.Parameters.AddWithValue("Field", tickPrice.Field);
                cmd.Parameters.AddWithValue("Price", tickPrice.Price);
                cmd.Parameters.AddWithValue("CanAutoExecute", tickPrice.Attribs.CanAutoExecute);
                cmd.Parameters.AddWithValue("PastLimit", tickPrice.Attribs.PastLimit);
                cmd.Parameters.AddWithValue("PreOpen", tickPrice.Attribs.PreOpen);

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                if (result == 0) throw new Exception("Could not insert TickPrice:" + tickPrice.ToString());

                return result;
            }
        }
    }
}
