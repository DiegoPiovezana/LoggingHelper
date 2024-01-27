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
            LevelStackNud.Minimum = 0;
            LevelStackNud.Value = 2;

            LogValidityNud.Minimum = 0;
            LogValidityNud.Value = 1;

            FormatLogOutputTxb.Text = "<dd/MM/yyyy HH:mm:ss.fff> [<level>] (<stack>) <message> | <obs>";

            LogPathFileTxb.Text = ".\\LOG_TEST\\Logging_general.log";

            LogLevelFileNud.Maximum = Enum.GetValues(typeof(LoggingHelper.Level)).Length - 1;
            LogLevelFileNud.Minimum = -1;
            LogLevelFileNud.Value = 0;

            LogLevelConsoleNud.Maximum = Enum.GetValues(typeof(LoggingHelper.Level)).Length - 1;
            LogLevelConsoleNud.Minimum = -1;
            LogLevelConsoleNud.Value = 0;

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
            LoggingHelper.FormatLogOutput = FormatLogOutputTxb.Text;
            LoggingHelper.LogPathFile = LogPathFileTxb.Text;
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
            if (LogPathFileFbd.ShowDialog() == DialogResult.OK) { LogPathFileTxb.Text = LogPathFileFbd.SelectedPath + "\\LoggingLH_Test.log"; }
        }

        private void LogPathFileTxb_TextChanged(object sender, EventArgs e)
        {
            LoggingHelper.LogPathFile = LogPathFileTxb.Text.Trim();
        }

        private void FormatLogOutputTxb_DoubleClick(object sender, EventArgs e)
        {
            FormatLogOutputTxb.Text = "<dd/MM/yyyy HH:mm:ss.fff> [<level>] (<stack>) <message> | <obs>";
        }

        private void FormatLogOutputTxb_TextChanged(object sender, EventArgs e)
        {
            LoggingHelper.FormatLogOutput = FormatLogOutputTxb.Text.Trim();
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