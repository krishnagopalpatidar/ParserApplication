using System.Collections.Generic;


namespace BusinessLayer
{

  #region Sentence class

  /// <summary>
  /// Sentence class to represent sentences and words in sentences.
  /// </summary>
  public class Sentence
  {
    /// <summary>
    /// Constructor- initializes a new instance of Sentence class.
    /// </summary>
    public Sentence() { }


    /// <summary>
    /// Constructor- initializes a new instance of Sentence class.
    /// </summary>
    /// <param name="words">List of words in a sentence.</param>
    public Sentence(List<string> words) {
      Words = words;
    }

    /// <summary>
    /// Gets or sets list of words in a sentence.
    /// </summary>
    public List<string> Words { get; set; }
  }

  #endregion Sentence class

}