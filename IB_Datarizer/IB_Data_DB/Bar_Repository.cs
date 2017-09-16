using System;
using System.Data;
using System.Data.SqlClient;

namespace IB_Data_DB
{
    public class Bar_Repository
    {
        public int Save(Bar bar)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("BarInsert", connection);
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
                int result = cmd.ExecuteNonQuery();

                connection.Close();

                if (result == 0) throw new Exception("Could not insert bar:" + bar.ToString());

                return id;
            }
        }
    }
}
