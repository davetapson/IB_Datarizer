using System;

namespace IB_DataDB
{
    public enum BarSize { FiveMin }
    public class Bar
    {
        public Bar() { }

        public Bar(int id, int reqId, DateTime barTimeUTC, DateTime dateStamp, string symbol,
            int barTypeId, decimal open, decimal high, decimal low, decimal close,
            int vol, int count, int wap)
        {
            Id = id;
            ReqId = reqId;
            BarTimeUTC = barTimeUTC;
            DateStamp = dateStamp;
            Symbol = symbol;
            BarTypeId = barTypeId;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Vol = vol;
            Count = count;
            WAP = wap;
        }

        public int Id { get;  set; }
        public int ReqId { get; set; }
        public DateTime BarTimeUTC { get; set; }
        public DateTime DateStamp { get; set; }
        public string Symbol { get; set; }
        public int BarTypeId { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public int Vol { get; set; }
        public int Count { get; set; }
        public int WAP { get; set; }
    }
}
