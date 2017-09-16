using IB_DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_Datarizer
{
    public static class DataUtils
    {
        public static List<RequestSymbol> GetRequestSymbols()
        {
            RequestSymbol_Repository requestSymbol_Repository = new RequestSymbol_Repository();
            return requestSymbol_Repository.RequestSymbols;
        }
    }
}
