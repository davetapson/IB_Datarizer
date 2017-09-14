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

namespace IB_Datarizer
{
    public partial class frmMain : Form
    {
        //Create ibClient object to represent the connection
        // This will be used throughout the form
        EWrapperImpl ibClient;
        EClientSocket clientSocket;
        EReaderSignal readerSignal;



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

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
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

            // Set up the form object in the EWrapper
            ibClient.MainForm = (frmMain)Application.OpenForms[0];
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Disconnect from interactive Brokers
            ibClient.ClientSocket.eDisconnect();

            tslConnectionStatus.Text = "Disconnected";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Create a new contract to specify the security we are searching for
            IBApi.Contract contract = new IBApi.Contract();
            // Create a new TagValueList object (for API version 9.71 and later) 
            List<IBApi.TagValue> mktDataOptions = new List<IBApi.TagValue>();

            // Set the underlying stock symbol from the tbSymbol text box
            contract.Symbol = txtSymbol.Text;
            // Set the Security type to STK for a Stock
            contract.SecType = "FUT";
            // Use "SMART" as the general exchange
            contract.Exchange = txtExchange.Text;
            // Set the primary exchange (sometimes called Listing exchange)
            // Use either NYSE or ISLAND
            //contract.PrimaryExch = "ISLAND";
            // Set the currency to USD
            contract.Currency = "USD";

            contract.ConId = 236950077;

            // Kick off the subscription for real-time data (add the mktDataOptions list for API v9.71)
            ibClient.ClientSocket.reqMktData(1, contract, "233", false, false, null);// mktDataOptions);
                                                                                     // For API v9.72 and higher, add one more parameter for regulatory snapshot
                                                                                     // ibClient.ClientSocket.reqMktData(1, contract, "", false, false, mktDataOptions)

            //! [futcontract]
            //Contract contract = new Contract();
            //contract.Symbol = "ZC";
            //contract.SecType = "FUT";
            //contract.Exchange = "ECBOT";
            //contract.Currency = "USD";
            //contract.LastTradeDateOrContractMonth = "20170914";

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Make the call to cancel the market data subscription
            ibClient.ClientSocket.cancelMktData(1);
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

            // Now fill the ContractInfo object with the necessary information 
            // Contract identifier
            contract.ConId = 0;
            // Stock symbol
            contract.Symbol = txtSymbol.Text;
            // Type of instrument: Stock=STK,Option=OPT,Future=FUT, etc.
            contract.SecType = "FUT";
            // The destination of order or request. "SMART" =IB order router
            contract.Exchange = txtExchange.Text;
            // The primary exchange where the instrument trades. 
            // NYSE, NASDAQ, AMEX, BATS, ARCA, PHLX etc.
            //contract.PrimaryExch = "NASDAQ";
            // The currency of the exchange USD or GBP or CAD or EUR, etc.
            contract.Currency = "USD";
            // Now call reqHistoricalDataEx with parameters:
            // tickerId, Contract, endDateTime, durationStr, barSize, WhatToShow, 
            // useRTH, formatDate
            contract.ConId = 236950077;

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
    }
}
