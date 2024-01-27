using LH;

namespace WinFormsApp1
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            DefineFieldsDefaultValues();
            DefineSettings();
        }

        public void DefineFieldsDefaultValues()
        {
            LogPathFileTxb.Text = ".\\LOG_TEST\\Logging_general.log";

            LevelStackNud.Minimum = 0;
            LevelStackNud.Value = 4;

            LogValidityNud.Minimum = 0;
            LogValidityNud.Value = 3;

            LogLevelFileNud.Maximum = Enum.GetValues(typeof(LoggingHelper.Level)).Length - 1;
            LogLevelFileNud.Minimum = -1;
            LogLevelFileNud.Value = 0;

            LogLevelConsoleNud.Maximum = Enum.GetValues(typeof(LoggingHelper.Level)).Length - 1;
            LogLevelConsoleNud.Minimum = -1;
            LogLevelConsoleNud.Value = -1;

            MessageTxb.Text = "This is a log message.";
        }

        private void TraceBtn_Click(object sender, EventArgs e)
        {
            LoggingHelper.Write(MessageTxb.Text, LoggingHelper.Level.TRACE, ObservationTxb.Text);
        }

        private void DebugBtn_Click(object sender, EventArgs e)
        {
            LoggingHelper.Write(MessageTxb.Text, LoggingHelper.Level.DEBUG, ObservationTxb.Text);
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            LoggingHelper.Write(MessageTxb.Text, LoggingHelper.Level.INFO, ObservationTxb.Text);
        }

        private void WarningBtn_Click(object sender, EventArgs e)
        {
            LoggingHelper.Write(MessageTxb.Text, LoggingHelper.Level.WARNING, ObservationTxb.Text);
        }

        private void ErrorBtn_Click(object sender, EventArgs e)
        {
            LoggingHelper.Write(MessageTxb.Text, LoggingHelper.Level.ERROR, ObservationTxb.Text);
        }

        private void CriticalBtn_Click(object sender, EventArgs e)
        {
            LoggingHelper.Write(MessageTxb.Text, LoggingHelper.Level.CRITICAL, ObservationTxb.Text);
        }

        private void RandomBtn_Click(object sender, EventArgs e)
        {
            int randomIndex = new Random().Next(Enum.GetValues(typeof(LoggingHelper.Level)).Length);
            LoggingHelper.Write(MessageTxb.Text, randomIndex, ObservationTxb.Text);
        }

        public void DefineSettings()
        {
            LoggingHelper.LogValidity = (int)LogValidityNud.Value;
            LoggingHelper.LevelStack = (int)LevelStackNud.Value;
            LoggingHelper.LogPathFile = LogPathFileTxb.Text ?? ".\\LOG_TEST\\Logging_general.log";
            LoggingHelper.LogLevelFile = (int)LogLevelFileNud.Value;
            LoggingHelper.LogLevelConsole = (int)LogLevelConsoleNud.Value;
        }

        private void LogValidityNud_ValueChanged(object sender, EventArgs e)
        {
            LoggingHelper.LogValidity = (int)LogValidityNud.Value;
        }

        private void LevelStackNud_ValueChanged(object sender, EventArgs e)
        {
            LoggingHelper.LevelStack = (int)LevelStackNud.Value;
        }

        private void LogPathFileTxb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var folder = LogPathFileFbd.ShowDialog();
            if(folder == DialogResult.OK)
            {
                LogPathFileTxb.Text = LogPathFileFbd.SelectedPath + "\\Logging_general.log";
            }
        }

        private void LogPathFileTxb_TextChanged(object sender, EventArgs e)
        {
            LoggingHelper.LogPathFile = LogPathFileTxb.Text ?? ".\\LOG_TEST\\Logging_general.log";
        }

        private void LogLevelFileNud_ValueChanged(object sender, EventArgs e)
        {
            LoggingHelper.LogLevelFile = (int)LogLevelFileNud.Value;
        }

        private void LogLevelConsoleNud_ValueChanged(object sender, EventArgs e)
        {
            LoggingHelper.LogLevelConsole = (int)LogLevelConsoleNud.Value;
        }

        
    }
}