<%@ Page Language="C#" MasterPageFile="~/MasterSheet.Master" AutoEventWireup="true" CodeBehind="Ex01Calc.aspx.cs" Inherits="SampleWebApp.Ex01Calc" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
     <div>
            <h1 style="text-align: center; font-style: italic; text-decoration: underline; color: #CC99FF">Calculator</h1>
            <hr />  
            <p> 
               Enter the First Value:
                <asp:TextBox runat="server" ID="txtFirstNo" />
            </p>
            <p>
                Select the Option:
                <asp:DropDownList runat="server" ID="dpList">
                    <asp:ListItem Text="Add" />
                    <asp:ListItem Text="Subtract" />
                    <asp:ListItem Text="Multiply" />
                    <asp:ListItem Text="Division" />
                </asp:DropDownList>
            </p>
             <p> 
                Enter the Second Value:
                <asp:TextBox runat="server" ID="txtSecondNo" />
            <p>
                <asp:Button Text="Get Result" runat="server" ID="btnResult" OnClick="btnResult_Click" />
            </p>
            <p>
                <asp:Label Text="The Result" runat="server" ID="lblDisplay" />
            </p>
        </div>
</asp:Content>



