using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class _ParserMain : Page
{
 
  private IConverter _iConverter = null;

  #region Events

  protected void btnConvert_Click(object sender, EventArgs e) {
    txtOutput.Text = string.Empty;
    SetConverter(rdblistFormat.SelectedValue);
    txtOutput.Text = _iConverter.Convert(!string.IsNullOrEmpty(txtInput.Text) ? txtInput.Text : string.Empty);
  }

  #endregion Events

  #region Private methods

  private void SetConverter(string format) {
    ConverterFactory factory = new ConcreteConverterFactory();
    _iConverter = factory.GetConverter(format);
  }

  #endregion Private methods

}
