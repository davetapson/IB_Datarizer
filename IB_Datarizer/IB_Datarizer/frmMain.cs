﻿using IB_DataDB;
using IBApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using ConfigFileReader;
using System.IO;

namespace IB_Datarizer
{
    public partial class frmMain : Form
    {
        //Create ibClient object to represent the connection
        // This will be used throughout the form
        EWrapperImpl ibClient;
        EClientSocket clientSocket;
        EReaderSignal readerSignal;
        RequestSymbolRepository requestSymbol_Repository;

        string configFile = "C:\\IB_Datarizer\\config\\IB_Datarizer.config";
        List<ConfigSetting> configSettings;

        private static Logger logger;



        // This delegate enables asynchronous calls for setting
        // the text property on a ListBox control.
        delegate void SetTextCallback(string text);

        public void AddRealTimeListBoxItem(string text)
        {
            // See if a new invocation is required form a different thread
            if (this.lstRealTimeData.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddRealTimeListBoxItem);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // Add the text string to the list box
                this.lstRealTimeData.Items.Add(text);
            }
        }

        public void AddRealTimeBarsListBoxItem(string text)
        {
            // See if a new invocation is required form a different thread
            if (this.lstRealTimeBars.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddRealTimeBarsListBoxItem);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // Add the text string to the list box
                this.lstRealTimeBars.Items.Add(text);
            }
        }

        public void AddHistoricalListBoxItem(string text)
        {
            // See if a new invocation is required form a different thread
            if (this.lstHistoricalData.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddHistoricalListBoxItem);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // Add the text string to the list box
                this.lstHistoricalData.Items.Add(text);
            }
        }

        public void AddErrorsListBoxItem(string text)
        {
            // See if a new invocation is required form a different thread
            if (this.lstErrors.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddErrorsListBoxItem);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // Add the text string to the list box
                this.lstErrors.Items.Add(text);
            }
        }

        public frmMain()
        {
            InitializeComponent();
            
            // Instantiate ibClient
            ibClient = new EWrapperImpl();
             clientSocket = ibClient.ClientSocket;
             readerSignal = ibClient.Signal;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            logger = LogManager.GetCurrentClassLogger();
            logger.Info("App Started.");
            configSettings = GetConfigSettings(configFile);
            SetConfigSettings(configSettings);

            requestSymbol_Repository = new RequestSymbolRepository();

        }

        private void SetConfigSettings(List<ConfigSetting> configSettings)
        {
            txtSymbol.Text = configSettings.Find(x => x.Key == "Symbol").Value;
            txtExchange.Text = configSettings.Find(x => x.Key == "Exchange").Value;
            cboDurationPeriod.Text = configSettings.Find(x => x.Key == "DurationPeriod").Value;
            numDurationNumber.Value = Convert.ToDecimal(configSettings.Find(x => x.Key == "DurationNumber").Value);
            cboHistoricBarSize.Text = configSettings.Find(x => x.Key == "BarSize").Value;
            dtpEndDateTime.Value = Convert.ToDateTime( configSettings.Find(x => x.Key == "EndDateTime").Value);
        }

        private List<ConfigSetting> GetConfigSettings(string configFile)
        {
            // ensure directory/file exists
            Directory.CreateDirectory(Path.GetDirectoryName(configFile));
            if (!File.Exists(configFile)) { File.WriteAllText(configFile, ""); }

            // get config fle
            ConfigFile cf = new ConfigFile(configFile);
            return cf.ConfigSettings;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Set up the form object in the EWrapper
            ibClient.MainForm = (frmMain)Application.OpenForms[0];

            // Connect to the IB Server through TWS. Parameters are:
            // host       - Host name or IP address of the host running TWS
            // port       - The port TWS listens through for connections
            // clientId   - The identifier of the client application
            ibClient.ClientSocket.eConnect("", 4002, 0);

            // For IB TWS API version 9.72 and higher, implement this
            // signal-handling code. Otherwise comment it out.
            //var reader = new EReader(ibClient.ClientSocket, ibClient.Signal);
            //reader.Start();
            //new Thread(() => {
            //    while (ibClient.ClientSocket.IsConnected())
            //    {
            //        ibClient.Signal.waitForSignal();
            //        reader.processMsgs();
            //    }
            //})
            //{ IsBackground = true }.Start();

            tslConnectionStatus.Text = "Connecting...";


            var reader = new EReader(clientSocket, readerSignal);
            reader.Start();
            //Once the messages are in the queue, an additional thread can be created to fetch them
            new Thread(() => { while (clientSocket.IsConnected()) { readerSignal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();
            //!


            // Pause here until the connection is complete 
            while (ibClient.NextOrderId <= 0) {}

            tslConnectionStatus.Text = "Connected";

            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Disconnect from interactive Brokers
            ibClient.ClientSocket.eDisconnect();

            tslConnectionStatus.Text = "Disconnected";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int requestId = requestSymbol_Repository.GetReqIdForSymbol(txtSymbol.Text);

            // Create a new contract to specify the security we are searching for
            IBApi.Contract contract = new IBApi.Contract();
            //       // Create a new TagValueList object (for API version 9.71 and later) 
                   List<IBApi.TagValue> mktDataOptions = new List<IBApi.TagValue>();

            //       // Set the underlying stock symbol from the tbSymbol text box
            ////       contract.Symbol = txtSymbol.Text;
            //       // Set the Security type to STK for a Stock
            //       contract.SecType = "FUT";
            //       // Use "SMART" as the general exchange
            //       contract.Exchange = txtExchange.Text;
            //       // Set the primary exchange (sometimes called Listing exchange)
            //       // Use either NYSE or ISLAND
            //       //contract.PrimaryExch = "ISLAND";
            //       // Set the currency to USD
            //       contract.Currency = "USD";

            //       contract.ConId = 236950077;
            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20171215"; //15/12/2017

            // Kick off the subscription for real-time data (add the mktDataOptions list for API v9.71)
            //ibClient.ClientSocket.reqMktData(1, contract, "233", false, false, null);// mktDataOptions);
            // For API v9.72 and higher, add one more parameter for regulatory snapshot
            ibClient.ClientSocket.reqMktData(/*requestId*/ 5, contract, "", false, false, mktDataOptions);

            //! [futcontract]
            //Contract contract = new Contract();
            //contract.Symbol = "ZC";
            //contract.SecType = "FUT";
            //contract.Exchange = "ECBOT";
            //contract.Currency = "USD";
            //contract.LastTradeDateOrContractMonth = "20170914";
            
            //ibClient.ClientSocket.reqRealTimeBars(requestId, contract, 5, "TRADES", true, null);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Make the call to cancel the market data subscription
            ibClient.ClientSocket.cancelMktData(5);
            int requestId = requestSymbol_Repository.GetReqIdForSymbol(txtSymbol.Text);
            ibClient.ClientSocket.cancelRealTimeBars(requestId);
        }

        public void SetServerTime(string serverTime)
        {
            tslServerTime.Text = serverTime;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGetHistoricalData_Click(object sender, EventArgs e)
        {
            // First clear out the list box
            lstHistoricalData.Items.Clear();

            // Create a new contract object
            IBApi.Contract contract = new IBApi.Contract();

            // Create a new TagValueList object (for API version 9.71)
            List<IBApi.TagValue> mktDataOptions = new List<IBApi.TagValue>();

            //// Now fill the ContractInfo object with the necessary information 
            //// Contract identifier
            //contract.ConId = 0;
            //// Stock symbol
            //contract.Symbol = txtSymbol.Text;
            //// Type of instrument: Stock=STK,Option=OPT,Future=FUT, etc.
            //contract.SecType = "FUT";
            //// The destination of order or request. "SMART" =IB order router
            //contract.Exchange = txtExchange.Text;
            //// The primary exchange where the instrument trades. 
            //// NYSE, NASDAQ, AMEX, BATS, ARCA, PHLX etc.
            ////contract.PrimaryExch = "NASDAQ";
            //// The currency of the exchange USD or GBP or CAD or EUR, etc.
            //contract.Currency = "USD";
            //// Now call reqHistoricalDataEx with parameters:
            //// tickerId, Contract, endDateTime, durationStr, barSize, WhatToShow, 
            //// useRTH, formatDate
            //contract.ConId = 236950077;

            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20171215"; //15/12/2017

            ibClient.ClientSocket.reqHistoricalData(1, contract,
                 dtpEndDateTime.Value.ToString("yyyyMMdd HH:mm:ss" ),
                 numDurationNumber.Value + " " + cboDurationPeriod.Text,// txtDuration.Text,
                 cboHistoricBarSize.Text, // + " " + cboBarSize.Text, //   txtBars.Text,
                 "TRADES", 1,1, true, mktDataOptions);

            // For API Version 9.71, add the TagValueList object  
            // named ChartOptions to the last parameter on the call to 
            // reqHistoricalDataEx
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRealTimeBarsStart_Click(object sender, EventArgs e)
        {
            int requestId = requestSymbol_Repository.GetReqIdForSymbol(txtSymbol.Text);

            // Create a new contract to specify the security we are searching for
            IBApi.Contract contract = new IBApi.Contract();
            // Create a new TagValueList object (for API version 9.71 and later) 
     //       List<IBApi.TagValue> mktDataOptions = new List<IBApi.TagValue>();

            // Set the underlying stock symbol from the tbSymbol text box
            //       contract.Symbol = txtSymbol.Text;
            // Set the Security type to STK for a Stock
    //        contract.SecType = "FUT";
            // Use "SMART" as the general exchange
    //        contract.Exchange = txtExchange.Text;
            // Set the primary exchange (sometimes called Listing exchange)
            // Use either NYSE or ISLAND
            //contract.PrimaryExch = "ISLAND";
            // Set the currency to USD
   //         contract.Currency = "USD";

    //        contract.ConId = 236950077;

            // Kick off the subscription for real-time data (add the mktDataOptions list for API v9.71)
            //ibClient.ClientSocket.reqMktData(1, contract, "233", false, false, null);// mktDataOptions);
            // For API v9.72 and higher, add one more parameter for regulatory snapshot
    //        ibClient.ClientSocket.reqMktData(/*requestId*/ 5, contract, "", false, false, mktDataOptions);

            //! [futcontract]
            //Contract contract = new Contract();
            //contract.Symbol = "ZC";
            //contract.SecType = "FUT";
            //contract.Exchange = "ECBOT";
            //contract.Currency = "USD";
            //contract.LastTradeDateOrContractMonth = "20170914";

            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20171215"; //15/12/2017

            ibClient.ClientSocket.reqRealTimeBars(1, contract, 5, "TRADES", true, null);
        }
    }
}
