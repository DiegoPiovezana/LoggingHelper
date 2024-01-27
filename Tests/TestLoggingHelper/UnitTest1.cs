using LoggingHelper = LH.LoggingHelper;

namespace TestLoggingHelper
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public void CodigoExemploReadme()
        {
            try
            {
                //LoggingHelper.Check();
                LoggingHelper.Write("This is a trace log message.", 0, "Start application.");
                LoggingHelper.Write("Debug message.", 1, null);
                LoggingHelper.Write("This is a message for an information log.", 2, null);
                LoggingHelper.Write("This is also a message for an information log.", LoggingHelper.Level.INFO, null);

                throw new Exception();
            }
            catch (Exception ex)
            {
                LoggingHelper.Write("This is a log message for logging errors!", 4, ex.Message);
            }
        }

        [Test]
        public void Test2()
        {           
            //LoggingHelper.LogPath = ".\\LOG_TEST\\Logging_general.log";
            //LoggingHelper.Check();
            //LoggingHelper.Write("This is a trace log message.", 0, "Start application.");

            LoggingHelper.LogPath = ".\\LOG_TEST2\\Test.log";

            LoggingHelper.Write("This is level 0.", LoggingHelper.Level.TRACE, "Teste 2.1");
            LoggingHelper.Write("This is level 5.", (LoggingHelper.Level)5, "Teste 2.2");
            LoggingHelper.Write("This is level 1.", (int)LoggingHelper.Level.DEBUG, "Teste 2.3");
        }

        [TestFixture]
        public class TestsWrites
        {
            [Test, TestCaseSource(typeof(CasosDeTeste), nameof(CasosDeTeste.Tests))]
            public bool ValidarEscritas(string message, int indLevel, string obs) => LH.LoggingHelper.Write(message, indLevel, obs);
        }

        public class CasosDeTeste
        {
            public static List<TestCaseData> Tests
            {
                get
                {
                    //LH.LoggingHelper.Check();

                    return new List<TestCaseData>()
                     {
                         new TestCaseData($"Esse é o primeiro teste!", 2, null).Returns(true).SetName("Teste padrão sem observação!"),
                         new TestCaseData($"Esse é o segundo teste!", 2, "Isso é uma observação!").Returns(true).SetName("Teste padrão com observação!"),
                         new TestCaseData($"Esse é o teste 3!", 0,"Nível 0").Returns(true).SetName("Teste padrão nível 0!"),
                         new TestCaseData($"Esse é o teste 4!", 1,"Nível 1").Returns(true).SetName("Teste padrão nível 1!"),
                         new TestCaseData($"Esse é o teste 5!", 2,"Nível 2").Returns(true).SetName("Teste padrão nível 2!"),
                         new TestCaseData($"Esse é o teste 6!", 3,"Nível 3").Returns(true).SetName("Teste padrão nível 3!"),
                         new TestCaseData($"Esse é o teste 7!", 4,"Nível 4").Returns(true).SetName("Teste padrão nível 4!"),
                         new TestCaseData($"Esse é o teste 8!", 5,"Nível 5").Returns(true).SetName("Teste padrão nível 5!"),
                         new TestCaseData($"Esse é o teste 9!", 6,"Nível 6").Returns(true).SetName("Teste nível 6!"),
                         new TestCaseData($"Esse é o teste 10!", 7,"Nível 7").Returns(true).SetName("Teste nível 7!"),
                         new TestCaseData("", 2,null).Returns(true).SetName("Teste com mensagem vazia sem observação!"),
                         new TestCaseData(" ", 2,null).Returns(true).SetName("Teste com mensagem em branco e sem observação!"),
                         new TestCaseData(" ", 2,"Mensagem em branco").Returns(true).SetName("Teste com mensagem em branco e com observação!"),

                         new TestCaseData(" ", null,"Tipo nulo #1").Returns(true).SetName("#1 Teste com mensagem e tipo nulo e com observação!"), // !!! OK funcionar? Tipo nulo = 0
                         new TestCaseData($"Esse é o teste negativo #2!", -1,"Nível -1").Returns(false).SetName("#2 Teste nível -1!"), // Nivel >= 0
                         new TestCaseData(null, 2,null).Returns(true).SetName("#3 Teste com mensagem e observação nula!"), // Mensagem != null
                         new TestCaseData("Teste tipo vazio", "","Tipo vazio #4").Returns(true).SetName("#4 Teste com tipo vazio com observação!"), // Tipo vazio
                         new TestCaseData("Teste tipo em branco", " ","Tipo em branco #5").Returns(true).SetName("#5 Teste com mensagem e tipo em branco e comm observação!"), // Tipo em branco

                         new TestCaseData($"Esse é o teste com enumerable 0 (TRACE)!", LoggingHelper.Level.TRACE,"Nível 0").Returns(true).SetName("Teste enum padrão nível 0!"),
                         new TestCaseData($"Esse é o teste com enumerable 5 (CRITICAL)!", (LoggingHelper.Level)5,"Nível 5").Returns(true).SetName("Teste enum padrão nível 5!"),
                         new TestCaseData($"Esse é o teste com enumerable 2 (INFO)!", LoggingHelper.Level.INFO,"Nível 2").Returns(true).SetName("Teste enum padrão nível 2!")
                    };
                }
            }
        }

    }
}