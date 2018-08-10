using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ParserApplication.Tests
{

  #region XmlConverterTests classs

  /// <summary>
  /// This is test class to test Xml conversion functionality.
  /// </summary>
  [TestClass]
  public class XmlConverterTests
  {
    public TestContext TestContext { get; set; }
    private ILogger logger = new DebugLogger();

    [TestMethod]
    public void Convert_Xml_Working_Test() {
      string input = "I am writing simple sentence.";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Length > 0);
      Assert.IsTrue(result.Contains("I") && result.Contains("am") && result.Contains("writing")
        && result.Contains("simple") && result.Contains("sentence"));
    }

    [TestMethod]
    public void Convert_Xml_Check_textnode_Test() {
      string input = "I am writing simple sentence.";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      Assert.IsNotNull(result);
      XDocument xDoc = XDocument.Parse(result);
      XName text = XName.Get("text");
      IEnumerable<XElement> elements = xDoc.Elements(text);
      Assert.IsTrue(elements.ToString().Length > 0);
    }

    [TestMethod]
    public void Convert_Xml_Check_sentencenode_Test() {
      string input = "I am writing simple sentence.";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      Assert.IsNotNull(result);
      XDocument xDoc = XDocument.Parse(result);
      IEnumerable<XElement> elements = xDoc.Elements(XName.Get("text"));
      IEnumerable<XNode> nodes = elements.Nodes();
      Assert.IsTrue(nodes.ElementAt(0).ToString().StartsWith("<sentence>"));
    }

    [TestMethod]
    public void Convert_Xml_Check_wordnode_Test() {
      string input = "I am writing simple sentence.";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      Assert.IsNotNull(result);
      XDocument xDoc = XDocument.Parse(result);
      IEnumerable<XElement> elements = xDoc.Elements(XName.Get("text"));
      IEnumerable<XNode> nodes = elements.Nodes();
      foreach(XNode node in nodes) {
        Assert.IsNotNull(node.XPathSelectElement("word").Name);
        Assert.IsTrue(!string.IsNullOrEmpty(node.XPathSelectElement("word").Name.ToString()));
      }
    }

    [TestMethod]
    public void Convert_Xml_CheckFullResult_TwoSentences_Test() {
      string input = "I am writing simple sentence. Its done now.";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      Assert.IsNotNull(result);
      XDocument xDoc = XDocument.Parse(result);
      Assert.IsTrue(xDoc.XPathSelectElements("/text/sentence").Count() == 2);
    }

    [TestMethod]
    public void Convert_Xml_CheckFullResult_ThreeSentences_Test() {
      string input = "I am writing simple sentence. Its done now. It seems to be very cloudy outside.";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      Assert.IsNotNull(result);
      XDocument xDoc = XDocument.Parse(result);
      Assert.IsTrue(xDoc.XPathSelectElements("/text/sentence").Count() == 3);
    }

    [TestMethod]
    public void Convert_Xml_InvalidInput_Test() {
      string input = "**876769898.898&*$$$$980";
      IConverter xmlConverter = new XmlConverter(logger);
      string result = xmlConverter.Convert(input);
      XDocument xDoc = XDocument.Parse(result);
      Assert.IsNotNull(xDoc);
      Assert.IsFalse(xDoc.XPathSelectElements("/text/sentence").Count() > 0);
    }

  }

  #endregion XmlConverterTests classs

}
