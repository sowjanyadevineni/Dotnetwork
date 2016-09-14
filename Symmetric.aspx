<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Symmetric.aspx.cs" Inherits="Assignment4.Symmetric" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="text-align:center;"> <h2>Encryption-Decryption using Symentric key</h2></div>
    <table align="center" width="90%">

        <tr>
            <td height="50px" align="right">&nbsp;</td>
            <td height="50px">Message To Encrypt :</td>
            <td>
                <asp:TextBox ID="txtPlainText" CssClass="txt" runat="server">
                </asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlainText" ErrorMessage="Enter text to encrypt!" 
                            ForeColor="Red" Display="Dynamic" ValidationGroup="SYM">
                    </asp:RequiredFieldValidator> 
                </td>
            <td></td>
        </tr>
        <tr>
            <td height="50px" width="25%">&nbsp;</td>
            <td width="25%" colspan="2" style="width: 50%" align="center">
                <asp:Button ID="btnGenerateSymKey" CssClass="btn" runat="server" Text="Generate a symmetric key" OnClick="btnGenerateSymKey_Click" ValidationGroup="SYM" />
            </td>
            <td width="25%">&nbsp;</td>
        </tr>
        <tr>
            <td height="50px">&nbsp;</td>
            <td>Symmetric Key :      
                <td>

                    <asp:TextBox ID="txtSymKey" CssClass="txt" runat="server"></asp:TextBox>

                </td>
                <td>&nbsp;</td>
        </tr>
        <tr>
            <td height="50px" width="25%">&nbsp;</td>
            <td width="25%" colspan="2" style="width: 50%" align="center">
                <asp:Button ID="btnEncryptSym" CssClass="btn" runat="server" Text="Encrypt Message" OnClick="btnEncryptSym_Click" ValidationGroup="SYM"/>
            </td>
            <td width="25%">&nbsp;</td>
        </tr>
        <tr>
            <td height="50px" width="25%">&nbsp;</td>
            <td width="25%">Enctepted Messege :
            </td>
            <td width="25%">
                <asp:TextBox ID="txtCiphertext" CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td width="25%">&nbsp;</td>
        </tr>
        <tr>
            <td height="50px" width="25%">
                <td width="25%" colspan="2" style="width: 50%" align="center">
                    <asp:Button ID="btnDecryptSym" CssClass="btn" runat="server" Text="Decrypt Message" OnClick="btnDecryptSym_Click" /></td>
                <td width="25%">&nbsp;</td>
        </tr>
        <tr>
            <td height="50px">&nbsp;</td>
            <td>Decrypted Message :
            </td>
            <td>
                <asp:TextBox ID="txtCipherToPlain" CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td height="50px" width="25%">
                <td width="25%" colspan="2" style="width: 50%" align="center">
                    <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="Reset" OnClick="btnReset_Click" /></td>
                <td width="25%">&nbsp;</td>
        </tr>
        <%--<tr>
            <td height="50px">
                <asp:Button ID="btnPublicPrivate" CssClass="btn" runat="server" Text="Generate Public-Private Key Paire" OnClick="btnPublicPrivate_Click" /></td>
            <td>
                <asp:TextBox ID="txtPublicKey" CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPrivateKey" CssClass="txt" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>--%>


        <%-- <tr>
            <td height="50px">3.</td>
            <td>Type Text :</td>
            <td>
        </tr>
        <tr>
            <td height="50px">4.</td>
            <td>
                <asp:Button ID="btngenerateHash" CssClass="btn" runat="server" Text="Generate Hash" OnClick="btngenerateHash_Click" /></td>
            <td>
                <asp:TextBox ID="txtGenerateHash" CssClass="txt" runat="server"></asp:TextBox>

            </td>
            <td></td>
        </tr>
        <tr>
            <td height="50px"></td>
            <td>Text To Validate :
                        <asp:TextBox ID="txtPlainTextAgain" CssClass="txt" runat="server"></asp:TextBox>
                <td>Hash To Validate :
                            <asp:TextBox ID="txtHashToValidate" CssClass="txt" runat="server"></asp:TextBox>

                </td>
                <td>
                    <asp:Button ID="btnValidateHash" CssClass="btn" runat="server" Text="Validate Hash" OnClick="btnValidateHash_Click" /></td>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>--%>
    </table>
</asp:Content>
