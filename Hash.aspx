<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Hash.aspx.cs" Inherits="Assignment4.Hash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;"> <h2>Encryption-Decryption using Hashing Algorithem</h2></div>
    <table align="center" width="90%">
        <tr>
            <td width="25%" height="50px" align="right">&nbsp;</td>
            <td width="25%" height="50px">Message To Encrypt :</td>
            <td width="25%">
                <asp:TextBox ID="txtPlainText" CssClass="txt" runat="server">
                </asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlainText" ErrorMessage="Enter text to encrypt!" 
                            ForeColor="Red" Display="Dynamic" ValidationGroup="SYM">
                    </asp:RequiredFieldValidator> 
            </td>
            <td width="25%"></td>
        </tr>
        <tr>
            <td height="50px"></td>
            <td colspan="2" align="center">
                <asp:Button ID="btngenerateHash" CssClass="btn" runat="server" ValidationGroup="SYM" Text="Generate Hash" OnClick="btngenerateHash_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td height="50px"></td>
            <td>Hash Code :</td>
            <td>
                <asp:TextBox ID="txtGenerateHash" CssClass="txt" runat="server" ValidationGroup="SYM"></asp:TextBox>
            </td>

            <td></td>
        </tr>
        <tr>
            <td height="50px"></td>
            <td>Message To Validate Hash :</td>
            <td>
                <asp:TextBox ID="txtPlainTextAgain" CssClass="txt" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtPlainTextAgain" ErrorMessage="Enter text to validate!" 
                            ForeColor="Red" Display="Dynamic" ValidationGroup="S">
                    </asp:RequiredFieldValidator> 
            </td>

            <td></td>
        </tr>
        <tr>
            <td height="50px"></td>
            <td colspan="2" align="center">
                <asp:Button ID="btnValidateHash" CssClass="btn" runat="server" Text="Validate Hash" OnClick="btnValidateHash_Click" width="30%" ValidationGroup="S"/>
                &nbsp;
                    <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="Reset" OnClick="btnReset_Click" width="30%"/>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
