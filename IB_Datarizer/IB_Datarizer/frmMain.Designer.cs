namespace IB_Datarizer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.lstRealTimeData = new System.Windows.Forms.ListBox();
            this.tlsFooter = new System.Windows.Forms.ToolStrip();
            this.tslConnectionStatus = new System.Windows.Forms.ToolStripLabel();
            this.tslServerTime = new System.Windows.Forms.ToolStripLabel();
            this.lstHistoricalData = new System.Windows.Forms.ListBox();
            this.btnGetHistoricalData = new System.Windows.Forms.Button();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExchange = new System.Windows.Forms.TextBox();
            this.cboDurationPeriod = new System.Windows.Forms.ComboBox();
            this.numDurationNumber = new System.Windows.Forms.NumericUpDown();
            this.cboHistoricBarSize = new System.Windows.Forms.ComboBox();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.lstRealTimeBars = new System.Windows.Forms.ListBox();
            this.btnRealTimeBarsStart = new System.Windows.Forms.Button();
            this.btRealTimeBarsStop = new System.Windows.Forms.Button();
            this.tlsFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(95, 13);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(177, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(259, 13);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(62, 42);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtSymbol.TabIndex = 4;
            this.txtSymbol.Text = "ES";
            // 
            // lstRealTimeData
            // 
            this.lstRealTimeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstRealTimeData.FormattingEnabled = true;
            this.lstRealTimeData.Location = new System.Drawing.Point(327, 70);
            this.lstRealTimeData.Name = "lstRealTimeData";
            this.lstRealTimeData.Size = new System.Drawing.Size(385, 290);
            this.lstRealTimeData.TabIndex = 5;
            // 
            // tlsFooter
            // 
            this.tlsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslConnectionStatus,
            this.tslServerTime});
            this.tlsFooter.Location = new System.Drawing.Point(0, 504);
            this.tlsFooter.Name = "tlsFooter";
            this.tlsFooter.Size = new System.Drawing.Size(1184, 25);
            this.tlsFooter.TabIndex = 6;
            this.tlsFooter.Text = "Footer ToolStrip";
            // 
            // tslConnectionStatus
            // 
            this.tslConnectionStatus.Name = "tslConnectionStatus";
            this.tslConnectionStatus.Size = new System.Drawing.Size(178, 22);
            this.tslConnectionStatus.Text = "Not Connected.  Press \'Connect\'";
            // 
            // tslServerTime
            // 
            this.tslServerTime.Name = "tslServerTime";
            this.tslServerTime.Size = new System.Drawing.Size(0, 22);
            // 
            // lstHistoricalData
            // 
            this.lstHistoricalData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHistoricalData.FormattingEnabled = true;
            this.lstHistoricalData.Location = new System.Drawing.Point(718, 70);
            this.lstHistoricalData.Name = "lstHistoricalData";
            this.lstHistoricalData.Size = new System.Drawing.Size(454, 290);
            this.lstHistoricalData.TabIndex = 7;
            // 
            // btnGetHistoricalData
            // 
            this.btnGetHistoricalData.Location = new System.Drawing.Point(404, 13);
            this.btnGetHistoricalData.Name = "btnGetHistoricalData";
            this.btnGetHistoricalData.Size = new System.Drawing.Size(75, 23);
            this.btnGetHistoricalData.TabIndex = 8;
            this.btnGetHistoricalData.Text = "Historical";
            this.btnGetHistoricalData.UseVisualStyleBackColor = true;
            this.btnGetHistoricalData.Click += new System.EventHandler(this.btnGetHistoricalData_Click);
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.Location = new System.Drawing.Point(569, 16);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDateTime.TabIndex = 9;
            this.dtpEndDateTime.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "End DateTime:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bars:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Duration:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Symbol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Exchange:";
            // 
            // txtExchange
            // 
            this.txtExchange.Location = new System.Drawing.Point(253, 42);
            this.txtExchange.Name = "txtExchange";
            this.txtExchange.Size = new System.Drawing.Size(100, 20);
            this.txtExchange.TabIndex = 17;
            this.txtExchange.Text = "GLOBEX";
            // 
            // cboDurationPeriod
            // 
            this.cboDurationPeriod.FormattingEnabled = true;
            this.cboDurationPeriod.Items.AddRange(new object[] {
            "S",
            "D",
            "W",
            "M",
            "Y"});
            this.cboDurationPeriod.Location = new System.Drawing.Point(735, 43);
            this.cboDurationPeriod.Name = "cboDurationPeriod";
            this.cboDurationPeriod.Size = new System.Drawing.Size(34, 21);
            this.cboDurationPeriod.TabIndex = 18;
            this.cboDurationPeriod.Text = "D";
            // 
            // numDurationNumber
            // 
            this.numDurationNumber.Location = new System.Drawing.Point(650, 44);
            this.numDurationNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDurationNumber.Name = "numDurationNumber";
            this.numDurationNumber.Size = new System.Drawing.Size(79, 20);
            this.numDurationNumber.TabIndex = 19;
            this.numDurationNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboHistoricBarSize
            // 
            this.cboHistoricBarSize.FormattingEnabled = true;
            this.cboHistoricBarSize.Items.AddRange(new object[] {
            "1 Secs",
            "5 Secs",
            "10 Secs",
            "15 Secs",
            "30 Secs",
            "1 Min",
            "2 Mins",
            "3 Mins",
            "5 Mins",
            "10 Mins",
            "15 Mins",
            "20 Mins",
            "30 Mins",
            "1 Hour",
            "2 Hours",
            "3 Hours",
            "4 Hours",
            "8 Hours",
            "1 Day",
            "1 W",
            "1 M"});
            this.cboHistoricBarSize.Location = new System.Drawing.Point(466, 43);
            this.cboHistoricBarSize.Name = "cboHistoricBarSize";
            this.cboHistoricBarSize.Size = new System.Drawing.Size(55, 21);
            this.cboHistoricBarSize.TabIndex = 21;
            this.cboHistoricBarSize.Text = "1 Min";
            this.cboHistoricBarSize.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lstErrors
            // 
            this.lstErrors.FormattingEnabled = true;
            this.lstErrors.Location = new System.Drawing.Point(15, 366);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(949, 134);
            this.lstErrors.TabIndex = 22;
            // 
            // lstRealTimeBars
            // 
            this.lstRealTimeBars.FormattingEnabled = true;
            this.lstRealTimeBars.Location = new System.Drawing.Point(12, 70);
            this.lstRealTimeBars.Name = "lstRealTimeBars";
            this.lstRealTimeBars.Size = new System.Drawing.Size(309, 290);
            this.lstRealTimeBars.TabIndex = 23;
            // 
            // btnRealTimeBarsStart
            // 
            this.btnRealTimeBarsStart.Location = new System.Drawing.Point(869, 13);
            this.btnRealTimeBarsStart.Name = "btnRealTimeBarsStart";
            this.btnRealTimeBarsStart.Size = new System.Drawing.Size(95, 23);
            this.btnRealTimeBarsStart.TabIndex = 24;
            this.btnRealTimeBarsStart.Text = "RTBars Start";
            this.btnRealTimeBarsStart.UseVisualStyleBackColor = true;
            this.btnRealTimeBarsStart.Click += new System.EventHandler(this.btnRealTimeBarsStart_Click);
            // 
            // btRealTimeBarsStop
            // 
            this.btRealTimeBarsStop.Location = new System.Drawing.Point(970, 13);
            this.btRealTimeBarsStop.Name = "btRealTimeBarsStop";
            this.btRealTimeBarsStop.Size = new System.Drawing.Size(83, 23);
            this.btRealTimeBarsStop.TabIndex = 25;
            this.btRealTimeBarsStop.Text = "RTBars Stop";
            this.btRealTimeBarsStop.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 529);
            this.Controls.Add(this.btRealTimeBarsStop);
            this.Controls.Add(this.btnRealTimeBarsStart);
            this.Controls.Add(this.lstRealTimeBars);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.cboHistoricBarSize);
            this.Controls.Add(this.numDurationNumber);
            this.Controls.Add(this.cboDurationPeriod);
            this.Controls.Add(this.txtExchange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDateTime);
            this.Controls.Add(this.btnGetHistoricalData);
            this.Controls.Add(this.lstHistoricalData);
            this.Controls.Add(this.tlsFooter);
            this.Controls.Add(this.lstRealTimeData);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmMain";
            this.Text = "IB_Datarizer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlsFooter.ResumeLayout(false);
            this.tlsFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.ListBox lstRealTimeData;
        private System.Windows.Forms.ToolStrip tlsFooter;
        private System.Windows.Forms.ToolStripLabel tslConnectionStatus;
        private System.Windows.Forms.ToolStripLabel tslServerTime;
        private System.Windows.Forms.ListBox lstHistoricalData;
        private System.Windows.Forms.Button btnGetHistoricalData;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExchange;
        private System.Windows.Forms.ComboBox cboDurationPeriod;
        private System.Windows.Forms.NumericUpDown numDurationNumber;
        private System.Windows.Forms.ComboBox cboHistoricBarSize;
        private System.Windows.Forms.ListBox lstErrors;
        private System.Windows.Forms.ListBox lstRealTimeBars;
        private System.Windows.Forms.Button btnRealTimeBarsStart;
        private System.Windows.Forms.Button btRealTimeBarsStop;
    }
}

