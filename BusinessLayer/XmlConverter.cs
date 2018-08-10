using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BusinessLayer
{

  #region XmlConverter class

  /// <summary>
  /// XmlConverter class- Class responsible for XML formatting.
  /// </summary>
  public class XmlConverter : Parser, IConverter
  {
    private ILogger logger;

    #region Constructor

    /// <summary>
    /// Constructor- initializes a new instance of XmlConverter class.
    /// </summary>
    /// <param name="iLogger">object of ILogger type to indicate type of logging to be done.</param>
    public XmlConverter(ILogger iLogger) : base(iLogger) {
      logger = iLogger;
    }

    #endregion  

    /// <summary>
    /// This method gets parsing output for given input and then creates and returns specific XML formatted text.
    /// </summary>
    /// <param name="input">Input text to be parsed and formatted in specific XML output.</param>
    /// <returns>It returns a string/text output in a specific XML format.</returns>
    public string Convert(string input) {

      List<Sentence> inputSentences = Parse(input);
      StringBuilder xmlOutput = new StringBuilder();

      try {
        var sentenceElements = inputSentences.Select(sentence =>
      {
        var wordElements = sentence.Words.Select(word => new XElement("word", word));
        return new XElement("sentence", wordElements);
      });
        var rootElement = new XElement("text", sentenceElements);
        var xmlDeclaration = new XDeclaration(Constants.XML_VERSION, Constants.XML_ENCODING, Constants.XML_IS_STANDALONE);
        XDocument xDoc = new XDocument(xmlDeclaration, rootElement);
        
        using (StringWriter writer = new StringWriter(xmlOutput)) {
          xDoc.Save(writer);
        }
      }

      catch(Exception ex) {
        logger.Log("Some error occured in XmlConverter.Convert method. Error details are- " + ex.Message);
      }

      return xmlOutput.ToString();
    }

  }

  #endregion XmlConverter class

}







