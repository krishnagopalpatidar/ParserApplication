using System;


namespace BusinessLayer
{
  /* TEMPORARY COMMENT- ConverterFactory class follows Factory method design pattern. It has abstract method
     which should be overriden to create objects of IConverter family. */

  #region ConverterFactory - Creator, abstract class

  /// <summary>
  /// The 'Creator' (ConverterFactory) abstract Class. Factory method to get converter object.
  /// </summary>
  public abstract class ConverterFactory
  {
    /// <summary>
    /// This is an abstract method to get converter type object created based on given format input (expected output format).
    /// </summary>
    /// <param name="outputFormat">Format of expected output.</param>
    /// <returns>It returns a converter object of IConverter type.</returns>
    public abstract IConverter GetConverter(string outputFormat);
  }

  #endregion ConverterFactory - Creator, abstract class

  /* TEMPORARY COMMENT- ConcreteConverterFactory class follows Factory method design pattern. It takes
     care of creating objects of IConverter family. */

  #region ConcreteConverterFactory - ConcreteCreator class

  /// <summary>
  /// A 'ConcreteCreator' (ConcreteConverterFactory) class
  /// </summary>
  public class ConcreteConverterFactory : ConverterFactory
  {

    /// <summary>
    /// This is a factory method to get converter type object created based on given format input (expected output format).
    /// </summary>
    /// <param name="outputFormat">Format of expected output.</param>
    /// <returns>It returns a converter object of IConverter type.</returns>
    public override IConverter GetConverter(string outputFormat) {

      switch (outputFormat) {

        case "XML":
          return new XmlConverter(new DebugLogger());

        case "CSV":
          return new CsvConverter(new DebugLogger());

        default:
          throw new ApplicationException(string.Format("Converter '{0}' cannot be created.", outputFormat));
      }
    }

  }

  #endregion ConcreteConverterFactory - ConcreteCreator class

}
