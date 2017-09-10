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
            this.lstData = new System.Windows.Forms.ListBox();
            this.tlsFooter = new System.Windows.Forms.ToolStrip();
            this.tslConnectionStatus = new System.Windows.Forms.ToolStripLabel();
            this.tslServerTime = new System.Windows.Forms.ToolStripLabel();
            this.tlsFooter.SuspendLayout();
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
            this.txtSymbol.Location = new System.Drawing.Point(13, 43);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtSymbol.TabIndex = 4;
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(13, 70);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(385, 186);
            this.lstData.TabIndex = 5;
            // 
            // tlsFooter
            // 
            this.tlsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslConnectionStatus,
            this.tslServerTime});
            this.tlsFooter.Location = new System.Drawing.Point(0, 259);
            this.tlsFooter.Name = "tlsFooter";
            this.tlsFooter.Size = new System.Drawing.Size(410, 25);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 284);
            this.Controls.Add(this.tlsFooter);
            this.Controls.Add(this.lstData);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.ToolStrip tlsFooter;
        private System.Windows.Forms.ToolStripLabel tslConnectionStatus;
        private System.Windows.Forms.ToolStripLabel tslServerTime;
    }
}

