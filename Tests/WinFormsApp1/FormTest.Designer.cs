namespace WinFormsApp1
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            LabelTittleTests = new Label();
            PicBoxLib = new PictureBox();
            TraceBtn = new Button();
            LogPathFileLbl = new Label();
            LogLevelConsoleLbl = new Label();
            LogValidityLbl = new Label();
            LogLevelFileLbl = new Label();
            LevelStackLbl = new Label();
            PanelConfigFile = new Panel();
            LogLevelFileNud = new NumericUpDown();
            LogPathFileTxb = new TextBox();
            PanelConfigLib = new Panel();
            LogValidityNud = new NumericUpDown();
            LevelStackNud = new NumericUpDown();
            FormatLogOutputTxb = new TextBox();
            FormatLogOutputLbl = new Label();
            PanelConfigConsole = new Panel();
            LogLevelConsoleNud = new NumericUpDown();
            ErrorBtn = new Button();
            WarningBtn = new Button();
            DebugBtn = new Button();
            InfoBtn = new Button();
            RandomBtn = new Button();
            CriticalBtn = new Button();
            PanelButtons = new Panel();
            LevelTxb = new TextBox();
            PanelInput = new Panel();
            MessageLbl = new Label();
            ObservationLbl = new Label();
            MessageTxb = new TextBox();
            ObservationTxb = new TextBox();
            LogPathFileFbd = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)PicBoxLib).BeginInit();
            PanelConfigFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogLevelFileNud).BeginInit();
            PanelConfigLib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogValidityNud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LevelStackNud).BeginInit();
            PanelConfigConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogLevelConsoleNud).BeginInit();
            PanelButtons.SuspendLayout();
            PanelInput.SuspendLayout();
            SuspendLayout();
            // 
            // LabelTittleTests
            // 
            LabelTittleTests.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelTittleTests.AutoSize = true;
            LabelTittleTests.BackColor = Color.Transparent;
            LabelTittleTests.Font = new Font("Roboto", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            LabelTittleTests.ForeColor = Color.White;
            LabelTittleTests.Location = new Point(544, 122);
            LabelTittleTests.Name = "LabelTittleTests";
            LabelTittleTests.Size = new Size(141, 57);
            LabelTittleTests.TabIndex = 0;
            LabelTittleTests.Text = "Tests";
            LabelTittleTests.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PicBoxLib
            // 
            PicBoxLib.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PicBoxLib.BackgroundImage = WinFormsApp.Properties.Resources.LoggingHelper_publish;
            PicBoxLib.BackgroundImageLayout = ImageLayout.Zoom;
            PicBoxLib.Location = new Point(345, 9);
            PicBoxLib.Name = "PicBoxLib";
            PicBoxLib.Size = new Size(363, 189);
            PicBoxLib.TabIndex = 1;
            PicBoxLib.TabStop = false;
            // 
            // TraceBtn
            // 
            TraceBtn.Anchor = AnchorStyles.None;
            TraceBtn.Location = new Point(138, 25);
            TraceBtn.Name = "TraceBtn";
            TraceBtn.Size = new Size(81, 28);
            TraceBtn.TabIndex = 2;
            TraceBtn.Text = "TRACE";
            TraceBtn.UseVisualStyleBackColor = true;
            TraceBtn.Click += TraceBtn_Click;
            // 
            // LogPathFileLbl
            // 
            LogPathFileLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            LogPathFileLbl.AutoSize = true;
            LogPathFileLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LogPathFileLbl.ForeColor = Color.White;
            LogPathFileLbl.Location = new Point(24, 10);
            LogPathFileLbl.Name = "LogPathFileLbl";
            LogPathFileLbl.Size = new Size(91, 20);
            LogPathFileLbl.TabIndex = 3;
            LogPathFileLbl.Text = "LogPathFile";
            // 
            // LogLevelConsoleLbl
            // 
            LogLevelConsoleLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogLevelConsoleLbl.AutoSize = true;
            LogLevelConsoleLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LogLevelConsoleLbl.ForeColor = Color.White;
            LogLevelConsoleLbl.Location = new Point(24, 10);
            LogLevelConsoleLbl.Name = "LogLevelConsoleLbl";
            LogLevelConsoleLbl.Size = new Size(126, 20);
            LogLevelConsoleLbl.TabIndex = 3;
            LogLevelConsoleLbl.Text = "LogLevelConsole";
            // 
            // LogValidityLbl
            // 
            LogValidityLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogValidityLbl.AutoSize = true;
            LogValidityLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LogValidityLbl.ForeColor = Color.White;
            LogValidityLbl.Location = new Point(182, 32);
            LogValidityLbl.Name = "LogValidityLbl";
            LogValidityLbl.Size = new Size(87, 20);
            LogValidityLbl.TabIndex = 3;
            LogValidityLbl.Text = "LogValidity";
            // 
            // LogLevelFileLbl
            // 
            LogLevelFileLbl.Anchor = AnchorStyles.Bottom;
            LogLevelFileLbl.AutoSize = true;
            LogLevelFileLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LogLevelFileLbl.ForeColor = Color.White;
            LogLevelFileLbl.Location = new Point(26, 78);
            LogLevelFileLbl.Name = "LogLevelFileLbl";
            LogLevelFileLbl.Size = new Size(95, 20);
            LogLevelFileLbl.TabIndex = 3;
            LogLevelFileLbl.Text = "LogLevelFile";
            // 
            // LevelStackLbl
            // 
            LevelStackLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LevelStackLbl.AutoSize = true;
            LevelStackLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LevelStackLbl.ForeColor = Color.White;
            LevelStackLbl.Location = new Point(33, 32);
            LevelStackLbl.Name = "LevelStackLbl";
            LevelStackLbl.Size = new Size(82, 20);
            LevelStackLbl.TabIndex = 3;
            LevelStackLbl.Text = "LevelStack";
            // 
            // PanelConfigFile
            // 
            PanelConfigFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            PanelConfigFile.BorderStyle = BorderStyle.Fixed3D;
            PanelConfigFile.Controls.Add(LogLevelFileNud);
            PanelConfigFile.Controls.Add(LogPathFileLbl);
            PanelConfigFile.Controls.Add(LogLevelFileLbl);
            PanelConfigFile.Controls.Add(LogPathFileTxb);
            PanelConfigFile.Location = new Point(469, 216);
            PanelConfigFile.Name = "PanelConfigFile";
            PanelConfigFile.Size = new Size(239, 149);
            PanelConfigFile.TabIndex = 5;
            // 
            // LogLevelFileNud
            // 
            LogLevelFileNud.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogLevelFileNud.Location = new Point(28, 101);
            LogLevelFileNud.Name = "LogLevelFileNud";
            LogLevelFileNud.Size = new Size(150, 27);
            LogLevelFileNud.TabIndex = 6;
            LogLevelFileNud.ValueChanged += LogLevelFileNud_ValueChanged;
            // 
            // LogPathFileTxb
            // 
            LogPathFileTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            LogPathFileTxb.Location = new Point(26, 33);
            LogPathFileTxb.Name = "LogPathFileTxb";
            LogPathFileTxb.Size = new Size(188, 27);
            LogPathFileTxb.TabIndex = 4;
            LogPathFileTxb.TextChanged += LogPathFileTxb_TextChanged;
            LogPathFileTxb.MouseDoubleClick += LogPathFileTxb_MouseDoubleClick;
            // 
            // PanelConfigLib
            // 
            PanelConfigLib.BackColor = Color.FromArgb(116, 166, 0);
            PanelConfigLib.Controls.Add(LogValidityNud);
            PanelConfigLib.Controls.Add(LevelStackNud);
            PanelConfigLib.Controls.Add(FormatLogOutputTxb);
            PanelConfigLib.Controls.Add(LogValidityLbl);
            PanelConfigLib.Controls.Add(FormatLogOutputLbl);
            PanelConfigLib.Controls.Add(LevelStackLbl);
            PanelConfigLib.Location = new Point(12, 12);
            PanelConfigLib.Name = "PanelConfigLib";
            PanelConfigLib.Size = new Size(317, 185);
            PanelConfigLib.TabIndex = 5;
            // 
            // LogValidityNud
            // 
            LogValidityNud.Location = new Point(182, 55);
            LogValidityNud.Name = "LogValidityNud";
            LogValidityNud.Size = new Size(106, 27);
            LogValidityNud.TabIndex = 6;
            LogValidityNud.ValueChanged += LogValidityNud_ValueChanged;
            // 
            // LevelStackNud
            // 
            LevelStackNud.Location = new Point(33, 55);
            LevelStackNud.Name = "LevelStackNud";
            LevelStackNud.Size = new Size(106, 27);
            LevelStackNud.TabIndex = 6;
            LevelStackNud.ValueChanged += LevelStackNud_ValueChanged;
            // 
            // FormatLogOutputTxb
            // 
            FormatLogOutputTxb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FormatLogOutputTxb.Location = new Point(33, 128);
            FormatLogOutputTxb.Name = "FormatLogOutputTxb";
            FormatLogOutputTxb.Size = new Size(255, 27);
            FormatLogOutputTxb.TabIndex = 4;
            FormatLogOutputTxb.TextChanged += FormatLogOutputTxb_TextChanged;
            FormatLogOutputTxb.DoubleClick += FormatLogOutputTxb_DoubleClick;
            // 
            // FormatLogOutputLbl
            // 
            FormatLogOutputLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FormatLogOutputLbl.AutoSize = true;
            FormatLogOutputLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormatLogOutputLbl.ForeColor = Color.White;
            FormatLogOutputLbl.Location = new Point(33, 102);
            FormatLogOutputLbl.Name = "FormatLogOutputLbl";
            FormatLogOutputLbl.Size = new Size(136, 20);
            FormatLogOutputLbl.TabIndex = 3;
            FormatLogOutputLbl.Text = "FormatLogOutput";
            // 
            // PanelConfigConsole
            // 
            PanelConfigConsole.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PanelConfigConsole.BorderStyle = BorderStyle.Fixed3D;
            PanelConfigConsole.Controls.Add(LogLevelConsoleNud);
            PanelConfigConsole.Controls.Add(LogLevelConsoleLbl);
            PanelConfigConsole.Location = new Point(469, 382);
            PanelConfigConsole.Name = "PanelConfigConsole";
            PanelConfigConsole.Size = new Size(239, 77);
            PanelConfigConsole.TabIndex = 5;
            // 
            // LogLevelConsoleNud
            // 
            LogLevelConsoleNud.Location = new Point(28, 29);
            LogLevelConsoleNud.Name = "LogLevelConsoleNud";
            LogLevelConsoleNud.Size = new Size(150, 27);
            LogLevelConsoleNud.TabIndex = 6;
            LogLevelConsoleNud.ValueChanged += LogLevelConsoleNud_ValueChanged;
            // 
            // ErrorBtn
            // 
            ErrorBtn.Anchor = AnchorStyles.None;
            ErrorBtn.Location = new Point(237, 73);
            ErrorBtn.Name = "ErrorBtn";
            ErrorBtn.Size = new Size(81, 28);
            ErrorBtn.TabIndex = 2;
            ErrorBtn.Text = "ERROR";
            ErrorBtn.UseVisualStyleBackColor = true;
            ErrorBtn.Click += ErrorBtn_Click;
            // 
            // WarningBtn
            // 
            WarningBtn.Anchor = AnchorStyles.None;
            WarningBtn.Location = new Point(138, 73);
            WarningBtn.Name = "WarningBtn";
            WarningBtn.Size = new Size(81, 28);
            WarningBtn.TabIndex = 2;
            WarningBtn.Text = "WARN";
            WarningBtn.UseVisualStyleBackColor = true;
            WarningBtn.Click += WarningBtn_Click;
            // 
            // DebugBtn
            // 
            DebugBtn.Anchor = AnchorStyles.None;
            DebugBtn.Location = new Point(237, 25);
            DebugBtn.Name = "DebugBtn";
            DebugBtn.Size = new Size(81, 28);
            DebugBtn.TabIndex = 2;
            DebugBtn.Text = "DEBUG";
            DebugBtn.UseVisualStyleBackColor = true;
            DebugBtn.Click += DebugBtn_Click;
            // 
            // InfoBtn
            // 
            InfoBtn.Anchor = AnchorStyles.None;
            InfoBtn.Location = new Point(338, 25);
            InfoBtn.Name = "InfoBtn";
            InfoBtn.Size = new Size(81, 28);
            InfoBtn.TabIndex = 2;
            InfoBtn.Text = "INFO";
            InfoBtn.UseVisualStyleBackColor = true;
            InfoBtn.Click += InfoBtn_Click;
            // 
            // RandomBtn
            // 
            RandomBtn.Anchor = AnchorStyles.None;
            RandomBtn.Location = new Point(15, 25);
            RandomBtn.Name = "RandomBtn";
            RandomBtn.Size = new Size(100, 28);
            RandomBtn.TabIndex = 2;
            RandomBtn.Text = "RANDOM";
            RandomBtn.UseVisualStyleBackColor = true;
            RandomBtn.Click += RandomBtn_Click;
            // 
            // CriticalBtn
            // 
            CriticalBtn.Anchor = AnchorStyles.None;
            CriticalBtn.Location = new Point(337, 73);
            CriticalBtn.Name = "CriticalBtn";
            CriticalBtn.Size = new Size(81, 28);
            CriticalBtn.TabIndex = 2;
            CriticalBtn.Text = "CRITICAL";
            CriticalBtn.UseVisualStyleBackColor = true;
            CriticalBtn.Click += CriticalBtn_Click;
            // 
            // PanelButtons
            // 
            PanelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelButtons.BackColor = Color.FromArgb(116, 166, 0);
            PanelButtons.Controls.Add(DebugBtn);
            PanelButtons.Controls.Add(TraceBtn);
            PanelButtons.Controls.Add(LevelTxb);
            PanelButtons.Controls.Add(ErrorBtn);
            PanelButtons.Controls.Add(CriticalBtn);
            PanelButtons.Controls.Add(RandomBtn);
            PanelButtons.Controls.Add(WarningBtn);
            PanelButtons.Controls.Add(InfoBtn);
            PanelButtons.Location = new Point(12, 340);
            PanelButtons.Name = "PanelButtons";
            PanelButtons.Size = new Size(441, 119);
            PanelButtons.TabIndex = 5;
            // 
            // LevelTxb
            // 
            LevelTxb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LevelTxb.Location = new Point(15, 73);
            LevelTxb.Name = "LevelTxb";
            LevelTxb.Size = new Size(102, 27);
            LevelTxb.TabIndex = 4;
            LevelTxb.TextAlign = HorizontalAlignment.Center;
            LevelTxb.DoubleClick += LevelTxb_DoubleClick;
            // 
            // PanelInput
            // 
            PanelInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelInput.BackColor = Color.FromArgb(116, 166, 0);
            PanelInput.Controls.Add(MessageLbl);
            PanelInput.Controls.Add(ObservationLbl);
            PanelInput.Controls.Add(MessageTxb);
            PanelInput.Controls.Add(ObservationTxb);
            PanelInput.Location = new Point(12, 216);
            PanelInput.Name = "PanelInput";
            PanelInput.Size = new Size(441, 104);
            PanelInput.TabIndex = 5;
            // 
            // MessageLbl
            // 
            MessageLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MessageLbl.AutoSize = true;
            MessageLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MessageLbl.ForeColor = Color.White;
            MessageLbl.Location = new Point(13, 28);
            MessageLbl.Name = "MessageLbl";
            MessageLbl.Size = new Size(70, 20);
            MessageLbl.TabIndex = 3;
            MessageLbl.Text = "Message";
            // 
            // ObservationLbl
            // 
            ObservationLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ObservationLbl.AutoSize = true;
            ObservationLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ObservationLbl.ForeColor = Color.White;
            ObservationLbl.Location = new Point(13, 67);
            ObservationLbl.Name = "ObservationLbl";
            ObservationLbl.Size = new Size(95, 20);
            ObservationLbl.TabIndex = 3;
            ObservationLbl.Text = "Observation";
            // 
            // MessageTxb
            // 
            MessageTxb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MessageTxb.Location = new Point(118, 25);
            MessageTxb.Name = "MessageTxb";
            MessageTxb.Size = new Size(300, 27);
            MessageTxb.TabIndex = 4;
            // 
            // ObservationTxb
            // 
            ObservationTxb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ObservationTxb.Location = new Point(118, 64);
            ObservationTxb.Name = "ObservationTxb";
            ObservationTxb.Size = new Size(300, 27);
            ObservationTxb.TabIndex = 4;
            // 
            // FormTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(94, 135, 0);
            ClientSize = new Size(720, 471);
            Controls.Add(PanelButtons);
            Controls.Add(PanelInput);
            Controls.Add(PanelConfigLib);
            Controls.Add(PanelConfigConsole);
            Controls.Add(PanelConfigFile);
            Controls.Add(LabelTittleTests);
            Controls.Add(PicBoxLib);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(738, 518);
            Name = "FormTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoggingHelper Tests";
            ((System.ComponentModel.ISupportInitialize)PicBoxLib).EndInit();
            PanelConfigFile.ResumeLayout(false);
            PanelConfigFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogLevelFileNud).EndInit();
            PanelConfigLib.ResumeLayout(false);
            PanelConfigLib.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogValidityNud).EndInit();
            ((System.ComponentModel.ISupportInitialize)LevelStackNud).EndInit();
            PanelConfigConsole.ResumeLayout(false);
            PanelConfigConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogLevelConsoleNud).EndInit();
            PanelButtons.ResumeLayout(false);
            PanelButtons.PerformLayout();
            PanelInput.ResumeLayout(false);
            PanelInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTittleTests;
        private PictureBox PicBoxLib;
        private Button TraceBtn;
        private Label LogPathFileLbl;
        private Label LogLevelConsoleLbl;
        private Label LogValidityLbl;
        private Label LogLevelFileLbl;
        private Label LevelStackLbl;
        private Panel PanelConfigFile;
        private Panel PanelConfigLib;
        private Panel PanelConfigConsole;
        private TextBox LogPathFileTxb;
        private Button ErrorBtn;
        private Button WarningBtn;
        private Button DebugBtn;
        private Button InfoBtn;
        private Button RandomBtn;
        private Button CriticalBtn;
        private Panel PanelButtons;
        private Panel PanelInput;
        private Label MessageLbl;
        private Label ObservationLbl;
        private TextBox MessageTxb;
        private TextBox ObservationTxb;
        private NumericUpDown LevelStackNud;
        private NumericUpDown LogValidityNud;
        private NumericUpDown LogLevelFileNud;
        private NumericUpDown LogLevelConsoleNud;
        private FolderBrowserDialog LogPathFileFbd;
        private TextBox FormatLogOutputTxb;
        private Label FormatLogOutputLbl;
        private TextBox LevelTxb;
    }
}