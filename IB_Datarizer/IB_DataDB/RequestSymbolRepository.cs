using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_DataDB
{
    public class RequestSymbolRepository
    {

        private List<RequestSymbol> requestSymbols;

        public RequestSymbolRepository()
        {
            requestSymbols = GetAll();
        }


        public List<RequestSymbol> RequestSymbols
        {
            get { return requestSymbols; }
        }

        public List<RequestSymbol> GetAll()
        {
            List<RequestSymbol> requestSymbols = new List<RequestSymbol>();

            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("RequestSymbol_GetAll", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RequestSymbol requestSymbol = new RequestSymbol();
                            requestSymbol.Id = reader.GetInt32(0);
                            requestSymbol.ReqId = reader.GetInt32(1);
                            requestSymbol.Symbol = reader.GetString(2);
                            requestSymbols.Add(requestSymbol);
                        }
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }

                return requestSymbols;
            }
        }

        public string GetSymbolForReqId(int reqId)
        {
            RequestSymbol requestSymbol = requestSymbols.Find(o => o.ReqId.Equals(reqId));

            return requestSymbol.Symbol;
        }

        public int GetReqIdForSymbol(string symbol)        {
            
            RequestSymbol requestSymbol = requestSymbols.Find(o => o.Symbol.Trim().Equals(symbol.Trim()));

            return requestSymbol.ReqId;
        }
    }
}
