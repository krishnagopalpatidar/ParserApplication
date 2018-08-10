using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BusinessLayer
{

  #region Parser class
  
  /* TEMPORARY COMMENT- Depending on Parsing needed in this application, a deciosion has to be made if Parser class
   can be Singleton. And its one object and Parse method can be used throughout the application. 
   But if different types of parsing might be needed, then we might need changes in Parser class.
   So, considering this, going for "Open/Closed" principle in this case. So, Parser class is open for
   extension. Hene, we make Parse method as virtual. So, in future if any converter needs different type of parsing
   it can override Parse method. Rest converters will use it as it is.   */

  /// <summary>
  /// Parser class- Class responsible for parsing of given input text.
  /// </summary>
  public class Parser
  {
    private readonly char[] _sentenceEndCharacters = { '.', '?', '!' };
    private ILogger logger;

    #region Constructor

    /// <summary>
    /// Constructor- initializes a new instance of Parser class.
    /// </summary>
    /// <param name="iLogger">object of ILogger type to indicate type of logging to be done.</param>
    public Parser(ILogger iLogger) {
      logger = iLogger;
    }

    #endregion  

    /// <summary>
    /// This method does parsing of given text/string input- it breaks input in sentences and words and prepate list of 'Sentences' model/entity.
    /// </summary>
    /// <param name="input">Input text to be parsed..</param>
    /// <returns>It returns a list of Sentence model/entity type as parsing result.</returns>
    public virtual List<Sentence> Parse(string input) {
      var parsedSentences = new List<Sentence>();
      try {
        var sentences = input.Split(_sentenceEndCharacters, StringSplitOptions.RemoveEmptyEntries);
        foreach (var sentence in sentences) {
          var words = ReplaceInvalidCharacters(sentence)
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(RemoveInvalidStartCharacters)
                    .Select(RemoveInvalidEndCharacters)
                    .Where(w => !string.IsNullOrWhiteSpace(w))
                    .Where(w => !w.All(char.IsPunctuation))
                    .OrderBy(w => w)
                    .ToList();
          if (words.Count > 0) {
            parsedSentences.Add(new Sentence(words));
          }
        }
      }
      catch (Exception ex) {
        logger.Log("Some error occured in Parser.Parse method. Error details are- " + ex.Message);
      }
      return parsedSentences;
    }

    #region Private methods

    private string ReplaceInvalidCharacters(string s) {
      return Regex.Replace(s, "[^a-zA-Z'-]+", " ");
    }

    private string RemoveInvalidStartCharacters(string s) {
      s = Regex.Replace(s, "^'+", "");
      return Regex.Replace(s, "^-+", "");
    }

    private string RemoveInvalidEndCharacters(string s) {
      return Regex.Replace(s, "-+$", "");
    }

    #endregion

  }

  #endregion Parser class

}
