<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="ParserMain.aspx.cs" Inherits="_ParserMain" ValidateRequest="false" Debug="true" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parser</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1>PARSER</h1>
        </div>

        <div>
            <div style="float: left; width: 50%;">
                <table style="width: 100%;">
                    <tr>
                        <p class="lead">
                            This parser will parse English sentences given in input and produce output
                            <br />
                            in XML/CSV format.
                        </p>
                        <td>
                            <asp:Label ID="labelInstruction" runat="server" Text="Enter your text input to parse in below box."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtInput" runat="server" TextMode="MultiLine" Rows="15" Width="500" Style="overflow: scroll"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                &nbsp;&nbsp;
                    <asp:RadioButtonList ID="rdblistFormat" runat="server" RepeatDirection="Horizontal" Width="510px">
                        <asp:ListItem Selected="True" Value="XML">Convert in XML format</asp:ListItem>
                        <asp:ListItem Value="CSV">Convert in CSV format</asp:ListItem>
                    </asp:RadioButtonList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr />
                    <tr />
                    <tr />
                    <tr />
                    <tr />
                    <tr />
                    <tr />
                    <tr />
                    <tr>
                        <td>
                            <asp:Button ID="btnConvert" runat="server" Text="Convert" OnClick="btnConvert_Click" Style="height: 30px; width: 164px; margin-left: 125px" />

                        </td>
                    </tr>

                </table>
            </div>
            <div style="float: right; width: 50%;">
                <tr>
                    <td>
                        <asp:Panel ID="outputPanel" runat="server" GroupingText="Parser Output">
                            <asp:TextBox ID="txtOutput" runat="server" TextMode="MultiLine" Rows="30" Width="550" ReadOnly="true" Style="overflow: scroll" Wrap="false"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
            </div>
        </div>
    </form>
</body>
</html>
