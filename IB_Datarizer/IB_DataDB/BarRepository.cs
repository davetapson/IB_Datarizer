using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IB_DataDB
{
    public class BarRepository
    {
        BarType_Repository barTypeRepository = new BarType_Repository();
        DateTime fiveMinBarLastBarTime = DateTime.MinValue;

        List<Bar> fiveMinBars = new List<Bar>();

        public int Save(Bar bar)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Bar_Insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ReqId", bar.ReqId);
                cmd.Parameters.AddWithValue("BarTimeUTC", bar.BarTimeUTC);
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

        public void MakeBars(BarSize barSize, Bar bar)
        {
            if (barSize == BarSize.FiveMin)
            {
                fiveMinBars.Add(bar);

                if (bar.BarTimeUTC.Minute % 5 == 0 &&
                    bar.BarTimeUTC.Minute != fiveMinBarLastBarTime.Minute)
                {
                    Bar fiveMinBar = new Bar();
                    fiveMinBar.ReqId = bar.ReqId;
                    fiveMinBar.BarTypeId = barTypeRepository.GetIDForBarTypeDesc("5 Min");
                    fiveMinBar.DateStamp = bar.DateStamp;
                    fiveMinBar.Symbol = bar.Symbol;
                    fiveMinBar.BarTimeUTC = bar.BarTimeUTC;
                    fiveMinBar.Open = fiveMinBars[0].Open;
                    fiveMinBar.High = fiveMinBars.Max(t => t.High);
                    fiveMinBar.Low = fiveMinBars.Min(t => t.Low);
                    fiveMinBar.Close = fiveMinBars[fiveMinBars.Count - 1].Close;
                    fiveMinBar.Vol = fiveMinBars.Sum((t => t.Vol));
                    fiveMinBar.Count = fiveMinBars.Sum(t => t.Count);

                    Save(fiveMinBar);

                    fiveMinBarLastBarTime = bar.BarTimeUTC;
                    fiveMinBars = new List<Bar>();
                } 
            }
        }
    }
}
