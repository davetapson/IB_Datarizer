using System;
using System.Data;
using System.Data.SqlClient;

namespace IB_DataDB
{
    public class Bar_Repository
    {
        public int Save(Bar bar)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Bar_Insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ReqId", bar.ReqId);
                cmd.Parameters.AddWithValue("Time", bar.Time);
                cmd.Parameters.AddWithValue("DateStamp", bar.DateStamp);
                cmd.Parameters.AddWithValue("Symbol", bar.Symbol);
                cmd.Parameters.AddWithValue("BarTypeId", bar.BarTypeId);
                cmd.Parameters.AddWithValue("Open", bar.Open);
                cmd.Parameters.AddWithValue("High", bar.High);
                cmd.Parameters.AddWithValue("Low", bar.Low);
                cmd.Parameters.AddWithValue("Close", bar.Close);
                cmd.Parameters.AddWithValue("Vol", bar.Vol);
                cmd.Parameters.AddWithValue("Count", bar.Count);
                cmd.Parameters.AddWithValue("WAP", bar.WAP);

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                if (result == 0) throw new Exception("Could not insert bar:" + bar.ToString());

                return result;
            }
        }
    }
}
