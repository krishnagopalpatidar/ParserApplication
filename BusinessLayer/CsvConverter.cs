using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{

  #region CsvConverter class

  /// <summary>
  /// CsvConverter class- Class responsible for CSV formatting.
  /// </summary>
  public class CsvConverter : Parser, IConverter
  {
    private ILogger logger;

    #region Constructor

    /// <summary>
    /// Constructor- initializes a new instance of CsvConverter class.
    /// </summary>
    /// <param name="iLogger">object of ILogger type to indicate type of logging to be done.</param>
    public CsvConverter(ILogger iLogger) : base(iLogger) {
      logger = iLogger;
    }

    #endregion  

    /// <summary>
    /// This method gets parsing output for given input and then creates and returns CSV formatted text.
    /// </summary>
    /// <param name="input">Input text to be parsed and formatted in specific CSV output.</param>
    /// <returns>It returns a string/text output in a specific CSV format.</returns>
    public string Convert(string input) {

      StringBuilder csvOutput = new StringBuilder();

      try {    
        int sentenceNumber = 1;
        List<Sentence> inputSentences = Parse(input);

        var maximumWordsCount = inputSentences.Max(s => s.Words.Count);
        var wordsRange = Enumerable.Range(1, maximumWordsCount);
        var columnHeaders = wordsRange.Select(i => $", Word {i}");
        //Create csv header
        csvOutput.AppendLine(string.Join("", columnHeaders));

        //Create csv data
        foreach (var sentence in inputSentences) {
          csvOutput.Append($"Sentence {sentenceNumber}, ");
          csvOutput.AppendLine(string.Join(", ", sentence.Words));
          sentenceNumber++;
        }
      }

      catch (Exception ex) {
        logger.Log("Some error occured in CsvConverter.Convert method. Error details are- " + ex.Message);
      }

      return csvOutput.ToString();
    }

  }

  #endregion CsvConverter class

}
