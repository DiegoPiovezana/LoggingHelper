using LH;

namespace TestLoggingHelper
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPass()
        {
            Assert.Pass();
        }

        [Test]
        public void CodeExampleReadme()
        {
            try
            {
                //LoggingHelper.Check();
                LoggingHelper.Write("This is a trace log message.", 0, "Start application.");
                LoggingHelper.Write("Debug message.", 1, null);
                LoggingHelper.Write("This is a message for an information log [2].", 2, null);
                LoggingHelper.Write("This is also a message for an information log [3].", LoggingHelper.Level.INFO, null);
                LoggingHelper.Write("This is also a message for an information log [4].", "INFO", null);
                LoggingHelper.Write("This is also a message for an information log [5].", "2", null);

                throw new Exception();
            }
            catch (Exception ex)
            {
                LoggingHelper.Write("This is a log message for logging errors!", 4, ex.Message);
            }
        }

        [Test]
        public void TestSimple()
        {           
            //LoggingHelper.LogPath = ".\\LOG_TEST\\Logging_general.log";
            //LoggingHelper.Check();
            //LoggingHelper.Write("This is a trace log message.", 0, "Start application.");

            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            LoggingHelper.Write("This is level 0.", LoggingHelper.Level.TRACE, "Teste 2.1");
            LoggingHelper.Write("This is level 5.", (LoggingHelper.Level)5, "Teste 2.2");
            LoggingHelper.Write("This is level 1.", (int)LoggingHelper.Level.DEBUG, "Teste 2.3");
        }        

        [Test]
        public void TestNullMessage()
        {
            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            // #3 Test with null message and observation! (Message == null ok)

            Assert.That(LoggingHelper.Write(null, 2, null), Is.True);
        }

        [Test]
        public void TestNegativeLevel()
        {
            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            // #2 Test with level -1! (Level >= 0)

            Assert.Throws<ArgumentException>(() =>
            {
                LoggingHelper.Write($"This is the negative test #2!", -1, "Level -1");
            }, "E-00001-LH: Log message level (-1) is invalid!");
        }

        [Test]
        public void TestNullLevel()
        {
            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            // #1 Test with null message and level and with observation
            
            //Assert.That(LoggingHelper.Write(" ", null, "Null type #1"), Is.True);

            // !!! OK ? null = 0


            Assert.Throws<ArgumentException>(() =>
            {
                LoggingHelper.Write(" ", null, "Null type #1");
            }, "E-00001-LH: Log message level cannot be null or empty!");
        }        

        [Test]
        public void TestEmptyLevel()
        {
            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            // #4 Test with empty level

            //Assert.That(LoggingHelper.Write("Test empty type", "", "Empty type #4"), Is.True);


            Assert.Throws<ArgumentException>(() =>
            {
                LoggingHelper.Write("Test empty type", "", "Empty type #4");
            }, "E-00001-LH: Log message level cannot be null or empty!");
        }

        [Test]
        public void TestBlankLevel()
        {
            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            // #5 Test with blank level            

            Assert.Throws<ArgumentException>(() =>
            {
                LoggingHelper.Write("Blank type test", " ", "Blank type #5");
            }, "E-00001-LH: Log message level cannot be null or empty!");
        }

        [Test]
        public void TestInvalityLevel()
        {
            LoggingHelper.LogPathFile = ".\\LOG_TEST\\Test.log";

            Assert.Multiple(() =>
            {
                Assert.That(LoggingHelper.Write("Test Invality Level 1", "1", null), Is.True);
                Assert.That(LoggingHelper.Write("Test Invality Level 1", "INFO", null), Is.True);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                LoggingHelper.Write("Test Invality Level 1", "Outro", null);
            },"E-00002-LH: Log message level (Outro) is not defined in 'Level' property!");
        }

        [TestFixture]
        public class TestsWrites
        {
            [Test, TestCaseSource(typeof(TestCases), nameof(TestCases.Tests))]
            public bool CheckWrites(string message, int indLevel, string obs) => LH.LoggingHelper.Write(message, indLevel, obs);
        }

        public class TestCases
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
                          
                         new TestCaseData($"Esse é o teste com enumerable 0 (TRACE)!", LoggingHelper.Level.TRACE,"Nível 0").Returns(true).SetName("Teste enum padrão nível 0!"),
                         new TestCaseData($"Esse é o teste com enumerable 5 (CRITICAL)!", (LoggingHelper.Level)5,"Nível 5").Returns(true).SetName("Teste enum padrão nível 5!"),
                         new TestCaseData($"Esse é o teste com enumerable 2 (INFO)!", LoggingHelper.Level.INFO,"Nível 2").Returns(true).SetName("Teste enum padrão nível 2!")
                    };
                }
            }
        }

    }
}