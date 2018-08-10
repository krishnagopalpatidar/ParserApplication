using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ParserApplication.Tests
{

  #region ParserTests class

  /// <summary>
  /// This is test class to test Parser functionality.
  /// </summary>
  [TestClass]
  public class ParserTests 
  {
    public TestContext TestContext { get; set; }
    private ILogger logger = new DebugLogger();

    #region Test methods


    [TestMethod]
    public void Parse_SingleSentenceCount_Test() {
      string input = "I am writing simple sentence.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
    }

    [TestMethod]
    public void Parse_SingleSentence_WordsCount_Test() {
      string input = "I am writing simple sentence.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      Assert.IsTrue(result.First().Words.Count == 5);
    }

    [TestMethod]
    public void Parse_SingleSentence_ValidateWords_Test() {
      string input = "I am writing simple sentence.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      List<string> expectedWordList = new List<string>(){"I", "am", "writing", "simple", "sentence" };
      var setDifference = expectedWordList.Except(result.First().Words).ToList();
      Assert.IsTrue(setDifference.Count == 0);
    }

    [TestMethod]
    public void Parse_Check_AlphabeticalOrderWords_Test() {
      string input = "I am writing simple sentence.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      List<string> expectedWordList = new List<string>(){ "am", "I", "sentence", "simple", "writing" };
      Assert.IsTrue(expectedWordList.SequenceEqual(result.First().Words));
    }

    [TestMethod]
    public void Parse_Check_WithMultipleSpaces_Test() {
      string input = "I         am writing         simple sentence.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      List<string> expectedWordList = new List<string>(){ "am", "I", "sentence", "simple", "writing" };
      Assert.IsTrue(expectedWordList.SequenceEqual(result.First().Words));
    }

    [TestMethod]
    public void Parse_Check_WithMultipleSentences_Test() {
      string input = "I am writing simple sentences. These sentences are part of test cases. This input is part of the ParserTests class.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      Assert.IsTrue(result.Count == 3 && result.First().Words.Count == 5
        && result[1].Words.Count == 7 && result[2].Words.Count == 8);
    }

    [TestMethod]
    public void Parse_SentencesWith_NonAlphabeticCharacters_Test() {
      string input = "I am < > writing : simple sentences. These  ||  \" sentences are { } part of test cases. &*&* This input is part of the ParserTests class.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      Assert.IsTrue(result.Count == 3 && result.First().Words.Count == 5
        && result[1].Words.Count == 7 && result[2].Words.Count == 8);
    }

    [TestMethod]
    public void Parse_WithInterogativeSentences_Test() {
      string input = "Will it run successful? Let's see how it goes? We hope for best.";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count > 0);
      Assert.IsTrue(result.Count == 3 && result.First().Words.Count == 4
        && result[1].Words.Count == 5 && result[2].Words.Count == 4);
    }

    [TestMethod]
    public void Parse_AllNumbersInSentences_Test() {
      string input = "9454569607967.344464657.8787989";
      Parser parser = new Parser(logger);
      List<Sentence> result = parser.Parse(input);
      Assert.IsTrue(result.Count == 0);
    }


    #endregion #region Test methods

  }

  #endregion ParserTests class

}
