using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserApplication.Tests
{

  #region CsvConverterTests class

  /// <summary>
  /// This is test class to test Csv conversion functionality
  /// </summary>
  [TestClass]
  public class CsvConverterTests
  {
    public TestContext TestContext { get; set; }
    private ILogger logger = new DebugLogger();


  [TestMethod]
    public void Convert_Csv_Working_Test() {
      string input = "I am writing simple sentence.";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Length > 0);
      Assert.IsTrue(result.Contains("I") && result.Contains("am") && result.Contains("writing")
        && result.Contains("simple") && result.Contains("sentence"));
    }

    [TestMethod]
    public void Convert_Csv_CheckWordsFormat_Test() {
      string input = "I am writing simple sentence.";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Length > 0);
      Assert.IsTrue(result.StartsWith(", Word 1, Word 2, Word 3, Word 4, Word 5"));
    }

    [TestMethod]
    public void Convert_Csv_MultiSentence_CheckWordsFormat_Test() {
      string input = "I am writing very simple sentence. Its done now.";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Length > 0);
      Assert.IsTrue(result.StartsWith(", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6"));
    }

    [TestMethod]
    public void Convert_Csv_CheckSentence_StartFormat_Test() {
      string input = "I am writing simple sentence.";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Length > 0);
      string[] sentenceRow = result.Split('\n');
      Assert.IsTrue(sentenceRow[1].StartsWith("Sentence 1"));
    }

    [TestMethod]
    public void Convert_Csv_MultiSentence_CheckSentence_StartFormat_Test() {
      string input = "I am writing simple sentence. Its done now. It seems to be very cloudy outside.";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      string[] sentenceRow = result.Split('\n');
      Assert.IsTrue(sentenceRow[1].StartsWith("Sentence 1,"));
      Assert.IsTrue(sentenceRow[2].StartsWith("Sentence 2,"));
      Assert.IsTrue(sentenceRow[3].StartsWith("Sentence 3,"));
    }

    [TestMethod]
    public void Convert_Csv_MultiSentence_CheckFullResult_Test() {
      string input = "I am writing simple sentence. Its done now.";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      string[] sentenceRow = result.Split('\n');
      Assert.IsTrue(sentenceRow[0].StartsWith(", Word 1, Word 2, Word 3, Word 4, Word 5"));
      Assert.IsTrue(sentenceRow[1].StartsWith("Sentence 1, am, I, sentence, simple, writing"));
      Assert.IsTrue(sentenceRow[2].StartsWith("Sentence 2, done, Its, now"));
    }

    [TestMethod]
    public void Convert_Xml_InvalidInput_Test() {
      string input = "**876769898.898&*$$$$980";
      IConverter csvConverter = new CsvConverter(logger);
      string result = csvConverter.Convert(input);
      Assert.IsNotNull(result);
      Assert.IsFalse(result.Length > 0);
    }

  }

  #endregion CsvConverterTests

}
