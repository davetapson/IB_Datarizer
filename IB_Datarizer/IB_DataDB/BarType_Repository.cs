using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_DataDB
{
    public class BarType_Repository
    {
        List<BarType> barTypes;

        public BarType_Repository()
        {
            barTypes = GetAll();
        }

        private List<BarType> GetAll()
        {
            List<BarType> barTypes = new List<BarType>();

            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("BarType_GetAll", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BarType BarType = new BarType();
                        BarType.Id = reader.GetInt32(0);
                        BarType.Desc = reader.GetString(1);
                        barTypes.Add(BarType);
                    }
                }

                return barTypes;
            }
        }

        public int GetIDForBarTypeDesc(string desc)
        {
            BarType barType = barTypes.Find(o => o.Desc.Trim().Equals(desc));

            return barType.Id;
        }
    }
}
