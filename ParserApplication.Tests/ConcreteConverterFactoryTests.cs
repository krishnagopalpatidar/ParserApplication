using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserApplication.Tests
{
  /// <summary>
  /// This is test class to test Csv conversion functionality
  /// </summary>
  [TestClass]
  public class ConcreteConverterFactoryTests
  {
    public TestContext TestContext { get; set; }


    [TestMethod]
    public void Create_XmlConverter_Object_Test() {
      ConverterFactory factory = new ConcreteConverterFactory();
      IConverter converter = factory.GetConverter("XML");
      Assert.IsTrue(converter is XmlConverter);
    }

    [TestMethod]
    public void Create_CsvConverter_Object_Test() {
      ConverterFactory factory = new ConcreteConverterFactory();
      IConverter converter = factory.GetConverter("CSV");
      Assert.IsTrue(converter is CsvConverter);
    }

    [TestMethod]
    [ExpectedException(typeof(ApplicationException), "Converter xyz cannot be created.")]
    public void Create_InvalidFormatPassed_Test() {
      ConverterFactory factory = new ConcreteConverterFactory();
      IConverter converter = factory.GetConverter("xyz");
    }

  }
}
