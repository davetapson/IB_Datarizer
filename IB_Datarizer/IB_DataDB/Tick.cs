using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_DataDB
{
    public enum TickName {
        BidSize = 0,
        BidPrice = 1,
        AskPrice = 2,
        AskSize = 3,
        LastPrice = 4,
        LastSize = 5,
        High = 6, // high price for the day
        Low = 7, // low price for the day
        Volume = 8, // US stocks: multiplier 100
        ClosePrice = 9, // last price of prev day
        OpenTick = 14, // today's opening price
        Low13Weeks = 15,
        High13Weeks = 16,
        Low26Weeks = 17,
        High26Weeks = 18,
        Low52Weeks = 19,
        High52Weeks = 20,
        AverageVolume = 21 // ave daily trading volume over 90 days (multiply by 100)
    }

    public enum MarketDataType
    {
        Live = 1,
        Frozen = 2,
        Delayed = 3,
        DelayedFrozen = 4
    }

    public enum WhatToShow
    {
        MIDPOINT,
        TRADES,
        BID,
        ASK
    }

    public class TickPrice
    {
        public int TickerId { get; set; }
        public int Field { get; set; }
        public double Price { get; set; }
        public IBApi.TickAttrib Attribs { get; set; }
    }

    public class TickSize
    {
        public int TickerId { get; set; }
        public int Field { get; set; }
        public int Size { get; set; }
    }

    public class TickString
    {
        public int TickerId { get; set; }
        public int tickType { get; set; }
        public string Value { get; set; }
    }

    public class TickGeneric
    {
        public int TickerId { get; set; }
        public int Field { get; set; }
        public double Value { get; set; }
    }

    public class TickReqParams
    {
        public int TickerId { get; set; }
        public double MinTick { get; set; }
        public string BBOExchange { get; set; }
        public int SnapshotPermissions { get; set; }
    }

}
