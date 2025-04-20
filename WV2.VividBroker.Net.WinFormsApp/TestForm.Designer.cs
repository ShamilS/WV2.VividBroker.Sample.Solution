namespace WV2.VividBroker.Net.WinFormsApp
{
    partial class TestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //SuspendLayout();
            //// 
            //// TestForm
            //// 
            //AutoScaleDimensions = new SizeF(7F, 17F);
            //AutoScaleMode = AutoScaleMode.Font;
            //ClientSize = new Size(1089, 558);
            //Name = "TestForm";
            //Text = "Form1";

            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.wvAndLogPanel = new System.Windows.Forms.Panel();
            this.wvAndLogSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.cmdNavigateAndWait = new System.Windows.Forms.Button();
            this.cmdAskQuestion = new System.Windows.Forms.Button();
            this.cmdGoToStartWebPage = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.wvAndLogPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvAndLogSplitContainer)).BeginInit();
            this.wvAndLogSplitContainer.Panel1.SuspendLayout();
            this.wvAndLogSplitContainer.Panel2.SuspendLayout();
            this.wvAndLogSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWebView)).BeginInit();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainTableLayoutPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.875F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.125F));
            this.mainTableLayoutPanel.Controls.Add(this.wvAndLogPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.commandPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // wvAndLogPanel
            // 
            this.wvAndLogPanel.Controls.Add(this.wvAndLogSplitContainer);
            this.wvAndLogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wvAndLogPanel.Location = new System.Drawing.Point(3, 3);
            this.wvAndLogPanel.Name = "wvAndLogPanel";
            this.mainTableLayoutPanel.SetRowSpan(this.wvAndLogPanel, 2);
            this.wvAndLogPanel.Size = new System.Drawing.Size(601, 444);
            this.wvAndLogPanel.TabIndex = 0;
            // 
            // wvAndLogSplitContainer
            // 
            this.wvAndLogSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wvAndLogSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.wvAndLogSplitContainer.Name = "wvAndLogSplitContainer";
            this.wvAndLogSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // wvAndLogSplitContainer.Panel1
            // 
            this.wvAndLogSplitContainer.Panel1.Controls.Add(this.mainWebView);
            // 
            // wvAndLogSplitContainer.Panel2
            // 
            this.wvAndLogSplitContainer.Panel2.Controls.Add(this.txtLog);
            this.wvAndLogSplitContainer.Size = new System.Drawing.Size(601, 444);
            this.wvAndLogSplitContainer.SplitterDistance = 341;
            this.wvAndLogSplitContainer.TabIndex = 0;
            // 
            // mainWebView
            // 
            this.mainWebView.AllowExternalDrop = true;
            this.mainWebView.CreationProperties = null;
            this.mainWebView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.mainWebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWebView.Location = new System.Drawing.Point(0, 0);
            this.mainWebView.Name = "mainWebView";
            this.mainWebView.Size = new System.Drawing.Size(601, 341);
            this.mainWebView.TabIndex = 0;
            this.mainWebView.ZoomFactor = 1D;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(601, 99);
            this.txtLog.TabIndex = 0;
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.cmdNavigateAndWait);
            this.commandPanel.Controls.Add(this.cmdAskQuestion);
            this.commandPanel.Controls.Add(this.cmdGoToStartWebPage);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandPanel.Location = new System.Drawing.Point(610, 3);
            this.commandPanel.Name = "commandPanel";
            this.mainTableLayoutPanel.SetRowSpan(this.commandPanel, 2);
            this.commandPanel.Size = new System.Drawing.Size(187, 444);
            this.commandPanel.TabIndex = 1;
            // 
            // cmdNavigateAndWait
            // 
            this.cmdNavigateAndWait.Location = new System.Drawing.Point(16, 92);
            this.cmdNavigateAndWait.Name = "cmdNavigateAndWait";
            this.cmdNavigateAndWait.Size = new System.Drawing.Size(157, 50);
            this.cmdNavigateAndWait.TabIndex = 4;
            this.cmdNavigateAndWait.Text = "Wait for \r\n\'Ask Question\' \r\nButton";
            this.cmdNavigateAndWait.UseVisualStyleBackColor = true;
            this.cmdNavigateAndWait.Click += new System.EventHandler(this.cmdNavigateAndWait_Click);
            // 
            // cmdAskQuestion
            // 
            this.cmdAskQuestion.Location = new System.Drawing.Point(16, 160);
            this.cmdAskQuestion.Name = "cmdAskQuestion";
            this.cmdAskQuestion.Size = new System.Drawing.Size(157, 50);
            this.cmdAskQuestion.TabIndex = 2;
            this.cmdAskQuestion.Text = "Navigate and Click \r\n\'Ask Question\' \r\nButton";
            this.cmdAskQuestion.UseVisualStyleBackColor = true;
            this.cmdAskQuestion.Click += new System.EventHandler(this.cmdAskQuestion_Click);
            // 
            // cmdGoToStartWebPage
            // 
            this.cmdGoToStartWebPage.Location = new System.Drawing.Point(16, 28);
            this.cmdGoToStartWebPage.Name = "cmdGoToStartWebPage";
            this.cmdGoToStartWebPage.Size = new System.Drawing.Size(157, 50);
            this.cmdGoToStartWebPage.TabIndex = 0;
            this.cmdGoToStartWebPage.Text = "Navigate to Start Web Page";
            this.cmdGoToStartWebPage.UseVisualStyleBackColor = true;
            this.cmdGoToStartWebPage.Click += new System.EventHandler(this.cmdGoToStartWebPage_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebView2: How to Ensure that a Web Page is Loaded";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.wvAndLogPanel.ResumeLayout(false);
            this.wvAndLogSplitContainer.Panel1.ResumeLayout(false);
            this.wvAndLogSplitContainer.Panel2.ResumeLayout(false);
            this.wvAndLogSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvAndLogSplitContainer)).EndInit();
            this.wvAndLogSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainWebView)).EndInit();
            this.commandPanel.ResumeLayout(false);
            this.ResumeLayout(false);


            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel wvAndLogPanel;
        private System.Windows.Forms.SplitContainer wvAndLogSplitContainer;
        private Microsoft.Web.WebView2.WinForms.WebView2 mainWebView;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Button cmdGoToStartWebPage;
        private System.Windows.Forms.Button cmdAskQuestion;
        private System.Windows.Forms.Button cmdNavigateAndWait;
    }
}
